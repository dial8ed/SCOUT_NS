using SCOUT.Core.Services;

namespace SCOUT.Core.Modules
{
    public interface IShopfloorModule : IModule
    {
        IShopfloorService Routes { get; }               
    }
}