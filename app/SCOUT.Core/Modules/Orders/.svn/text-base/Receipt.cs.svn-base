using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("receipts")]
    public class Receipt : VPLiteObject
    {
        private string m_comments;
        private string m_condition = "";
        private ItemCustomFields m_customFields;
        private ProductGrade m_grade;
        private int m_id;
        private InventoryItem m_item;
        private DateTime m_lastUpdate;
        private Part m_part;
        private int m_partId;
        private string m_partNumber;
        private PurchaseOrder m_PurchaseOrder;
        private int m_qty;
        private DateTime m_receiveDate;
        private string m_receivedBy;
        private Tote m_receivingTote;
        private bool m_routingRequired;
        private string m_serialNumber = "";
        private string m_unitTrackingId;
        private string m_updatedBy;
        private PurchaseLineItem m_lineItem;
        private string m_warnings;
        private string m_program;
        private string m_lineItemIdentifier;

        public Receipt(Session session) : base(session)
        {
            m_receivedBy = Security.UserSecurity.CurrentUser.Login;
        }

        [Key(AutoGenerate = true)]
        [Persistent("id")]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("unit_tracking_id")]
        [Indexed(Unique = true, Name = "uq_receipts_lotid")]
        public string UnitTrackingId
        {
            get { return m_unitTrackingId; }
            set { SetPropertyValue("UnitTrackingId", ref m_unitTrackingId, value); }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [NonPersistent]
        public string PartNumber
        {
            get { return m_part == null ? m_partNumber : m_part.PartNumber; }
            set { m_partNumber = value; }
        }

        [Persistent("quantity")]
        public int Qty
        {
            get { return m_qty; }
            set { SetPropertyValue("Qty", ref m_qty, value); }
        }

        [Persistent("condition")]
        public string Condition
        {
            get { return m_condition; }
            set { SetPropertyValue("Condition", ref m_condition, value); }
        }

        [Persistent("comments")]
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }

        [Persistent("receive_date")]
        public DateTime ReceiveDate
        {
            get { return m_receiveDate; }
            set { SetPropertyValue("ReceiveDate", ref m_receiveDate, value); }
        }

        [Persistent("received_by")]
        public string ReceivedBy
        {
            get { return m_receivedBy; }
            set { SetPropertyValue("ReceivedBy", ref m_receivedBy, value); }
        }

        [Persistent("last_update")]
        public DateTime LastUpdate
        {
            get { return m_lastUpdate; }
            set { SetPropertyValue("LastUpdate", ref m_lastUpdate, value); }
        }

        [Persistent("updated_by")]
        public string UpdatedBy
        {
            get { return m_updatedBy; }
            set { SetPropertyValue("UpdatedBy", ref m_updatedBy, value); }
        }

        [Persistent("order_id")]
        [Association("PurchaseOrder-Receipts")]
        public PurchaseOrder PurchaseOrder
        {
            get { return m_PurchaseOrder; }
            set { SetPropertyValue("PurchaseOrder", ref m_PurchaseOrder, value); }
        }

        [Persistent("receipt_tote_id")]
        public Tote ReceivingCart
        {
            get { return m_receivingTote; }
            set { SetPropertyValue("ReceivingCart", ref m_receivingTote, value); }
        }

        [NonPersistent]
        public ProductGrade Grade
        {
            get { return m_grade; }
            set { m_grade = value; }
        }

        [Persistent("lotid")]
        [Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("InventoryItem", ref m_item, value); }
        }

        [Persistent("serial_number")]
        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { SetPropertyValue("SerialNumber", ref m_serialNumber, value); }
        }

        [Persistent("routing_required")]
        public bool RoutingRequired
        {
            get { return m_routingRequired; }
            set { SetPropertyValue("RoutingRequired", ref m_routingRequired, value); }
        }

        [Persistent("line_item_id")]
        public PurchaseLineItem PurchaseLineItem
        {
            get { return m_lineItem; }
            set { SetPropertyValue("PurchaseLineItem", ref m_lineItem, value); }
        }

        [NonPersistent]
        public ItemCustomFields CustomFields
        {
            get { return m_customFields; }
            set { SetPropertyValue("CustomFields", ref m_customFields, value); }
        }

        [Persistent("warnings")]
        public string Warnings
        {
            get { return m_warnings; }
            set { SetPropertyValue("Warnings", ref m_warnings, value); }
        }

        [Persistent("program")]
        public string Program
        {
            get { return m_program; }
            set { SetPropertyValue("Program", ref m_program, value); }
        }

        [Persistent("line_item_identifier")]
        public string LineItemIdentifier
        {
            get { return m_lineItemIdentifier; }
            set { SetPropertyValue("LineItemIdentifier", ref m_lineItemIdentifier, value); }
        }

    }
}