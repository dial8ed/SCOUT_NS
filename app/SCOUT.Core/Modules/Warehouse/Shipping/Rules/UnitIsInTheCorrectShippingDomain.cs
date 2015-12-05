using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data.Rules
{
    public class UnitIsInTheCorrectShippingDomain : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            if (facts.SalesOrder.ShipmentDomainStatus != null &
                 !facts.Item.Domain.Status.Equals(facts.SalesOrder.ShipmentDomainStatus))
            {
                var error = string.Format("Incorrect domain status. This unit needs to be in a [{0}] domain",
                                        facts.SalesOrder.ShipmentDomainStatus);
                messageBuilder.AddMessage(error, UserMessageType.Validation);
                return true;
            }

            return false;
        }
    }
}