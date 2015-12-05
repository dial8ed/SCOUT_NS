using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_service_route_dipositions")]
    public class ServiceRouteDisposition
    {
        private Guid m_id;
        private ServiceRoute m_serviceRoute;
        private InventoryItem m_item;
        private DateTime  m_completionDate;
        private string m_disposition;


        [Persistent("id"), Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { m_id = value; }
        }


        [Persistent("service_route_id")]
        public ServiceRoute ServiceRoute
        {
            get { return m_serviceRoute; }
            set { m_serviceRoute = value; }
        }

        [Persistent("lotid")]
        public InventoryItem Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        [Persistent("completion_date")]
        public DateTime CompletionDate
        {
            get { return m_completionDate; }
            set { m_completionDate = value; }
        }

        [Persistent("disposition")]
        public string Disposition
        {
            get { return m_disposition; }
            set { m_disposition = value; }
        }
    }
}