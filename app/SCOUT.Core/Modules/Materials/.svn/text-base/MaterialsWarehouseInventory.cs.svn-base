using System;
using System.Linq.Expressions;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using IRepository = SCOUT.Core.Providers.Data.IRepository;

namespace SCOUT.Core.Modules.Materials
{
    public class MaterialsWarehouseInventory
    {
        private IRepository m_repository;        
       
        public MaterialsWarehouseInventory(IRepository repository)
        {
            m_repository = repository;
        }

        public MaterialWarehouseItem IncreaseItemQuantity(Part part, Domain domain, string rackLocation, int quantity)
        {
            var item = m_repository.GetAndCreateIfNotFound
                (DefaultSearchExpression(part, domain, rackLocation), 
                    DefaultMapping(part,domain,rackLocation,quantity));

            item.IncreaseQty(quantity);

            return item;
        }

        public MaterialWarehouseItem DecreaseItemQuantity(Part part, Domain domain, string rackLocation, int quantity)
        {
            var item = m_repository.Get(DefaultSearchExpression(part, domain, rackLocation));

            if (item == null){                
                throw new NullReferenceException("Warehouse item not found.");
            }
                           
           item.DecreaseQty(quantity);

           return item;
        }
      
        public static Expression<Func<MaterialWarehouseItem,bool>> DefaultSearchExpression(Part part, Domain domain, string rackLocation)
        {
            return (d) => d.Part.Id == part.Id
                          && d.Domain.Id == domain.Id
                          && (rackLocation == null ? d.RackLocation == null : d.RackLocation == rackLocation);
        }

        public static Action<MaterialWarehouseItem> DefaultMapping(Part part, Domain domain, string rackLocation, int quantity)
        {
            Action<MaterialWarehouseItem> mapping = d =>
            {
                d.Part = part;
                d.Qty = 0;
                d.RackLocation = rackLocation;
                d.Domain = domain;
            };

            return mapping;
        }

        public event EventHandler<UserMessageEventArgs> MessageRaised;
    }
}