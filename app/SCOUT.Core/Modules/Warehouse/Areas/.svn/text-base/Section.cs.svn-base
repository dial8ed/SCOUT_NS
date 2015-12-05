using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a section within a RackLocation
    /// </summary>
    [Persistent("area_sections")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Section : Area
    {
        private Domain _domain;
        
        public Section(Session session) 
            : base(session)
        {
               
           
        }
        
        [Association("Domain-Sections"),Aggregated]
        [Persistent("parent_id")]
        public Domain Parent
        {
            get { return _domain;  }
            set 
            { 
                SetPropertyValue("Parent", ref _domain, value);
                m_parent = value;
            }
        }

        [Association("Section-Bays"), Aggregated]
        public XPCollection<Bay> Bays
        {
            get
            {
                return GetCollection<Bay>("Bays");                
            }
        }

        public Bay CreateBay(int bayNumber)
        {            
            Bay bay = Scout.Core.Data.CreateEntity<Bay>(Session);
            bay.Label = (bayNumber.ToString().PadLeft(3, (char.Parse("0"))));
            bay.Active = true;
            Bays.Add(bay);
            return bay;            
        }
    }
}