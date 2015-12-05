using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class ShipmentValidator : ValidatorBase
    {
        private readonly InventoryItem m_item;
        private readonly SalesOrder m_salesOrder;
        private readonly int m_shipQty;

        public ShipmentValidator(MessageListener listener) : base(listener)
        {
        }

 
        public ShipmentValidator(SalesOrder salesOrder, InventoryItem item, int shipQty)
        {
            m_shipQty = shipQty;
            m_salesOrder = salesOrder;
            m_item = item;
        }

        public ShipmentValidator(ShipmentFacts facts)
        {
            m_shipQty = facts.ShipQty;
            m_salesOrder = facts.SalesOrder;
            m_item = facts.Item;            
        }

        public override void GetError()
        {
            m_error = "";

            SalesLineItem lineItem = ShipmentIsAssociatedToLineItem();

            if (lineItem == null) return;
            if (!LineItemIsShippable(lineItem)) return;
            if (!PartIsExpected()) return;
            if (UnitIsOnHold()) return;
            if (ExceedsLotQty()) return;
            if (ExceedsExpectedQty()) return;
            if (!DomainIsShippable()) return;
            if (!UnitIsIntheCorrectShippingDomain()) return;
            if (!UnitHasFinishedProcessing()) return;
            if (!UnitCompletedRequiredServiceRoute()) return;
            if (!UnitHasCorrectShopfloorProgram()) return;
            if (!UnitIsOnCorrectShopfloorline()) return;
        }

        private bool UnitIsOnCorrectShopfloorline()
        {
            if(m_salesOrder.Shopfloorline == null)
                return true;

            if(m_item.Shopfloorline.Id != m_salesOrder.Shopfloorline.Id)
            {
                m_error = "Shipment Cancelled: This unit is not on the " + m_salesOrder.Shopfloorline +
                          " shopfloorline.";
                return false;
            }

            return true;
        }

        private bool UnitHasCorrectShopfloorProgram()
        {
            if (string.IsNullOrEmpty(m_salesOrder.RequiredProgram))
                return true;

            if(m_item.ShopfloorProgram == null || !m_item.ShopfloorProgram.Equals(m_salesOrder.RequiredProgram))
            {
                m_error = "Shipment Cancelled: This unit is not associated to the required program of "
                          + m_salesOrder.RequiredProgram;
                return false;
            }

            return true;
        }

        private SalesLineItem ShipmentIsAssociatedToLineItem()
        {
            SalesLineItem lineItem;
            lineItem = m_salesOrder.GetLineByPart(m_item.Part);

            if (lineItem == null)
            {
                m_error = "No sales order line item found for this part";
                return null;
            }

            return lineItem;
        }

        private bool LineItemIsShippable(SalesLineItem lineItem)
        {
            var lineValidator = new SalesLineItemShipmentValidator(lineItem);
            if (!lineValidator.Validated())
            {
                m_error = "Line item is not shippable";
                return false;
            }

            return true;
        }

        private bool PartIsExpected()
        {
            if (m_salesOrder.ExpectedQtyForPart(m_item.Part.Id) <= 0)
            {
                m_error = string.Format("Part number {0} is not expected on this order.", m_item.PartNumber);
                return false;
            }

            return true;
        }

        private bool ExceedsExpectedQty()
        {
            if (m_salesOrder.ExpectedQtyForPart(m_item.Part.Id) < m_shipQty)
            {
                m_error = string.Format(
                    "Shipping {0} units of part number {1} will exceed the qty expected.",
                    m_shipQty, m_item.PartNumber);

                return true;
            }

            return false;
        }

        private bool ExceedsLotQty()
        {
            if (m_shipQty > m_item.Qty)
            {
                m_error = string.Format("{0} exceeds the available quantity for this lot.", m_shipQty);
                return true;
            }
            return false;
        }

        private bool DomainIsShippable()
        {
            if (!m_item.Domain.IsShippable)
            {
                m_error = string.Format(
                    "This unit is in a non shippable domain ({0}) and cannot be processed.",
                    m_item.Domain);
                return false;
            }

            return true;
        }

        private bool UnitIsIntheCorrectShippingDomain()
        {
            if (m_salesOrder.ShipmentDomainStatus != null &
                !m_item.Domain.Status.Equals(m_salesOrder.ShipmentDomainStatus))
            {
                m_error = string.Format("Incorrect domain status. This unit needs to be in a [{0}] domain",
                                        m_salesOrder.ShipmentDomainStatus);
                return false;
            }

            return true;
        }

        private bool UnitCompletedRequiredServiceRoute()
        {
            ServiceRoute requiredRoute =
                m_salesOrder.RequiredServiceRoute;

            if (requiredRoute == null)
                return true;

            ServiceRouteDisposition disposition =  
                Scout.Core.Service<IShopfloorService>()
                    .GetRouteDisposition(m_item, requiredRoute);
                            
           if (disposition == null)
            {
                m_error = string.Format("Shipment Cancelled: This unit did not complete the {0} route",
                                        requiredRoute.Name);
                                        
                return false;
            }

            return true;
        }

        private bool UnitIsOnHold()
        {
            if (m_item.Hold != null)
            {
                m_error = "Unit is on hold and cannot be shipped.";
                return true;
            }

            return false;
        }

        private bool UnitHasFinishedProcessing()
        {
            if (m_item.RoutingRequired && m_item.CurrentProcess != null)
            {
                m_error = "Routing Required: This unit has not finished processing on its route and cannot be shipped.";
                return false;
            }

            return true;
        }
    }
}