using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_shipping_qtys_raw")]
    public class ShippingPartSummary : VPLiteObject
    {
        private Guid m_id;
        private SalesOrder m_salesOrder;
        private Order m_order;
        private Part m_part;
        private int m_qty;

        public ShippingPartSummary(Session session) : base(session)
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

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { m_part = value; }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { m_qty = value; }
        }
    }
}