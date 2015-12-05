using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a Domain within a Shopfloorline
    /// </summary>
    [Persistent("areas")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Domain : Area
    {
        private Shopfloorline _shopfloorline;
        private bool _locatorControlled;
        private bool m_isPreProcessArea;
        private bool m_isShippable;

        public Domain(Session session) : base(session)
        {
        }

        [Persistent("locator_controlled")]
        public bool LocatorControlled
        {
            get { return _locatorControlled; }
            set { SetPropertyValue("LocatorControlled", ref _locatorControlled, value); }
        }

        [Persistent("is_pre_process_area")]
        public bool IsPreProcessArea
        {
            get { return m_isPreProcessArea; }
            set { SetPropertyValue("IsPreProcessArea", ref m_isPreProcessArea, value); }
        }

        [Persistent("is_shippable")]
        public bool IsShippable
        {
            get { return m_isShippable; }
            set { SetPropertyValue("IsShippable", ref m_isShippable, value); }
        }

        [Persistent("parent_id")]
        [Association("ShopfloorLine-Domains"), Aggregated]
        public Shopfloorline Parent
        {
            get { return _shopfloorline; }
            set
            {
                SetPropertyValue("ShopfloorLine", ref _shopfloorline, value);
                this.m_parent = value;
            }
        }

        [NonPersistent]
        public string ParentLabel
        {
            get
            {
                /// Workaround for B1 MRB domain not getting the parent
                /// correctly. This happens during shipment. The inventory repository
                /// will pull a inventory item, but for some reason in this instance
                /// it does not pull the domain correctly! WTF
                if(Parent == null)
                    return Label;

                return Parent.Label + "-" + Label;
            }
        }

        [Association("Domain-Sections"), Aggregated]
        public XPCollection<Section> Sections
        {
            get { return GetCollection<Section>("Sections"); }
        }

        [Association("Domain-RackLocations")]
        public XPCollection<RackLocation> RackLocations
        {
            get { return GetCollection<RackLocation>("RackLocations"); }
        }

        public override string ToString()
        {
            return ParentLabel;
        }

        public Section CreateSection(string label)
        {
            Section section = Scout.Core.Data.CreateEntity<Section>(Session);
            section.Active = true;
            section.Label = label;            
            Sections.Add(section);
            return section;
        }
    }
}