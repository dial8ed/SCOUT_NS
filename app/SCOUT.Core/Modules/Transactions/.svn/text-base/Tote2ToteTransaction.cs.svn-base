using DevExpress.Xpo;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class Tote2ToteTransactionSpecification : TransactionSpecification
    {
        private Shopfloorline m_shopfloorline;
        private IArea m_destinationArea;
        private IArea m_sourceArea;
        private Session m_session;

        public Tote2ToteTransactionSpecification(Shopfloorline shopfloorline, TransactionType type) : base(type)
        {
            m_shopfloorline = shopfloorline;
            m_session = shopfloorline.Session as XpoUnitOfWork;
            m_sourceAreas = new XPCollection(m_session,typeof(Tote));
            m_destinationAreas = new XPCollection(m_session,typeof(Tote));                 
        }

        public override bool ReloadDestinationsOnSourceChange
        {
            get { return false; }
        }

        public override string SourceName
        {
            get {return "Tote:";}
        }

        public override string DestinationName
        {
            get { return "Tote:"; }
        }

        public override IArea DestinationArea
        {
            get { return m_destinationArea; }
            set
            {
                m_destinationArea = value;
            }
        }

        public override IArea SourceArea
        {
            get { return m_sourceArea; }
            set
            {
                m_sourceArea = value;                
            }
        }

        public override void UpdateItem()
        {
            Scout.Core.Service<IInventoryService>().AddItemToTote((Tote) m_destinationArea, Item);     
        }
    }
}