using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class UnitHasFinishedProcessing : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.Item.RoutingRequired && facts.Item.CurrentProcess != null)
            {
                var error = "Routing Required: This unit has not finished processing on its route and cannot be shipped.";
                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return false;
            }

            return true; 
        }
    }
}
