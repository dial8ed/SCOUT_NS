using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class DomainIsShippable : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (!facts.Item.Domain.IsShippable)
            {
                var error = string.Format(
                    "This unit is in a non shippable domain ({0}) and cannot be processed.",
                    facts.Item.Domain);
                messageBuilder.AddMessage(error,UserMessageType.Validation);

                return true;
            }

            return false;
        }
    }
}