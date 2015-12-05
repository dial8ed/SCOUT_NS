using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("dell_prealert_items")]
    public class DellPreAlertItem : VPObject, IPreAlertItem
    {
        private Guid m_id;
        private string m_lotId;
        private string m_raNumber;
        private string m_rtvNumber;
        private string m_poNumber;
        private string m_scnLP;
        private string m_ppid;
        private string m_cartonId;
        private string m_dpsNumber;
        private string m_partNumber;
        private string m_serialNumber;
        private string m_reasonCode;
        private int m_cost;
        private string m_problemDes;
        private DateTime m_scanTime;
        private PurchaseOrder m_purchaseOrder;
        
        public DellPreAlertItem(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());            
        }

        [Key(AutoGenerate = true)]
        [Persistent("id")]  
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("id", ref m_id, value); }
        }

        [Persistent("ra_number")]
        public string RaNumber
        {
            get { return m_raNumber; }
            set { m_raNumber = value; }
        }

        [Persistent("rtv_number")]
        public string RtvNumber
        {
            get { return m_rtvNumber; }
            set { m_rtvNumber = value; }
        }

        [Persistent("po_number")]
        public string PoNumber
        {
            get { return m_poNumber; }
            set { m_poNumber = value; }
        }

        [Persistent("scn_lp")]
        public string ScnLp
        {
            get { return m_scnLP; }
            set { m_scnLP = value; }
        }

        [Persistent("ppid")]
        public string PPID
        {
            get { return m_ppid; }
            set { m_ppid = value; }
        }

        [Persistent("carton_id")]
        public string CartonId
        {
            get { return m_cartonId; }
            set { m_cartonId = value; }
        }

        [Persistent("dps_number")]
        public string DpsNumber
        {
            get { return m_dpsNumber; }
            set { m_dpsNumber = value; }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return m_partNumber; }
            set { m_partNumber = value; }
        }

        [Persistent("serial_number")]
        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { m_serialNumber = value; }
        }

        [Persistent("reason_code")]
        public string ReasonCode
        {
            get { return m_reasonCode; }
            set { m_reasonCode = value; }
        }

        [Persistent("cost")]
        public int Cost
        {
            get { return m_cost; }
            set { m_cost = value; }
        }

        [Persistent("problem_des")]
        public string ProblemDes
        {
            get { return m_problemDes; }
            set { m_problemDes = value; }
        }

        [Persistent("scan_time")]
        public DateTime ScanTime
        {
            get { return m_scanTime; }
            set { m_scanTime = value; }
        }

        [Persistent("lotid")]
        public string LotId
        {
            get { return m_lotId; }
            set { SetPropertyValue("LotId", ref m_lotId, value); }
        }

        [Persistent("purchase_order_id")]       
        public PurchaseOrder PurchaseOrder
        {
            get { return m_purchaseOrder; }
            set { m_purchaseOrder = value; }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}