using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_receipt_deltas")]
    public class ReceiptDelta : VPLiteObject
    {
        private Guid m_id;
        private int m_partId;
        private string m_partNumber;
        private string m_description;
        private int m_received;
        private int m_expected;
        private int m_sent;
        private PurchaseOrder m_purchaseOrder;

        public ReceiptDelta(Session session) : base(session)
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

        [Persistent("received")]
        public int Received
        {
            get { return m_received; }
            set { SetPropertyValue("Received", ref m_received, value); }
        }

        [Persistent("expected")]
        public int Expected
        {
            get { return m_expected; }
            set { SetPropertyValue("Expected", ref m_expected, value); }
        }

        [Persistent("sent")]
        public int Sent
        {
            get { return m_sent; }
            set { SetPropertyValue("Sent", ref m_sent, value); }
        }

        [Association("PurchaseOrder-ReceiptDeltas")]
        [Persistent("order_id")]
        public PurchaseOrder PurchaseOrder
        {
            get { return m_purchaseOrder;  }
            set { SetPropertyValue("PurchaseOrder", ref m_purchaseOrder, value); }
        }
    }
}