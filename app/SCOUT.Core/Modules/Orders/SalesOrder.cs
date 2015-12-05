using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    [Persistent("sales_orders")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class SalesOrder : ContractBase
    {
        private string m_billToAccount = "";
        private string m_billToAddress = "";
        private Contact m_contact;
        private int m_contactId = -1;
        private int m_id;
        private string m_notes = "";
        private Organization m_organization;
        private int m_orgId = -1;
        private string m_paymentTerms = "";
        private int m_salesOrderNumber;
        private string m_salesRep = "";
        private int m_salesStatus = -1;
        private decimal m_salesTax;
        private string m_shipMethod = "";
        private ShippingResults m_shippingResults;
        private string m_shipToAddress = "";
        private string m_subTotal;
        private int m_turnAroundTime;        
        private AreaStatus m_domainStatus = null;
        private Shopfloorline m_shopfloorline;
        private bool m_newPacklistUponShipment = false;      
        private ServiceRoute m_requiredServiceRoute;
        private string m_requiredProgram;
        private Packlist m_assignedPacklist;
        private bool m_useConfiguration;

        public SalesOrder(Session session) : base(session)
        {

        }

        [Persistent("so_number")]
        public int SalesOrderNumber
        {
            get { return m_salesOrderNumber; }
            set { SetPropertyValue("SalesOrderNumber", ref m_salesOrderNumber, value); }
        }

        [Persistent("status")]
        public int SalesStatus
        {
            get { return m_salesStatus; }
            set { SetPropertyValue("SalesStatus", ref m_salesStatus, value); }
        }

        [Persistent("sales_rep")]
        public string SalesRep
        {
            get { return m_salesRep; }
            set { SetPropertyValue("SalesRep", ref m_salesRep, value); }
        }

        [Persistent("org_id")]
        public int OrgId
        {
            get { return m_orgId; }
            set
            {
                if (value > 0)
                {
                    m_organization = Organization.GetOrganization(value);
                    SetPropertyValue("OrgId", ref m_orgId, value);
                }
            }
        }

        [Persistent("contact_id")]
        public int ContactId
        {
            get { return m_contactId; }
            set
            {
                if (value > 0)
                {
                    if (m_organization != null)
                    {
                        SetPropertyValue("ContactId", ref m_contactId, value);
                        m_contact = m_organization.Contacts.Find("Id", m_contactId);
                    }
                }
            }
        }

        [Persistent("ship_method")]
        public string ShipMethod
        {
            get { return m_shipMethod; }
            set { SetPropertyValue("ShipMethod", ref m_shipMethod, value); }
        }

        [Persistent("notes")]
        public string Notes
        {
            get { return m_notes; }
            set { SetPropertyValue("Notes", ref m_notes, value); }
        }

        [Persistent("ship_to_addr")]
        public string ShipToAddress
        {
            get { return m_shipToAddress; }
            set { SetPropertyValue("ShipToAddress", ref m_shipToAddress, value); }
        }

        [Persistent("bill_to_addr")]
        public string BillToAddress
        {
            get { return m_billToAddress; }
            set { SetPropertyValue("BillToAddress", ref m_billToAddress, value); }
        }

        [Persistent("payment_terms")]
        public string PaymentTerms
        {
            get { return m_paymentTerms; }
            set { SetPropertyValue("PaymentTerms", ref m_paymentTerms, value); }
        }

        [Persistent("sales_tax")]
        public decimal SalesTax
        {
            get { return m_salesTax; }
            set { SetPropertyValue("SalesTax", ref m_salesTax, value); }
        }

        [Persistent("bill_to_acct")]
        public string BillToAccount
        {
            get { return m_billToAccount; }
            set { SetPropertyValue("BillToAccount", ref m_billToAccount, value); }
        }

        [Persistent("sub_total")]
        public string SubTotal
        {
            get { return m_subTotal; }
            set { SetPropertyValue("SubTotal", ref m_subTotal, value); }
        }

        [Persistent("turn_around_time")]
        public int TurnAroundTime
        {
            get { return m_turnAroundTime; }
            set { SetPropertyValue("TurnAroundTime", ref m_turnAroundTime, value); }
        }

        [Persistent("domain_status_id")]
        public AreaStatus ShipmentDomainStatus
        {
            get { return m_domainStatus; }
            set { SetPropertyValue("ShipmentDomainStatus", ref m_domainStatus, value); }           
        }

        [Persistent("shopfloorline_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set
            {
                if (value == null || !value.Equals(m_shopfloorline))
                    RequiredServiceRoute = null;

                SetPropertyValue("Shopfloorline", ref m_shopfloorline, value);
            }
        }

        [Persistent("required_route_id")]
        public ServiceRoute RequiredServiceRoute
        {
            get { return m_requiredServiceRoute; }
            set { SetPropertyValue("RequiredServiceRoute", ref m_requiredServiceRoute, value); }
        }

        [Persistent("required_program")]
        public string RequiredProgram
        {
            get { return m_requiredProgram; }
            set { SetPropertyValue("RequiredProgram", ref m_requiredProgram, value); }
        }

        [Persistent("use_configuration")]
        public bool UseConfiguration
        {
            get { return m_useConfiguration; }
            set
            {
                SetPropertyValue("UseConfiguration", ref m_useConfiguration, value);

                if (m_useConfiguration)
                    ShipToAddress = "USE CONFIGURATION";          
            }
        }

        [NonPersistent]
        public bool NewPacklistUponShipment
         {
             get
             {
                 if (GetTodaysPacklist() == null)
                     return true;

                 return m_newPacklistUponShipment;
             }
             set { m_newPacklistUponShipment = value; }
         }
        [NonPersistent]
        public Organization Organization
        {
            get { return m_organization; }
            set
            {
                if (m_organization != value)
                {
                    m_organization = value;

                    if (value != null)
                    {
                        OrgId = m_organization.Id;
                        // Reset items that are organization specific
                        Contact = null;

                        if(!UseConfiguration)
                            ShipToAddress = "";

                        BillToAddress = "";
                    }
                }
            }
        }

        [NonPersistent]
        public Contact Contact
        {
            get { return m_contact; }
            set
            {
                if (m_contact != value)
                {
                    m_contact = value;

                    if (value != null)
                        ContactId = m_contact.Id;
                }
            }
        }

        public string Activity
        {
            get
            {
                return "";

                //string.Format("Create Date: {0}" +
                //                     Environment.NewLine +
                //                     "Created By: {1}" +
                //                     Environment.NewLine +
                //                     "Last Update: {2}" +
                //                     Environment.NewLine +
                //                     "Updated By: {3}", m_order.CreatedDate, m_order.CreatedBy, m_order.LastUpdated,
                //                     m_order.UpdatedBy);
            }
        }


        [NonPersistent]
        public ShippingResults ShippingResults
        {
            get
            {
                if (m_shippingResults == null)
                    m_shippingResults = new ShippingResults(m_salesOrderNumber);

                return m_shippingResults;
            }
        }


        [Association("SalesOrder-CartItems"), Aggregated]
        public XPCollection<SalesLineItem> CartItems
        {
            get { return GetCollection<SalesLineItem>("CartItems"); }
        }


        [Association("SalesOrder-Shipments")]
        public XPCollection<Shipment> Shipments
        {
            get { return GetCollection<Shipment>("Shipments"); } 
        }

        [Association("SalesOrder-ShipmentDeltas")]
        public XPCollection<ShipmentDelta> ShipmentDeltas
        {
            get { return GetCollection<ShipmentDelta>("ShipmentDeltas"); }
        }

        [Association("SalesOrder-Packlists")]
        public XPCollection<Packlist> Packlists
        {
            get { return GetCollection<Packlist>("Packlists"); }
        }

        [Association("SalesOrder-ShipTos")]
        public XPCollection<SalesOrderShipTo> ShipTos
        {
            get { return GetCollection<SalesOrderShipTo>("ShipTos"); }
        }


        [NonPersistent]
        public Packlist AssignedPacklist { get; set; }

        public Packlist GetCurrentPacklist()
        {
            if (AssignedPacklist != null)
                return AssignedPacklist;

            Packlist todaysPacklist = GetTodaysPacklist();

            if (todaysPacklist != null && NewPacklistUponShipment == false)
                return todaysPacklist;

            
            return NewPacklist();
 
        }

        public Packlist GetTodaysPacklist()
        {
            if(Packlists.Count == 0)
                return null;

            Packlist packlist = Packlists[Packlists.Count - 1];
            if (packlist == null || packlist.ShipDate.Date != DateTime.Today)
            {
                return null;
            }
            
            return packlist;
        }

        private Packlist NewPacklist()
        {            
            Packlist newPacklist = new Packlist(Session as Session);
            newPacklist.SalesOrder = this;
            newPacklist.PacklistId = ShippingUtils.GeneratePacklistId();
            newPacklist.ShipDate = DateTime.Now;
            Packlists.Add(newPacklist);

            // Reset the new packlist upon shipment flag
            // so that a new packlist is not generated
            // upon each new shipment for this sequence.
            m_newPacklistUponShipment = false;

            return newPacklist;
        }

        public decimal ExpectedQtyForPart(int partId)
        {            
            return CartItems.FirstOrDefault(ci => ci.Part.Id == partId).OpenQty;

            //int qty = 0;

            //foreach (Shipment shipment in Shipments)
            //{
            //    if (shipment.Part.Id == partId)
            //        qty += shipment.Qty;
            //}

            //return LineItemQtyForPart(partId) - qty;
        }

        public int LineItemQtyForPart(int partId)
        {
            int qty = 0;
            foreach (SalesLineItem item in CartItems)
            {
                if(item.PartId == partId)
                    qty += item.Quantity;
            }

            return qty;
        }

        public int GetItemId(int id)
        {
            foreach (SalesLineItem item in CartItems)
            {
                if (item.PartId == id)
                    return item.Id;
            }

            return 0;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_organization,
                             "SONoCustomer", "No customer selected.", "Organization");

            Verify.IsFalse(
                HasDuplicateSOItems(),
                "SODupCartItems",
                "There are duplicate items in the cart.",
                "CartItems");

            Verify.IsNotEmpty(SalesRep,
                              "SONoSalesRep", "No sales rep selected.", "SalesRep");

            Verify.IsNotNull(m_shopfloorline, 
                "SflReq", "Sales Order shopfloorline is required.", "Shopfloorline");

            Verify.IsNotEmpty(m_shipToAddress, "ShipToReq","Ship To Address is required", "ShipToAddress");


            if(this.Order.OrderType == OrderType.ReturnNReplace && !Order.IsTemplate)
                Verify.IsTrue(CartItems.Count > 0, "RnRLineItemsReq","Sales order line items are required for a return n replace order.", "CartItems");


            foreach (SalesLineItem salesLineItem in CartItems)
            {                
                if (!salesLineItem.IsDeleted)
                    Verify.IsTrue(salesLineItem.Error.Length == 0,
                        Guid.NewGuid().ToString(),
                        salesLineItem.Error,
                        "PartId");
            }
        }

        private bool HasDuplicateSOItems()
        {
            //List<SOItem> checkList = new List<SOItem>();
            //foreach (SOItem i1 in CartItems)
            //{
            //    foreach (SOItem i2 in checkList)
            //    {
            //        if (i1.Equals(i2))
            //            return true;
            //    }

            //    checkList.Add(i1);
            //}

            return false;
        }

        public void CopyItemsFromPurchaseOrder(PurchaseOrder order)
        {
            if (CartItems.Count > 0)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Sales Order already contains line items.", UserMessageType.Error);
                return;
            }

            foreach (PurchaseLineItem item in order.LineItems)
            {
                // Map the sales line item if the part does not exist already.
                if(GetItemId(item.Part.Id) ==0)
                    CartItems.Add(new SalesItemMapper().MapFrom(item));
            }

            CopyCustomerInfoFromPurchaseOrder(order);
        }

        public void RollupLineItemsFromPurchaseOrder(PurchaseOrder order)
        {
            if (CartItems.Count > 0)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Sales Order already contains line items.", UserMessageType.Error);
                return;
            }

            foreach (PurchaseLineItem item in order.LineItems)
            {
                if(item.OutgoingPart != null)
                {
                    SalesLineItem lineItem = GetLineByPart(item.OutgoingPart);                    
                    if(lineItem != null)
                        lineItem.Quantity += item.Quantity;
                    else
                    {
                        lineItem = Scout.Core.Data.CreateEntity<SalesLineItem>(Session);
                        lineItem.Part = item.OutgoingPart;
                        lineItem.Quantity = item.Quantity;     
                        CartItems.Add(lineItem);
                    }                                    
                }                
            }

            CopyCustomerInfoFromPurchaseOrder(order);
        }

        private void CopyCustomerInfoFromPurchaseOrder(PurchaseOrder order)
        {
            if (Order.CreatedFromTemplate)
                return;

            this.Organization = order.Organization;
            this.Contact = order.Contact;
            this.Shopfloorline = order.Shopfloorline;
            this.RequiredServiceRoute = order.ServiceRoute;
            this.RequiredProgram = order.Program;
        }

        public SalesLineItem GetLineByPart(Part part)
        {
            foreach (SalesLineItem item in CartItems)
            {
                if (item.Part.Id == part.Id)
                    return item;
            }

            return null;
        }
        
        public void DeleteMultipleShipToAddresses()
        {
            ShipTos.DeleteObjectOnRemove = true;

            for (int i = ShipTos.Count -1; i >= 0; i--)
            {
                ShipTos.Remove(ShipTos[i]);
            }
        }

    }
}