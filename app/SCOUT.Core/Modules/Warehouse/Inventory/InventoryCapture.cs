using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a inventory capture in the data store.
    /// </summary>
    [Persistent("inventory_captures")]
    public class InventoryCapture : VPObject
    {
        private int m_id;        
        private Shopfloorline m_shopfloorline;
        private bool m_active = true;
        private string m_description;
        private string m_message;
        private bool m_hold;
        private string m_criteria;
        private Domain m_holdDomain;
        private RouteStation m_holdStation;
        private RouteStation m_releaseStation;
        private bool m_allowStationData;
        private CapturePriority m_priority = CapturePriority.Normal;
        private string m_type = "";
        private string m_applyCondition = "";

        public InventoryCapture(Session session) : base(session)
        {            
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }


        [Persistent("shopfloorline_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline", ref m_shopfloorline, value); }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return m_active; }
            set { SetPropertyValue("Active", ref m_active, value); }
        }

        [Persistent("description")]
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("message")]
        [Size(SizeAttribute.Unlimited)]
        public string Message
        {
            get { return m_message; }
            set { SetPropertyValue("Message", ref m_message, value); }
        }

        [Persistent("hold")]
        public bool Hold
        {
            get { return m_hold; }
            set { SetPropertyValue("Hold", ref m_hold, value); }
        }

        [Persistent("criteria")]
        [Size(SizeAttribute.Unlimited)]
        public string Criteria
        {
            get { return m_criteria; }
            set { SetPropertyValue("Criteria", ref m_criteria, value); }
        }

        [Persistent("hold_domain_id")]
        public Domain HoldDomain
        {
            get { return m_holdDomain; }
            set { SetPropertyValue("HoldDomain",ref m_holdDomain, value); }
        }

        [Persistent("hold_station_id")]
        public RouteStation HoldStation
        {
            get { return m_holdStation; }
            set { SetPropertyValue("HoldStation", ref m_holdStation, value); }
        }

        [Persistent("release_station_id")]
        public RouteStation ReleaseStation
        {
            get { return m_releaseStation; }
            set { SetPropertyValue("ReleaseStation", ref m_releaseStation, value); }
        }

        [Persistent("allow_station_data")]
        public bool AllowStationData
        {
            get { return m_allowStationData; }
            set { SetPropertyValue("AllowStationData", ref m_allowStationData, value); }
        }

        [Persistent("priority")]
        public CapturePriority Priority
        {
            get { return m_priority; }
            set { SetPropertyValue("Priority", ref m_priority, value); }
        }

        [Persistent("type")]
        public string Type
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }

        [Persistent("apply_condition")]
        public string ApplyCondition
        {
            get { return m_applyCondition; }
            set { SetPropertyValue("ApplyCondition", ref m_applyCondition, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            //throw new NotImplementedException();
        }
    }
}