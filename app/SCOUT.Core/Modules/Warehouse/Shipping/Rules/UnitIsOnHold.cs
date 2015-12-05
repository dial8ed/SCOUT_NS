using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class UnitIsOnHold : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.Item.Hold != null)
            {
                var error = "Unit is on hold and cannot be shipped.";
                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return true;
            }

            return false;
        }
    }
}