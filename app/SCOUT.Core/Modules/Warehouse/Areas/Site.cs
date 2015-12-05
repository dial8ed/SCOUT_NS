using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a business Site.
    /// </summary>
    [Persistent("areas")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class Site : Area
    {
        static private Site m_site;

        static public Site Current
        {
            get { return m_site;}
            set
            {
                if(m_site == null)
                {
                    m_site = value;
                }
            }
        }

        public Site(Session session): base(session)
        {
            
        }

        // This violates the Dont talk to strangers principle.
        // Fix it later once the XPO stuff is better understood.
        // TODO: Dont violate the Dont talk to strangers principle
        [Association("Site-ShopfloorLines"), Aggregated]
        public XPCollection<Shopfloorline> ShopfloorLines
        {
            get { return GetCollection<Shopfloorline>("ShopfloorLines"); }
        }
    }
}