using System.Collections.Generic;
using System.Linq;
using SCOUT.Core.Data;

namespace SCOUT.Core.Modules.Orders
{
    public class OrderData : IOrderData
    {
        public ICollection<ShippingConfiguration> GetShippingConfigurations(IUnitOfWork uow, Shopfloorline sfl)
        {
            return Scout.Core.Data.GetRepository(uow)
                .Find<ShippingConfiguration>()
                .Where(c => c.Shopfloorline.Id == sfl.Id && c.Active)
                .ToList();
        }
    }

    public interface IOrderData
    {
        ICollection<ShippingConfiguration> GetShippingConfigurations(IUnitOfWork uow, Shopfloorline sfl);
    }
}