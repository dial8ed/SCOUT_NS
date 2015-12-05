using SCOUT.Core.Utils;

namespace SCOUT.Core.Data
{
    public class ShipmentScript : IShipmentScript
    {       
        public IMapper<ShipmentFacts, Shipment> ShipmentMapper { get; set; }
        public IMapper<Shipment, Transaction> TransactionMapper { get; set; }        
        private IUnitOfWork m_uow;

        public ShipmentScript(  
                                IMapper<ShipmentFacts,Shipment> shipmentMapper,
                                IMapper<Shipment, Transaction> transactionMapper)
        {

            ExecutionHelpers.ThrowIfNull(() => shipmentMapper, "Shipment Mapper cannot be null");
            ExecutionHelpers.ThrowIfNull(() => transactionMapper, "Transaction Mapper cannot be null");

            ShipmentMapper = shipmentMapper;
            TransactionMapper = transactionMapper;            
        }

        #region ITransactionScript Members


        public bool Run(ShipmentFacts facts, Packlist packlist)
        {                       
            m_uow = facts.SalesOrder.Session;

            // Associate shipment with sales order
            Shipment shipment = ShipmentMapper.MapFrom(facts);
                       
            // Update the new lot qty after the shipment                
            shipment.Item.Ship(shipment);

            // Create Transaction
            // implicit data record creation          
            TransactionMapper.MapFrom(shipment);
                       
            // Tell the line item to update its status from this shipment
            shipment.LineItem.UpdateStatusFromShipment(shipment.Qty);

            // Add shipment to packlist            
            packlist.AddShipment(shipment);
                       
            //Persist                
            Scout.Core.Data.Save(m_uow);
            
            return true;
        }

        #endregion
    }
}