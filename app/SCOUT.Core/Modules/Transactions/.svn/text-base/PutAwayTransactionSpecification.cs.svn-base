using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class PutAwayTransactionSpecification : TransactionSpecification
    {
        private IArea m_destinationArea;
        private Shopfloorline m_shopfloorline;
        private IArea m_sourceArea;
        private Session m_session;
        
        public PutAwayTransactionSpecification(Shopfloorline shopfloorline,TransactionType type):base(type)
        {
            m_shopfloorline = shopfloorline;
            m_session = shopfloorline.Session as XpoUnitOfWork;
            BinaryOperator filter = new BinaryOperator("LocatorControlled", true);
            m_sourceAreas = new XPCollection(m_session, m_shopfloorline.ActiveDomains, filter);
            //m_destinationAreas = new XPCollection(m_session, typeof(RackLocation));           
        }


        public override void UpdateItem()
        {
            RackLocation location = m_destinationArea as RackLocation;
            if (location != null)
                Item.LocatorLabel = location.Label;
        }

        public override bool ReloadDestinationsOnSourceChange
        {
            get { return true; }
        }

        public override string SourceName
        {
            get { return "Domain:"; }
        }

        public override string DestinationName
        {
            get { return "Location:"; }
        }


        public override IArea DestinationArea
        {
            get { return m_destinationArea; }
            set { m_destinationArea = value; }
        }

        public override IArea SourceArea
        {
            get { return m_sourceArea; }
            set
            {
                m_sourceArea = value;
                m_destinationAreas = new XPCollection(m_session, ((Domain)m_sourceArea).RackLocations);
            }
        }
    }
}