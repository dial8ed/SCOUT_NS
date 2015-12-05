using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class PartIsExpected : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.SalesOrder.ExpectedQtyForPart(facts.Item.Part.Id) <= 0)
            {
                var error = 
                    string.Format("Part number {0} is not expected on this order.", facts.Item.PartNumber);
                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return true;
            }

            return false;            
        }
    }
}