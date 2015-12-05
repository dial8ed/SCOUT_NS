using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("shipments")]
    public class Shipment : VPLiteObject
    {
        private int m_id;
        private int m_qty;
        private string m_packlistId;
        private DateTime m_shipDate;
        private string m_shippedBy;
        private DateTime m_cancelDate;
        private string m_cancelledBy;
        private int m_itemId;
        private SalesOrder m_salesOrder;
        private int m_partId;
        private Part m_part;
        private Packlist m_packlist;
        private SerializedUnit m_serializedUnit;
        private Domain m_departureDomain;
        private InventoryItem m_item;
        private SalesLineItem m_lineItem;
        private string m_program;
        private string m_lineItemIdentifier;

        public Shipment(Session session) : base(session)
        {
            m_shippedBy = Security.UserSecurity.CurrentUser.Login;
            m_shipDate = DateTime.Now;
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("sales_order_id")]
        [Association("SalesOrder-Shipments")]
        public SalesOrder SalesOrder
        {
            get { return m_salesOrder; }
            set { SetPropertyValue("SalesOrder", ref m_salesOrder, value); }
        }

        [Persistent("lotid")]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("LotId", ref m_item, value); }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { SetPropertyValue("Qty", ref m_qty, value); }
        }

        public string PacklistId
        {
            get { return (m_packlist != null ? m_packlist.PacklistId : ""); }
        }

        [Persistent("ship_date")]
        public DateTime ShipDate
        {
            get { return m_shipDate; }
            set { SetPropertyValue("ShipDate", ref m_shipDate, value); }
        }

        [Persistent("shipped_by")]
        public string ShippedBy
        {
            get { return m_shippedBy; }
            set { SetPropertyValue("ShippedBy", ref m_shippedBy, value); }
        }

        [Persistent("cancel_date")]
        public DateTime CancelDate
        {
            get { return m_cancelDate; }
            set { SetPropertyValue("CancelDate", ref m_cancelDate, value); }
        }

        [Persistent("cancelled_by")]
        public string CancelledBy
        {
            get { return m_cancelledBy; }
            set { SetPropertyValue("CancelledBy", ref m_cancelledBy, value); }
        }

        [Persistent("item_id")]
        public int ItemId
        {
            get { return m_itemId; }
            set { SetPropertyValue("ItemId", ref m_itemId, value); }
        }


        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("packlist_id")]
        [Association("Packlist-Shipments")]
        public Packlist Packlist
        {
            get { return m_packlist; }
            set { SetPropertyValue("Packlist", ref m_packlist, value); }
        }

        [Persistent("line_item_id")]
        public SalesLineItem LineItem
        {
            get { return m_lineItem; }
            set { SetPropertyValue("LineItem", ref m_lineItem, value); }
        }

        [Persistent("program")]
        public string Program
        {
            get { return m_program; }
            set { SetPropertyValue("Program", ref m_program, value); }
        }

        [NonPersistent]
        public string PartNumber
        {
            get { return (m_part != null ? m_part.PartNumber : ""); }
        }

        [NonPersistent]
        public string PartDescription
        {
            get { return (m_part != null ? m_part.Description : ""); }
        }

        [NonPersistent]
        public string SerialNumber
        {
            get
            {
                if (m_item.SerializedUnit == null)
                    return "NON-SERIALIZED";

                return m_item.SerializedUnit.InitIdent;
            }
        }

        [NonPersistent]
        public Domain DepartureDomain
        {
            get { return m_departureDomain; }
            set { m_departureDomain = value; }
        }

        [Persistent("line_item_identifier")]
        public string LineItemIdentifier
        {
            get { return m_lineItemIdentifier; }
            set { SetPropertyValue("LineItemIdentifier", ref m_lineItemIdentifier, value); }
        }
    }
}