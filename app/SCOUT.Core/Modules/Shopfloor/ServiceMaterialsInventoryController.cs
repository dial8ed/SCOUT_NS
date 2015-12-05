using System;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Warehouse.Inventory;
using SCOUT.Core.Services;
using SCOUT.Core.Utils;
using IRepository = SCOUT.Core.Providers.Data.IRepository;

namespace SCOUT.Core.Modules.Shopfloor
{
    public class ServiceMaterialsInventoryController
    {
        private IUnitOfWork m_unitOfWork;
        private IRepository m_repo;

        public ServiceMaterialsInventoryController(IUnitOfWork unitOfWork, IRepository repo)
        {
            m_unitOfWork = unitOfWork;
            m_repo = repo;
        }

        public ServiceMaterialsInventoryController()
        {
            m_unitOfWork = Scout.Core.Data.GetUnitOfWork();
            m_repo = Scout.Core.Data.GetRepository(m_unitOfWork);
        }

        public int Consume(string partNumber, int shopfloorlineId, int qty, string source, string lotId)
        {
            var part = m_repo.Get<Part>(p => p.PartNumber == partNumber);           
            var sfl = m_repo.Get<Shopfloorline>(s => s.Id == shopfloorlineId);
            Transaction trans;

            var item = MaterialRepository.GetConsumableItemByPart(m_unitOfWork, part, sfl);
            try
            {
                item.ThrowIfNull(partNumber + " was not found in consumable inventory.");                                                             
                item.DecreaseQty(qty);
                trans = MaterialService.WriteConsumptionTransaction(item, qty, source + " material consumed.", lotId);
                m_unitOfWork.OnLockingException += (s, e) =>
                                                {
                                                    m_unitOfWork.ReloadChangedObjects();
                                                    Consume(partNumber, shopfloorlineId, qty, source, lotId);
                                                };            
                m_unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return default(int);
            }
                           
            return trans.TransId;
        }

        public bool Undo(RepairComponent rc, Transaction transaction)
        {
            var part = m_repo.Get<Part>(p => p.Id == transaction.Part.Id);
            var sfl = m_repo.Get<Shopfloorline>(s => s.Label == transaction.DepartLocation);            
            
            var transType = new AdjustmentTransactionType("MATLUNDO", "Service part consumption reversed", "IN");

            ExecutionHelpers.ThrowIfNull(() => rc, "Cannot find repair record for this transaction.");

            rc.ConsumptionId = default(int);

            return MaterialService.AdjustMaterialConsumableItem
                (part, sfl, transaction.Qty, "Service part consumption reversed.", transType, null);

        }

    }
}