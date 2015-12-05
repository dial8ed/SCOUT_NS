namespace SCOUT.Core.Data
{
    public class ReceiptFacts
    {       
        private int m_qty;
        private string m_serialNumber;
        private string m_condition = "";
        private string m_comments;
        private Part m_part;
        private Tote m_receiveCart;
        private bool m_routingRequired;
        private PurchaseOrder m_order;
        private PurchaseLineItem m_lineItem;
        private ItemCustomFields m_customFields;
        private ProductGrade m_grade = ProductGrade.NA;
        private IUnitOfWork m_session;
        private string m_warnings;
        private IPreAlertItem m_preAlertItem;
        private string m_lineItemIdentifier;
       
        public IUnitOfWork Session
        {
            get { return m_session; }
            set { m_session = value; }
        }

        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { m_serialNumber = value; }
        }

        public int Qty
        {
            get { return m_qty; }
            set { m_qty = value; }
        }

        public string Condition
        {
            get { return m_condition; }
            set { m_condition = value; }
        }

        public string Comments
        {
            get { return m_comments; }
            set { m_comments = value; }
        }

        public Part Part
        {
            get { return m_part; }
            set { m_part = value; }
        }

        public Tote ReceivingCart
        {
            get { return m_receiveCart; }
            set { m_receiveCart = value; }
        }

        public bool RoutingRequired
        {
            get { return m_routingRequired; }
            set { m_routingRequired = value; }
        }

        public PurchaseOrder PurchaseOrder
        {
            get { return m_order; }
            set { m_order = value; }
        }

        public PurchaseLineItem PurchaseLineItem
        {
            get { return m_lineItem; }
            set { m_lineItem = value; }
        }

        public ItemCustomFields CustomFields
        {
            get { return m_customFields; }
            set { m_customFields = value; }
        }

        public ProductGrade Grade
        {
            get { return m_grade; }
            set { m_grade = value; }
        }

        public string Warnings
        {
            get { return m_warnings; }
            set { m_warnings = value; }
        }

        public IPreAlertItem PreAlertItem   
        {
            get {
                return m_preAlertItem;
            }
            set {
                m_preAlertItem = value;
            }
        }

        public bool DisableDfileCheck { get; set; }

        public string LineItemIdentifier { get; set; }

        public string SourceType { get; set; }
    }
}