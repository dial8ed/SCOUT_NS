using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a moveable product container. 
    /// </summary>
    [MapInheritance(MapInheritanceType.OwnTable)]
    [Persistent("totes")]
    public class Tote : Area
    {
        private Domain m_domain;
        private ToteType m_type;
        
        public Tote(Session session) : base(session)
        {
            Active = true;
            Contents.CollectionChanged += Contents_CollectionChanged;
        }

        [Persistent("domain_id")]
        public Domain Domain
        {
            get { return m_domain; }         
            set { SetPropertyValue("Domain", ref m_domain, value); }
        }

        [Persistent("type")]
        public ToteType ToteType
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }

        // TODO: Clean this up
        [Association("tote-contents")]
        public XPCollection<InventoryItem> Contents
        {
            get
            {
                BinaryOperator filterCriteria =
                        new BinaryOperator("Tote", this);
                
                return new XPCollection<InventoryItem>(
                    Session as XpoUnitOfWork, filterCriteria);
            }
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            return (((Tote)obj).Id == Id);
        }

        protected override void OnSaving()
        {
            base.OnSaving();

            if(Label == "<new>")
                Label = string.Format("{0} {1}",ToteType,ToteNumbers.Next(ToteType));
        }

        //
        // Disassociate this tote from a domain if the contents is empty.
        //
        void Contents_CollectionChanged(object sender, XPCollectionChangedEventArgs e)
        {
            if (Contents.Count == 0)
            {
                Domain = null;
            }
        }
    }

    public enum ToteType
    {
        Rack = 1,
        Cart = 2,
        Pallet = 3,
        Tray = 4
    }
 }