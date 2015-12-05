using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class LineItemIsShippable : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            var lineItem = facts.SalesOrder.GetLineByPart(facts.Item.Part);
            if (lineItem == null)
            {
                messageBuilder.AddMessage("No sales order line item found for this part", UserMessageType.Validation);
                return true;
            }

            if (lineItem.Status != LineItemStatus.Open)
            {
               messageBuilder.AddMessage("This line item is not open and cannot be shipped against.",UserMessageType.Validation);
               return true;
            }
         
            return false;
        }
    }
}