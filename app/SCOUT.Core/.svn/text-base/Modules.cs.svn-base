using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SCOUT.Core.Modules;
using SCOUT.Core.Modules.Orders;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class Modules
    {
        private ServiceRegistry m_registry;
       
        public Modules()
        {
            m_registry = new ServiceRegistry();
            m_registry.Register<IShopfloorModule>(new ShopfloorModule());
            m_registry.Register<IWarehouseModule>(new WarehouseModule());
            m_registry.Register<IClientModule>(new ClientModule());   
            m_registry.Register<IOrderModule>(new OrderModule());
        }

        public ICollection<IModule> AllModules()
        {
            object[] modules = new object[m_registry.Registry.Values.Count];
            m_registry.Registry.Values.CopyTo(modules,0);
            
            Collection<IModule> ret = new Collection<IModule>();

            for (int i = 0; i < modules.Length; i++)
            {
                ret.Add(modules[i] as IModule);
            }

            return ret;            
        }

        public IShopfloorModule Shopfloor
        {
            get
            {
                return m_registry.Get<IShopfloorModule>();               
            }
            set
            {
                if(value != null)
                    m_registry.Register<IShopfloorModule>(value);
            }
        }

        public IWarehouseModule Warehouse
        {
            get
            {
                return m_registry.Get<IWarehouseModule>();

            }
            set
            {
                if (value != null)
                    m_registry.Register<IWarehouseModule>(value);
            }
        }

        public IOrderModule Orders
        {
            get
            {
                return m_registry.Get<IOrderModule>();
            }
        }

        public IClientModule Client
        {
            get
            {
                return m_registry.Get<IClientModule>();
            }
            set
            {
                if (value != null)
                    m_registry.Register<IClientModule>(value);
            }
        }     
    }
}