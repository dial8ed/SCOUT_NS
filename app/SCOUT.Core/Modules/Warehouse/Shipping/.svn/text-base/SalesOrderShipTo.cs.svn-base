using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("sales_order_ship_tos")]
    public class SalesOrderShipTo : VPObject
    {
        private int m_id;
        private SalesOrder m_salesOrder;
        private Domain m_shipDomain;
        private string m_shipToAddress;
        private Address m_address;

        public SalesOrderShipTo(Session session) : base(session)
        {
        }

        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("sales_order_id")]
        [Association("SalesOrder-ShipTos")]
        public SalesOrder SalesOrder
        {
            get { return m_salesOrder; }
            set { SetPropertyValue("SalesOrder", ref m_salesOrder, value); }
        }

        [Persistent("ship_domain_id")]
        public Domain ShipDomain
        {
            get { return m_shipDomain; }
            set { SetPropertyValue("ShipDomain", ref m_shipDomain, value); }
        }

        [NonPersistent]
        public Address Address
        {
            set
            {
                if (value != null)
                    ShipToAddress = value.ToString();

                m_address = value;
            }
            get { return m_address; }
        }

        [Persistent("ship_to_address"), Size(255)]
        public string ShipToAddress
        {
            get { return m_shipToAddress; }
            set { SetPropertyValue("ShipToAddress", ref m_shipToAddress, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {

        }
    }
}