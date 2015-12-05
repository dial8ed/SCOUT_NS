using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{    
    [Persistent("sales_packlists")]    
    public partial class Packlist : VPLiteObject
    {
        private int m_id;
        private string m_packlistId;
        private DateTime m_shipDate;
        private SalesOrder m_salesOrder;
        private string m_waybill;
        private string m_xipControlNumber;
        private string m_shipToAddress;
        private ShippingConfiguration m_shippingConfiguration;
        private DateTime m_printDate;

        public Packlist(Session session) : base(session)
        {
 
        }

        [Persistent("packlist_id")]
        public string PacklistId
        {
            get { return m_packlistId; }
            set { SetPropertyValue("PacklistId", ref m_packlistId , value); }
        }

        [Persistent("ship_date")]
        public DateTime ShipDate
        {
            get { return m_shipDate; }
            set { SetPropertyValue("ShipDate", ref m_shipDate, value); }
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("sales_order_id")]
        [Association("SalesOrder-Packlists")]
        public SalesOrder SalesOrder
        {
            get { return m_salesOrder; }
            set { SetPropertyValue("SalesOrder", ref m_salesOrder, value); }
        }

        [Persistent("waybill")]
        public string Waybill
        {
            get { return m_waybill; }
            set { SetPropertyValue("Waybill", ref m_waybill, value);}
        }

        [Persistent("xip_control_number")]
        public string XipControlNumber
        {
            get { return m_xipControlNumber; }
            set { SetPropertyValue("XipControlNumber", ref m_xipControlNumber, value); }
        }

        [Persistent("ship_to_address")]
        public string ShipToAddress
        {
            get { return m_shipToAddress; }
            set { SetPropertyValue("ShipToAddress", ref m_shipToAddress, value); }
        }

        [Persistent("print_date")]
        public DateTime PrintDate
        {
            get { return m_printDate; }
            set { SetPropertyValue("PrintDate", ref m_printDate, value); }
        }

        [Association("Packlist-Shipments")]
        public XPCollection<Shipment> Shipments
        {
            get { return GetCollection<Shipment>("Shipments"); }
        }

        [Persistent("shipping_configuration_id")]
        public ShippingConfiguration ShippingConfiguration
        {
            get { return m_shippingConfiguration; }
            set
            {
                SetPropertyValue("ShippingConfiguration", ref m_shippingConfiguration, value);
            }
        }       
    }

    public partial class Packlist
    {
        [NonPersistent]
        public bool IsClosed
        {
            get
            {
                int rval = DateTime.Compare(ShipDate.Date, DateTime.Now.Date);
                return rval != 0;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            Shipments.Add(shipment);
            shipment.Packlist = this;
            return true;
        }

        public bool RemoveShipment(Shipment shipment)
        {
            return Shipments.Remove(shipment);
        }
    }
}