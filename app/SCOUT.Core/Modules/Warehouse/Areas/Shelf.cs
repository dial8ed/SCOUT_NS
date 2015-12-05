using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a Shelf within a RackLocation
    /// </summary>
    [Persistent("areas")]
    [MapInheritance(MapInheritanceType.ParentTable)]   
    public class Shelf :  Area
    {
        private Bay _bay;
        public Shelf(Session session) : base(session)
        {
            
        }

        [Association("Bay-Shelves")]
        [Persistent("parent_id")]
        public Bay Parent
        {
            get { return _bay; }
            set
            {
                SetPropertyValue("Parent", ref _bay, value);
                m_parent = value;
            }
        }
    }
}