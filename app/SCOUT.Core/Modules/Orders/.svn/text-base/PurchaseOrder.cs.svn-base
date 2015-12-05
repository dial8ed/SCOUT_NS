using System;
using DevExpress.Xpo;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    [Persistent("purchase_orders")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class PurchaseOrder : ContractBase
    {
        private DateTime m_cancelDate;
        private string m_cancelledBy;
        private Contact m_contact;
        private int m_contactId;
        private string m_notes;
        private Organization m_organization;
        private int m_orgId;
        private int m_purchaseOrderNumber;
        private Domain m_recDomain;
        private ReceivingResults m_receivingResults;
        private ServiceRoute m_route;
        private bool m_routingRequired = false;
        private Shopfloorline m_shopfloorline;
        private string m_program;
        private int m_status;
        private string m_workInstructions;
        private string m_preAlertType;
        private string m_buyer;
        private ReturnType m_returnType;
        private string m_sourceType = "PURREC";

        public PurchaseOrder(Session session) : base(session)
        {
        }

        [Persistent("po_number")]
        public int PurchaseOrderNumber
        {
            get { return m_purchaseOrderNumber; }
            set { SetPropertyValue("PurchaseOrderNumber", ref m_purchaseOrderNumber, value); }
        }

        [Persistent("rec_domain_id")]
        public Domain RecDomain
        {
            get { return m_recDomain; }
            set { SetPropertyValue("RecDomain", ref m_recDomain, value); }
        }

        [Persistent("shopfloorline_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set
            {
                SetPropertyValue("Shopfloorline", ref m_shopfloorline, value);
                
                // Reset Program 2.3.3.1
                if(!IsLoading)
                    Program = "";

                UpdateSflDetailsForLineItems();
            }
        }

        [Persistent("program")]
        public string Program
        {
            get { return m_program; }
            set { SetPropertyValue("Program", ref m_program, value); }
        }

        [Persistent("contact_id")]
        public int ContactId
        {
            get { return m_contactId; }
            set
            {
                SetPropertyValue("ContactId", ref m_contactId, value);
                LoadContact();
            }
        }

        [Persistent("org_id")]
        public int OrgId
        {
            get { return m_orgId; }
            set
            {
                SetPropertyValue("OrgId", ref m_orgId, value);
                LoadOrganization();
            }
        }

        [Persistent("cancelled_by")]
        public string CancelledBy
        {
            get { return m_cancelledBy; }
            set { SetPropertyValue("CancelledBy", ref m_cancelledBy, value); }
        }

        [Persistent("cancel_date")]
        public DateTime CancelDate
        {
            get { return m_cancelDate; }
            set { SetPropertyValue("CancelDate", ref m_cancelDate, value); }
        }

        [Persistent("work_instructions")]
        public string WorkInstructions
        {
            get { return m_workInstructions; }
            set { SetPropertyValue("WorkInstructions", ref m_workInstructions, value); }
        }

        [Persistent("notes")]
        public string Notes
        {
            get { return m_notes; }
            set { SetPropertyValue("Notes", ref m_notes, value); }
        }

        [Persistent("status")]
        public int Status
        {
            get { return m_status; }
            set { SetPropertyValue("Status", ref m_status, value); }
        }

        [Persistent("service_route_id")]
        public ServiceRoute ServiceRoute
        {
            get { return m_route; }
            set { SetPropertyValue("ServiceRoute", ref m_route, value); }
        }

        [Persistent("routing_required")]
        public bool RoutingRequired
        {
            get { return m_routingRequired; }
            set { SetPropertyValue("RoutingRequired", ref m_routingRequired, value); }
        }

        [Persistent("buyer")]
        public string Buyer
        {
            get { return m_buyer; }
            set { SetPropertyValue("Buyer", ref m_buyer, value); }
        }

        [Persistent("return_type")]
        public ReturnType ReturnType
        {
            get { return m_returnType; }
            set { SetPropertyValue("ReturnType", ref m_returnType, value); }
        }

        [Persistent("source_type")]
        public string SourceType
        {
            get { return m_sourceType; }
            set { SetPropertyValue("SourceType", ref m_sourceType, value); }
        }

        public Organization Organization
        {
            get { return m_organization; }
            set
            {
                SetPropertyValue("Organization", ref m_organization, value);

                if (value != null)
                    OrgId = value.Id;
            }
        }

        public Contact Contact
        {
            get { return m_contact; }
            set
            {
                m_contact = value;

                if (value != null)
                    ContactId = value.Id;
            }
        }

        [NonPersistent]
        public ReceivingResults ReceivingResults
        {
            get
            {
                if (m_receivingResults == null)
                    m_receivingResults = new ReceivingResults(m_purchaseOrderNumber);

                return m_receivingResults;
            }
        }

        [Association("PO-LineItems"), Aggregated]
        public XPCollection<PurchaseLineItem> LineItems
        {
            get { return GetCollection<PurchaseLineItem>("LineItems"); }
        }

        [Association("PurchaseOrder-Receipts")]
        public XPCollection<Receipt> Receipts
        {
            get { return GetCollection<Receipt>("Receipts"); }
        }

        [Association("PurchaseOrder-ReceiptDeltas")]
        public XPCollection<ReceiptDelta> ReceiptDeltas
        {
            get { return GetCollection<ReceiptDelta>("ReceiptDeltas"); }
        }

        //[Association("PurchaseOrder-DellPreAlertItems")]
        //public XPCollection<DellPreAlertItem> DellPreAlertItems
        //{
        //    get { return GetCollection<DellPreAlertItem>("DellPreAlertItems"); }
        //}

        //[Association("PurchaseOrder-XipPreAlertItems")]
        //public XPCollection<XipPreAlertItem> XipPreAlertItems
        //{
        //    get { return GetCollection<XipPreAlertItem>("XipPreAlertItems"); }
        //}

        internal bool IsDuplicate(Part newPart)
        {
            if (newPart == null) return false;
            return (GetLineByPart(newPart) != null);
        }

        public PurchaseLineItem LineItemByPart(Part part)
        {
            return GetLineByPart(part);
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_shopfloorline, "SflRequired", "Shopfloorline is required.", "Shopfloorline");
            Verify.IsNotNull(m_recDomain, "RecDomainRequired", "Rec domain is required.", "RecDomain");
            Verify.IsNotNull(m_organization, "OrgRequired", "Supplier is required.", "Organization");
            Verify.IsTrue(m_returnType != ReturnType.NotDefined,"ReturnTypeRequired","Return Type is required.", "ReturnType");
            Verify.IsFalse(
                m_shopfloorline != null && m_shopfloorline.IsProgramRequired && string.IsNullOrEmpty(m_program),
                "ProgramRequired","Program is required.", "Program");

            if (this.Order.OrderType == OrderType.ReturnNReplace && !Order.IsTemplate)
                Verify.IsTrue(LineItems.Count > 0, "RnRLineItemsReq", "Purchase order line items are required for a return n replace order.", "CartItems");

            foreach (PurchaseLineItem purchaseLineItem in LineItems)
            {
                if (!purchaseLineItem.IsDeleted)
                    Verify.IsTrue(purchaseLineItem.Error.Length == 0,
                                  Guid.NewGuid().ToString(),
                                  purchaseLineItem.Error,
                                  "PartId");
            }
        }

        private void LoadOrganization()
        {
            m_organization = Organization.GetOrganization(m_orgId);
            LoadContact();
        }

        private void LoadContact()
        {
            if (m_organization == null) return;
            m_contact = m_organization.Contacts.Find("Id", m_contactId);
        }

        public void CopyItemsFromSalesOrder(SalesOrder order)
        {
            foreach (SalesLineItem item in order.CartItems)
            {
                if (LineItemByPart(item.Part) == null)
                    LineItems.Add(new PurchaseItemMapper().MapFrom(item));
            }

            Organization = order.Organization;
            Contact = order.Contact;
            Shopfloorline = order.Shopfloorline;
            Program = order.RequiredProgram;
        }

        // Remove the rec domains on line items that 
        // reference a domain that belongs to a previous shopfloorline 
        private void UpdateSflDetailsForLineItems()
        {
            if (!IsLoading)
                foreach (PurchaseLineItem item in LineItems)
                {
                    Domain recDomain = item.ReceiveDomain;
                    if (recDomain != null)
                        if (!recDomain.Parent.Equals(m_shopfloorline))
                            item.ReceiveDomain = null;

                    ServiceRoute route = item.ServiceRoute;
                    if (route != null)
                        if (!route.Shopfloorline.Equals(m_shopfloorline))
                            item.ServiceRoute = null;
                }
        }

        public bool IsBlanket()
        {
            return LineItems.Count == 0;
        }

        public bool IsExpectedPreAlertItem(string serialNumber)
        {
            IPreAlert preAlert =
                OrderService.GetPreAlertByType(PreAlertType);
                         
            if(preAlert == null)
                return true;

            return preAlert.SerialIsExpected(this,serialNumber);
        }

        public IPreAlertItem GetPreAlertItem(string serialNumber)
        {
            IPreAlert preAlert =
                OrderService.GetPreAlertByType(PreAlertType);

            if (preAlert == null)
                return null;

            return preAlert.GetItemBySerialNumber(this, serialNumber);            
        }

        public PurchaseLineItem GetLineByPart(Part part)
        {
            if (IsBlanket()) return null;

            if(part == null) return null;

            foreach (PurchaseLineItem item in LineItems)
            {
                if (item.Part != null)
                {
                    if (item.AllowDownlevels)
                    {
                        if (item.Part.PartFamily != null)
                        {
                            if (item.Part.PartFamily.Equals(part.PartFamily))
                                return item;
                        }
                    }
                    else
                    {
                        if (item.Part.Id == part.Id)
                            return item;
                    }
                }
            }
            return null;
        }

        public int OutgoingPartProcessedQty(Part part)
        {
            int qty = 0;
            foreach (PurchaseLineItem item in LineItems)
            {
                if (item.OutgoingPart.Equals(part))
                    qty += item.ProcessedQty;
            }

            return qty;            
        }

        public PurchaseLineItem AddLineItem(Part part, int qty)
        {            
            PurchaseLineItem lineItem = Scout.Core.Data.CreateEntity<PurchaseLineItem>(Session);
            lineItem.PurchaseOrder = this;
            lineItem.Quantity = qty;
            lineItem.LoadPartDetails(part);
            LineItems.Add(lineItem);

            return lineItem;
        }

        [Persistent("prealert_system_type")]
        public string PreAlertType
        {
            get { return m_preAlertType; }
            set { SetPropertyValue("PreAlertType", ref m_preAlertType, value); }
        }
    }
}