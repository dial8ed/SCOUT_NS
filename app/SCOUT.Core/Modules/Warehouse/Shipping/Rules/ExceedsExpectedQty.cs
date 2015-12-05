using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class ExceedsExpectedQty : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.SalesOrder.ExpectedQtyForPart(facts.Item.Part.Id) < facts.ShipQty)
            {
                var error =
                string.Format(
                      "Shipping {0} units of part number {1} will exceed the qty expected.",
                      facts.ShipQty, facts.Item.PartNumber);

                messageBuilder.AddMessage(error, UserMessageType.Validation);

                return true;  
            }

            return false;
        }
    }
}