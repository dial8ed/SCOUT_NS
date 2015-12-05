using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class MaterialPurchaseOrderFacts
    {
        private string m_rma;
        private string m_po;
        private string m_other;
        private Organization m_organization;
        private Domain m_receiveDomain;
        private IUnitOfWork m_session;

        private MaterialPurchaseOrder m_materialPurchaseOrder;

        public MaterialPurchaseOrderFacts()
        {
            m_session = Scout.Core.Data.GetUnitOfWork();
        }

        public string RMA
        {
            get { return m_rma; }
            set { m_rma = value; }
        }

        public string PO
        {
            get { return m_po; }
            set { m_po = value; }
        }

        public string Other
        {
            get { return m_other; }
            set { m_other = value; }
        }

        public Organization Organization
        {
            get { return m_organization; }
            set { m_organization = value; }
        }

        public Domain ReceiveDomain
        {
            get { return m_receiveDomain; }
            set { m_receiveDomain = value; }
        }

        public MaterialPurchaseOrder MaterialPurchaseOrder
        {
            get { return m_materialPurchaseOrder; }
            set { m_materialPurchaseOrder = value; }
        }

        public IUnitOfWork Session
        {
            get { return m_session; }
            set { m_session = value; }
        }
    }
}