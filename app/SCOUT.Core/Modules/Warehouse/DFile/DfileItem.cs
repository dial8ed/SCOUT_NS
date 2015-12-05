using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public enum DfileStatus
    {
        Open = 1,
        Resolved = 2,
        Closed = 0
    }

    [Persistent("warehouse_dfile_items")]
    public class DfileItem : VPObject
    {
        private int m_id;
        private int m_shopfloorlineId;
        private int m_incomingOrderId;         
        private int m_partId;
        private string m_comments;
        private string m_serialNumber;
        private string m_reason;
        private string m_resolution;
        private string m_resolvedBy;
        private Order m_actionOrder;
        private DfileAction m_action = DfileAction.NoAction;
        private bool m_disableDfileAtReceipt;
        private string m_lineItemIdentifier;
        
        private DfileStatus m_status = DfileStatus.Open;

        public DfileItem(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id",ref m_id, value); }
        }

        [Persistent("shopfloorline_id")]
        public int ShopfloorlineId
        {
            get { return m_shopfloorlineId; }
            set
            {
                SetPropertyValue("ShopfloorlineId", ref m_shopfloorlineId, value);
            }
        }

        [Persistent("incoming_order_id")]
        public int IncomingOrderId
        {
            get { return m_incomingOrderId; }
            set
            {
                SetPropertyValue("IncomingOrderId", ref m_incomingOrderId, value);
            }
        }

        [Persistent("comments")]
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }

        [Persistent("part_id")]
        public int PartId
        {
            get { return m_partId; }
            set
            {
                SetPropertyValue("Part",ref m_partId, value);
            }
        }

        [Persistent("serial_number")]
        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { SetPropertyValue("SerialNumber", ref m_serialNumber, value); }
        }

        [Persistent("reason")]
        public string Reason
        {
            get { return m_reason; }
            set { SetPropertyValue("Reason", ref m_reason, value); }
        }

        [Persistent("resolution")]
        public string Resolution
        {
            get { return m_resolution; }
            set { SetPropertyValue("Resolution", ref m_resolution, value); }
        }

        [Persistent("resolved_by")]
        public string ResolvedBy
        {
            get { return m_resolvedBy; }
            set { SetPropertyValue("ResolvedBy", ref m_resolvedBy, value); }
        }

        [Persistent("status")]
        public DfileStatus Status
        {
            get { return m_status; }
            set { SetPropertyValue("Status", ref m_status, value); }
        }

        [Persistent("action_type")]
        public DfileAction Action
        {
            get { return m_action; }
            set { SetPropertyValue("Action", ref m_action, value); }
        }

        [Persistent("disable_dfile_at_receipt")]
        public bool DisableDfileAtReceipt
        {
            get { return m_disableDfileAtReceipt; }
            set { SetPropertyValue("DisableDfileAtReceipt", ref m_disableDfileAtReceipt, value); }
        }

        [Persistent("line_item_identifier")]
        public string LineItemIdentifier
        {
            get { return m_lineItemIdentifier; }
            set { SetPropertyValue("LineItemIdentifier", ref m_lineItemIdentifier, value); }
        }

        [NonPersistent]
        public Shopfloorline Shopfloorline {                        
            get
            {
                if (m_shopfloorlineId > 0 && !IsLoading)
                    return Repository.Get<Shopfloorline>(Session).ById(m_shopfloorlineId);

                return null;
            }        
        }

        [NonPersistent]
        public Part Part
        {
            get
            {
                if (m_partId > 0 && !IsLoading)
                    return PartRepository.GetPartById(Session, m_partId);

                return null;
            }
        }

        [NonPersistent]
        public Order IncomingOrder
        {
            get
            {
                if (m_incomingOrderId > 0 && !IsLoading)
                    return Repository.Get<Order>(Session).ById(m_incomingOrderId);

                return null;
            }             
        }

        [Persistent("action_order_id")]
        public Order ActionOrder
        {
            get { return m_actionOrder; }
            set
            {
                SetPropertyValue("ActionOrder", ref m_actionOrder, value);                
            }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {            

        }
    }
}