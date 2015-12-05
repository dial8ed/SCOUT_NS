using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("sales_line_item_schedules")]
    public class SalesLineItemSchedule : VPLiteObject
    {
        private int m_id;
        private SalesLineItem m_salesLineItem;
        private int m_qty;
        private DateTime m_scheduledDate;
        private bool m_isDefault;


        public SalesLineItemSchedule(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("line_item_id")]
        [Association("LineItem-Schedules"), Aggregated]
        public SalesLineItem LineItem
        {
            get { return m_salesLineItem; }
            set { SetPropertyValue("LineItem", ref m_salesLineItem, value); }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { SetPropertyValue("Qty", ref m_qty, value); }
        }

        [Persistent("scheduled_date")]
        public DateTime ScheduledDate 
        { 
            get { return m_scheduledDate; }
            set { SetPropertyValue("ScheduledDate", ref m_scheduledDate, value); }
        }

        [Persistent("is_default")]
        public bool IsDefault
        {
            get { return m_isDefault; }
            set { SetPropertyValue("IsDefault", ref m_isDefault, value); }
        }
    }
}