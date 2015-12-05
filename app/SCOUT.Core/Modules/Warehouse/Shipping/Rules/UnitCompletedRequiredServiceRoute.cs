using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data.Rules
{
    public class UnitCompletedRequiredServiceRoute : IShippingRule
    {
        public bool IsBroken(ShipmentFacts facts, IUserMessageBuilder messageBuilder)
        {
            ServiceRoute requiredRoute =
               facts.SalesOrder.RequiredServiceRoute;

            if (requiredRoute == null)
                return false;

            ServiceRouteDisposition disposition =
                Scout.Core.Service<IShopfloorService>()
                    .GetRouteDisposition(facts.Item, requiredRoute);

            if (disposition == null)
            {
                var error = string.Format("Shipment Cancelled: This unit did not complete the {0} route",
                                        requiredRoute.Name);

                messageBuilder.AddMessage(error,UserMessageType.Validation);
                return true;
            }

            return false;

        }
    }
}