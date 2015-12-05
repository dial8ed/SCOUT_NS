using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("material_purchase_orders")]
    public class MaterialPurchaseOrder : VPObject
    {
        private Guid m_id;
        private Organization m_supplier;
        private int m_orgId;
        private string m_rma;
        private string m_po;
        private Domain m_receiveDomain;
        private string m_other;

        public MaterialPurchaseOrder(Session session)
            : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }


        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("organization_id")]
        public  int OrganizationId
        {
            get { return m_orgId; }
            set
            {
                SetPropertyValue("OrganizationId", ref m_orgId, value);
            }
        }

        [NonPersistent]
        public Organization Organization
        {
            get
            {
                return Organization.GetOrganization(m_orgId);
            }
        }

        [Persistent("rma")]
        public string RMA
        {
            get { return m_rma; }
            set { SetPropertyValue("RMA", ref m_rma, value); }
        }

        [Persistent("po")]
        public string PO
        {
            get { return m_po; }
            set { SetPropertyValue("PO", ref m_po, value); }
        }

        [Persistent("other")]
        public string Other
        {
            get { return m_other; }
            set { SetPropertyValue("Other", ref m_other, value); }
        }

        [Persistent("receive_domain_id")]
        public Domain ReceiveDomain
        {
            get { return m_receiveDomain; }
            set { SetPropertyValue("ReceiveDomain", ref m_receiveDomain, value); }
        }

        [NonPersistent]
        public Shopfloorline Shopfloorline
        {
            get { return m_receiveDomain == null ? null : m_receiveDomain.Parent; }
        }

        [Association("MaterialPO-LineItems")]
        public XPCollection<MaterialPurchaseLineItem> LineItems
        {
            get { return GetCollection<MaterialPurchaseLineItem>("LineItems"); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

        public MaterialPurchaseLineItem GetLineItemForPart(Part part)
        {
            foreach (MaterialPurchaseLineItem item in LineItems)
            {
                if(item.Part.Equals(part))
                    return item;
            }

            return null;
        }
    }
}