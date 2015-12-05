using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_documents")]
    public class RouteStationDocument : VPLiteObject
    {
        private int m_id;
        private Document m_document;
        private RouteStation m_station;        

        public RouteStationDocument(Session session) : base(session)
        {
            Document = new Document(session);
        }

        [Persistent("Id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("document_id")]        
        public Document Document
        {
            get { return m_document; }
            set { SetPropertyValue("Document", ref m_document, value); }
        }

        [Persistent("route_station_id")]
        [Association("RouteStation-Documents")]
        public RouteStation Station
        {
            get { return m_station; }
            set { SetPropertyValue("Station", ref m_station, value); }
        }

        [NonPersistent]
        public int ImageIndex
        {
            get { return 0;  }
        }

        [NonPersistent]
        public string FilePath
        {
            get { return m_document.FilePath; }
            set { m_document.FilePath = value; }
        }

        [NonPersistent]
        public string Name
        {
            get { return m_document.Name;  }
            set { m_document.Name = value;}
        }

        public override string ToString()
        {
            return m_document.Name;
        }
    }
}