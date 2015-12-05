using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_shipping_qtys_by_line")]
    public class ShippingLineSummary : VPLiteObject
    {
        private Guid m_id;
        private SalesLineItem m_lineItem;
        private Order m_order;
        private int m_qty;
        private SalesOrder m_salesOrder;

        public ShippingLineSummary(Session session)
            : base(session)
        {
        }

        [Key(AutoGenerate = false)]
        [Persistent("id")]
        public Guid Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("contract_id")]
        public SalesOrder SalesOrder
        {
            get { return m_salesOrder; }
            set { m_salesOrder = value; }
        }

        [Persistent("order_id")]
        public Order Order
        {
            get { return m_order; }
            set { m_order = value; }
        }

        [Persistent("line_item_id")]
        public SalesLineItem LineItem
        {
            get { return m_lineItem; }
            set { m_lineItem = value; }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { m_qty = value; }
        }
    }
}