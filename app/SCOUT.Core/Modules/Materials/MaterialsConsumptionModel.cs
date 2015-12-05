using System.Collections.Generic;
using System.ComponentModel;
using SCOUT.Core.Data;
using SCOUT.Core.Modules.Materials;

namespace SCOUT.Core.Mvc
{
    public class MaterialsConsumptionModel : PersistentModel, INotifyPropertyChanged
    {        
        private Dictionary<MaterialConsumableItem, int> m_consumptionRequests;

        public MaterialsConsumptionModel(BomConfiguration configuration) : base(configuration.Session)
        {
            m_consumptionRequests = new Dictionary<MaterialConsumableItem, int>();
            ConsumptionDescription = configuration.Description;
            PartsToConsume  = new List<PartToConsume>();
            Shopfloorline = configuration.Shopfloorline;
            MapItemToPartsToConsume(configuration);                      
        }

        private void MapItemToPartsToConsume(BomConfiguration configuration)
        {
            foreach (var item in configuration.ConfigurationItems)
            {
                PartsToConsume.Add(new PartToConsume(item.BomComponent.Part, item.Qty, item.UsageAction));
            }
        }

//        public MaterialsConsumptionModel(IUnitOfWork unitOfWork, string consumptionDescription, List<PartToConsume> partsToConsume, Shopfloorline shopfloorline, string consumedInLotId) : base(unitOfWork)
//        {
//            m_consumptionRequests = new Dictionary<MaterialConsumableItem, int>();
//            ConsumptionDescription = consumptionDescription;
//            PartsToConsume = partsToConsume;
//            Shopfloorline = shopfloorline;
//        }

        public void AddConsumptionRequest(MaterialConsumableItem item, int qty)
        {
            if (!m_consumptionRequests.ContainsKey(item))
                m_consumptionRequests.Add(item, qty);
            else
            {
                m_consumptionRequests[item] = qty;
            }
        }

        public string ConsumptionDescription { get; set; }
        public List<PartToConsume> PartsToConsume { get; set; }
        public Shopfloorline Shopfloorline { get; private set; }
        public string ConsumedInLotId { get; set; }


        public Dictionary<MaterialConsumableItem, int> ConsumptionRequests
        {
            get { return m_consumptionRequests; }
        }


        internal void RemoveConsumedQtys()
        {
            foreach (KeyValuePair<MaterialConsumableItem, int> i in m_consumptionRequests)
            {
                i.Key.Qty -= i.Value;                
            }
        }

        internal void RefreshConsumableMaterials()
        {
            foreach (KeyValuePair<MaterialConsumableItem, int> i in m_consumptionRequests)
            {
                i.Key.Reload();
            }                        
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
    }
}