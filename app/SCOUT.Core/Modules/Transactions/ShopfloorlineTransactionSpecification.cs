using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class ShopfloorlineTransactionSpecification : TransactionSpecification
    {
        private Shopfloorline m_shopfloorline;
        private IArea m_DestinationArea;
        private IArea m_SourceArea;
        private Session m_session;
        private bool m_isProgramRequired = false;

        public ShopfloorlineTransactionSpecification(Shopfloorline sfl, TransactionType type) : base(type)
        {
            m_shopfloorline = sfl;
            m_session = sfl.Session as XpoUnitOfWork;

            m_sourceAreas = new XPCollection(m_session, m_shopfloorline.ActiveDomains);  

        }

        public override IArea DestinationArea
        {
            get { return m_DestinationArea; }
            set
            {
                m_DestinationArea = value;
                //if (m_DestinationArea != null)
                //    IsProgramRequired = ((Domain) m_DestinationArea).Parent.IsProgramRequired;
                               
            }
        }

        public override IArea SourceArea
        {
            get { return m_SourceArea; }
            set
            {
                m_SourceArea = value;

                BinaryOperator statusFilter = new BinaryOperator("Status", ((Domain)m_SourceArea).Status);
                BinaryOperator sflFilter = new BinaryOperator("Parent", m_shopfloorline, BinaryOperatorType.NotEqual);
                GroupOperator groupFilter = new GroupOperator(new CriteriaOperator[] { statusFilter, sflFilter });
                m_destinationAreas = new XPCollection(m_session, typeof(Domain), groupFilter);
            }
        }

        public override bool ReloadDestinationsOnSourceChange
        {
            get { return true; }
        }

        public override bool IsProgramRequired
        {
            get { return m_isProgramRequired; }    
            set
            {
                m_isProgramRequired = value;
            }
        }

        public override void UpdateItem()
        {
            Domain domain = m_DestinationArea as Domain;
            if(domain != null)
            {
                Item.Shopfloorline = domain.Parent;
                Item.Domain = domain;
                Item.LocatorLabel = "";
            }
        }

        public override string SourceName
        {
            get { return "Domain:"; }
        }

        public override string DestinationName
        {
            get { return "SFL Domain:"; }
        }
        
    }
}