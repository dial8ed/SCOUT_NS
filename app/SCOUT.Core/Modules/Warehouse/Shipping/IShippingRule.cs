using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public interface IShippingRule
    {
        bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder);
    }
}