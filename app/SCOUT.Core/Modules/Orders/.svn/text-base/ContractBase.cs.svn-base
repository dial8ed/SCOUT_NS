using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("order_contracts")]
    public abstract class ContractBase : VPObject
    {
        private int m_id;
        private Order m_order;


        protected ContractBase(Session session) : base(session)
        {

        }

        [Key(AutoGenerate = true)]
        [Persistent("id")]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Association("Order-Contracts")]
        [Persistent("order_id")]
        public Order Order
        {
            get { return m_order; }
            set { SetPropertyValue("Order", ref m_order, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
        }
    }
}