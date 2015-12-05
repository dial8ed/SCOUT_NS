using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [MapInheritance(MapInheritanceType.ParentTable)]
    [Persistent("areas")]
    public class Bay : Area
    {
        private Section _section;

        public Bay(Session session) : base(session)
        {
        }

        [Association("Section-Bays"), Aggregated]
        [Persistent("parent_id")]
        public Section Parent
        {
            get { return _section; }
            set
            {
                SetPropertyValue("Parent", ref _section, value);
                m_parent = value;
            }
        }

        [Association("Bay-Shelves"), Aggregated]
        public XPCollection<Shelf> Shelves
        {
            get { return GetCollection<Shelf>("Shelves"); }
        }

        public Shelf CreateShelf(int shelfNumber)
        {
            Shelf shelf  =Scout.Core.Data.CreateEntity<Shelf>(Session);
            shelf.Active = true;
            shelf.Label = (shelfNumber.ToString().PadLeft(3, char.Parse("0")));
            Shelves.Add(shelf);
            return shelf;          
        }
    }
}