using System;
using SCOUT.Core.Data;
using SCOUT.Core.Services;


namespace SCOUT.Core.Modules
{
    public class WarehouseModule : ModuleBase, IWarehouseModule
    {        
        public WarehouseModule()
        {
            Services.Register<IShippingService>
                (new ShippingService(this));    
            
            Services.Register<ICaptureService>(
                new CaptureService(this));

            Services.Register<ITransactionService>(
                new TransactionService(this));

            Services.Register<IInventoryService>(
                new InventoryService(this));

            Services.Register<IAreaService>(
                new AreaService(this));

            Services.Register<IToteService>(
                new ToteService(this));

            Services.Register<IReceivingService>
                (new ReceivingService(this));

            Services.Register<IDfileService>
                (new DfileService(this));
        }

        public IShippingService Shipping
        {
            get { return Services.Get<IShippingService>(); }
            set
            {
                if(value != null)
                    Services.Register(value);
            }
        }

        public IReceivingService Receiving
        {
            get { throw new NotImplementedException(); }
        }

        public IInventoryService Inventory
        {
            get { return Services.Get<IInventoryService>(); }
            set
            {
                if (value != null)
                    Services.Register(value);
            }
        }

        public IAreaService Areas
        {
            get { return Services.Get<IAreaService>(); }
        }

        public ICaptureService Captures
        {
            get { return Services.Get<ICaptureService>(); }      
            set { 
                if(value != null)
                    Services.Register(value);
            }
        }

        public ITransactionService Transactions
        {
            get { return Services.Get<ITransactionService>(); }
            set { 
                    if (value != null)
                           Services.Register(value);            
            }
        }
    }
}