using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class DomainTransactionSpecification : TransactionSpecification
    {
        private Shopfloorline m_shopfloorline;
        private IArea m_DestinationArea = null;
        private IArea m_SourceArea = null;
        private Session m_session;

        public DomainTransactionSpecification(Shopfloorline sfl, TransactionType type) : base(type)
        {
            m_shopfloorline = sfl;
            m_session = sfl.Session as XpoUnitOfWork;

            m_sourceAreas = new XPCollection(m_session, m_shopfloorline.ActiveDomains);
            m_destinationAreas = new XPCollection(m_session, m_shopfloorline.ActiveDomains);               
        }

        public override bool ReloadDestinationsOnSourceChange
        {
            get { return false;}
        }

        public override void UpdateItem()
        {
            Item.Domain = m_DestinationArea as Domain;
            Item.LocatorLabel = "";
        }

        public override string SourceName
        {
            get { return "Depart Domain"; }
        }

        public override string DestinationName
        {
            get { return "Destination Domain"; }
        }

        public override IArea DestinationArea
        {
            get { return m_DestinationArea; }
            set
            {
                m_DestinationArea = value;
            }
        }

        public override IArea SourceArea
        {
            get { return m_SourceArea; }
            set
            {
                m_SourceArea = value;
            }
        }

        public override string GetErrors()
        {
            if (Item.CurrentProcess != null && ((Domain)DestinationArea).IsShippable)
            {
                return "This unit is on a route and cannot be moved to " + DestinationArea.Label;
            }

            return "";

        }
    }
}