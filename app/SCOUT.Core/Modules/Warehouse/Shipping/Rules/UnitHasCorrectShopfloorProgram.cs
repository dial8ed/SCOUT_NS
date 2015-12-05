using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class UnitHasCorrectShopfloorProgram : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (string.IsNullOrEmpty(facts.SalesOrder.RequiredProgram))
                return true;

            if (facts.Item.ShopfloorProgram == null || !facts.Item.ShopfloorProgram.Equals(facts.SalesOrder.RequiredProgram))
            {
                var error = "Shipment Cancelled: This unit is not associated to the required program of "
                          + facts.SalesOrder.RequiredProgram;
                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return true;
            }

            return false; 
        }
    }
}