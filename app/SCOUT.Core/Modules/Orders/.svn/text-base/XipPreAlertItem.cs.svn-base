using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("xip_prealert_items")]
    public class XipPreAlertItem : VPObject, IPreAlertItem
    {
        private int m_id;
        private string m_lotid;
        private string m_dpsNumber;
        private string m_ppid;
        private string m_partNumber;
        private string m_oem;
        private string m_serviceTag;
        private string m_licensePlate;
        private string m_orderNumber;
        private string m_orderDate;
        private string m_orderTime;
        private string m_dateShipped;
        private string m_timeShipped;
        private string m_shipCode;
        private string m_shippedBy;
        private string m_fromStockRoom;
        private string m_shipmentType;
        private string m_shippedTo;
        private string m_packslip;
        private string m_waybill;
        private string m_custrtn_wbn;
        private string m_shipmentReferenceNumber;
        private string m_rma;
        private string m_unitCost;
        private string m_F9Comments;
        private string m_ioc;
        private string m_description;
        private PurchaseOrder m_purchaseOrder;

        public XipPreAlertItem(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("lotid")]        
        public string LotId
        {
            get { return m_lotid; }
            set { SetPropertyValue("LotId", ref m_lotid, value); }
        }

        [Persistent("dps")]
        [NullValue("")]
        public string DpsNumber
        {
            get { return m_dpsNumber; }
            set { m_dpsNumber = value; }
        }

        [Persistent("ppid")]
        [NullValue("")]
        public string PPID
        {
            get { return m_ppid; }
            set { m_ppid = value; }
        }

        [Persistent("oem")]
        [NullValue("")]
        public string OEM
        {
            get { return m_oem; }
            set { m_oem = value; }
        }

        [Persistent("license_plate")]
        [NullValue("")]
        public string LicensePlate
        {
            get { return m_licensePlate; }
            set { m_licensePlate = value; }
        }

        [Persistent("order_number")]
        [NullValue("")]
        public string OrderNumber
        {
            get { return m_orderNumber; }
            set { m_orderNumber = value; }
        }

        [Persistent("order_date")]        
        public string OrderDate
        {
            get { return m_orderDate; }
            set { m_orderDate = value; }
        }

        [Persistent("order_time")]
        public string OrderTime
        {
            get { return m_orderTime; }
            set { m_orderTime = value; }
        }

        [Persistent("date_shipped")]
        public string DateShipped
        {
            get { return m_dateShipped; }
            set { m_dateShipped = value; }
        }

        [Persistent("time_shipped")]
        public string TimeShipped
        {
            get { return m_timeShipped; }
            set { m_timeShipped = value; }
        }

        [Persistent("ship_code")]
        [NullValue("")]
        public string ShipCode
        {
            get { return m_shipCode; }
            set { m_shipCode = value; }
        }

        [Persistent("shipped_by")]
        [NullValue("")]
        public string ShippedBy
        {
            get { return m_shippedBy; }
            set { m_shippedBy = value; }
        }

        [Persistent("from_stock_room")]
        [NullValue("")]
        public string FromStockRoom
        {
            get { return m_fromStockRoom; }
            set { m_fromStockRoom = value; }
        }

        [Persistent("shipment_type")]
        [NullValue("")]
        public string ShipmentType
        {
            get { return m_shipmentType; }
            set { m_shipmentType = value; }
        }

        [Persistent("shipped_to")]
        [NullValue("")]
        public string ShippedTo
        {
            get { return m_shippedTo; }
            set { m_shippedTo = value; }
        }

        [Persistent("packslip")]
        [NullValue("")]
        public string Packslip
        {
            get { return m_packslip; }
            set { m_packslip = value; }
        }

        [Persistent("waybill")]
        [NullValue("")]
        public string Waybill
        {
            get { return m_waybill; }
            set { m_waybill = value; }
        }

        [Persistent("cust_rtn_wbn")]
        [NullValue("")]
        public string CustrtnWbn
        {
            get { return m_custrtn_wbn; }
            set { m_custrtn_wbn = value; }
        }

        [Persistent("shipment_reference_number")]
        [NullValue("")]
        public string ShipmentReferenceNumber
        {
            get { return m_shipmentReferenceNumber; }
            set { m_shipmentReferenceNumber = value; }
        }

        [Persistent("rma")]
        [NullValue("")]
        public string RMA
        {
            get { return m_rma; }
            set { m_rma = value; }
        }

        [Persistent("unit_cost")]
        [NullValue("")]
        public string UnitCost
        {
            get { return m_unitCost; }
            set { m_unitCost = value; }
        }

        [Persistent("f9_comments")]
        [NullValue("")]
        [Size(SizeAttribute.Unlimited)]
        public string F9Comments
        {
            get { return m_F9Comments; }
            set { m_F9Comments = value; }
        }

        [Persistent("ioc")]
        [NullValue("")]
        public string Ioc
        {
            get { return m_ioc; }
            set { m_ioc = value; }
        }

        [Persistent("description")]
        [NullValue("")]
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
         
        }

        [Persistent("part_number")]
        [NullValue("")]
        public string PartNumber
        {
            get { return m_partNumber; }
            set { m_partNumber = value;}
        }

        [Persistent("serial_number")]
        [NullValue("")]
        public string SerialNumber
        {
            get { return m_serviceTag; }
            set { m_serviceTag = value;}
        }

        [Persistent("purchase_order_id")]        
        public PurchaseOrder PurchaseOrder
        {
            get { return m_purchaseOrder; }
            set { m_purchaseOrder = value;}
        }
    }
}