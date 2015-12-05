using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_shipment_deltas")]
    public class ShipmentDelta : VPLiteObject
    {
        private Guid m_id;
        private int m_partId;
        private string m_partNumber;
        private string m_description;
        private int m_shipped;
        private int m_expected;
        private int m_onHand;
        private int m_orderQty;

        private SalesOrder m_salesOrder;

        public ShipmentDelta(Session session)
            : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("part_id")]
        public int PartId
        {
            get { return m_partId; }
            set { SetPropertyValue("PartId", ref m_partId, value); }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return m_partNumber; }
            set { SetPropertyValue("PartNumber", ref m_partNumber, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("shipped")]
        public int Shipped
        {
            get { return m_shipped; }
            set { SetPropertyValue("Received", ref m_shipped, value); }
        }

        [Persistent("expected")]
        public int Expected
        {
            get { return m_expected; }
            set { SetPropertyValue("Expected", ref m_expected, value); }
        }

        [Association("SalesOrder-ShipmentDeltas")]
        [Persistent("order_id")]
        public SalesOrder SalesOrder
        {
            get { return m_salesOrder; }
            set { SetPropertyValue("SalesOrder", ref m_salesOrder, value); }
        }

        [Persistent("on_hand")]
        public int OnHand
        {
            get { return m_onHand; }
            set { SetPropertyValue("OnHand", ref m_onHand, value); }
        }

        [Persistent("order_qty")]
        public int OrderQty
        {
            get { return m_orderQty; }
            set { SetPropertyValue("OrderQty", ref m_orderQty, value); }
        }
    }
}