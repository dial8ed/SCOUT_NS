using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a RackLocation within a Domain
    /// </summary>
    [Persistent("Domain_Rack_Locations")]
    public class RackLocation: VPLiteObject, IArea, ILocation
    {
        private Domain _domain;
        private string _label;
        private string _section;
        private string _bay;
        private string _shelf;
        private AreaStatus m_Status;
        private string m_AreaType = "RackLocation";
        private string m_FullLocation;

        public RackLocation(Session session)
            : base(session)
        {
            
        }

        [NonPersistent]
        public int Id
        {
            get { return 0;} // Do Nothing
            set { } // Do Nothing
        }
        
        [Persistent("Section")]
        public string Section
        {
            get { return _section; }
            set { _section = value;}
        }

        [Persistent("Bay")]
        public string Bay
        {
            get { return _bay; }
            set { _bay = value;}
        }

        [Persistent("Shelf")]
        public string Shelf
        {
            get { return _shelf;  }
            set { _shelf = value;}
        }

        [Key(AutoGenerate = false)]
        [Persistent("Label")]
        public string Label
        {
            get { return _label; }
            set { _label = value;}
        }

        [NonPersistent]
        public AreaStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        [NonPersistent]
        public string AreaType
        {
            get { return m_AreaType; }
        }

        [NonPersistent]
        public string FullLocation
        {
            get { return _domain.FullLocation + "-" + _label; }
            set { _label = value; }
        }

        public bool Equals(Area other)
        {
            return false;
        }

        [Association("Domain-RackLocations")]
        [Persistent("DomainId")]
        public Domain Domain
        {
            get { return _domain; }
            set { _domain = value;}
        }

        public override string ToString()
        {
            return _label;
        }
    }
}