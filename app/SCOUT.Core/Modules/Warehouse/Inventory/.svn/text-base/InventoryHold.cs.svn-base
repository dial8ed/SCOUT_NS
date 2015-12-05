using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a inventory hold in the data store
    /// </summary>
    [Persistent("inventory_holds")]
    public class InventoryHold : VPObject
    {
        private Guid m_oldId;
        private int m_id;
        private HoldStatus m_status = HoldStatus.Open;
        private InventoryItem m_item;
        private string m_resolution;
        private DateTime m_resolutionDate;
        private bool m_allowStationData;
        private string m_reason;
        private string m_multipleCaptureIds;
        private InventoryCapture m_capture = null;
        private HoldReleaseAction m_releaseAction =  HoldReleaseAction.Release;

        public InventoryHold(Session session) : base(session)
        {
            
        }

        public InventoryHold(InventoryItem item, string reason) : base(item.Session as XpoUnitOfWork)
        {
            m_oldId = Guid.NewGuid();
            m_reason = reason;
            m_item = item;
            m_item.Hold = this;
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id;}
            set { SetPropertyValue("Id", ref m_id, value); }
        }
  
        [Persistent("status_id")]
        public HoldStatus Status
        {
            get { return m_status; }
            set { SetPropertyValue("Status", ref m_status, value);} 
        }

        [Persistent("lotid")]
        [Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }

        [Persistent("resolution")]
        public string Resolution
        {
            get { return m_resolution; }
            set { SetPropertyValue("Resolution", ref m_resolution, value); }
        }

        [Persistent("resolution_date")]
        public DateTime ResolutionDate
        {
            get { return m_resolutionDate; }
            set { SetPropertyValue("ResolutionDate", ref m_resolutionDate, value); }
        }

        [Persistent("allow_station_data")]
        public bool AllowStationData
        {
            get { return m_allowStationData; }
            set { SetPropertyValue("AllowStationData", ref m_allowStationData, value); }
        }

        [Persistent("reason")]
        public string Reason
        {
            get { return m_reason; }
            set { SetPropertyValue("Reason", ref m_reason, value); }
        }

        [Persistent("capture_id")]
        public InventoryCapture Capture
        {
            get { return m_capture; }
            set { SetPropertyValue("Capture",ref m_capture, value); }
        }

        [Persistent("multiple_capture_ids")]
        public string MultipleCaptureIds
        {
            get { return m_multipleCaptureIds; }
            set { SetPropertyValue("MultipleCaptureIds", ref m_multipleCaptureIds, value); }
        }


        [Persistent("release_action")]
        public HoldReleaseAction ReleaseAction
        {
            get { return m_releaseAction; }
            set { SetPropertyValue("ReleaseAction", ref m_releaseAction, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}