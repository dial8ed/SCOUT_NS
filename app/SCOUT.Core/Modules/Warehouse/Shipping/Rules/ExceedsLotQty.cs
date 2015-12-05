using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class ExceedsLotQty : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.ShipQty > facts.Item.Qty)
            {
                var error = string.Format("{0} exceeds the available quantity for this lot.", facts.ShipQty);
                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return true;
            }
            return false;
        }
    }
}