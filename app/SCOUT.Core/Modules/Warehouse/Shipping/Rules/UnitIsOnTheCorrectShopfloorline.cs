using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class UnitIsOnTheCorrectShopfloorline : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.SalesOrder.Shopfloorline == null)
                return true;

            if (facts.Item.Shopfloorline.Id != facts.SalesOrder.Shopfloorline.Id)
            {
                var error = "Shipment Cancelled: This unit is not on the " + facts.SalesOrder.Shopfloorline +
                          " shopfloorline.";
                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return true;
            }

            return false;
        }
    }
}