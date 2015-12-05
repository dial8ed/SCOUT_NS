using SCOUT.Core.Services;

namespace SCOUT.Core.Modules
{
    public class ShopfloorModule :  ModuleBase, IShopfloorModule
    {
        public ShopfloorModule()
        {
            Services.Register<IShopfloorService>
                (new ShopfloorService(this));
        }

        public IShopfloorService Routes
        {
            get
            {
                return Services.Get<IShopfloorService>();
            }

            set
            {
                if(value != null)
                    Services.Register<IShopfloorService>(value);
            }
        }
    }
}