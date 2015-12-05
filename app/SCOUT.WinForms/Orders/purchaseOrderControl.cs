using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Warehouse.Inventory;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;


namespace SCOUT.WinForms.Orders
{
    public partial class PurchaseOrderControl : XtraUserControl, IValidationControl
    {
        #region fields

        private Domain m_domain;
        private RobotList<Organization> m_organizations;
        private List<PartIdentType> m_partIdentTypes;
        private PurchaseOrder m_po;
        private Shopfloorline m_shopfloorline;
        private XPCollection<Shopfloorline> m_shopfloorlines;

        #endregion

        #region .ctor

        public PurchaseOrderControl(PurchaseOrder purchaseOrder)
        {
            InitializeComponent();
            m_po = purchaseOrder;
            InitLists();
            Bind();
            WireEvents();
            SetupTemplateMode(purchaseOrder);
        }

        private void SetupTemplateMode(PurchaseOrder purchaseOrder)
        {
            if (!purchaseOrder.Order.IsTemplate)
                return;

            poTabs.Visibility = LayoutVisibility.Never;
        }

        public PurchaseOrderControl()
        {
            InitializeComponent();
        }

        #endregion

        #region event handlers

        private void shopfloorlineSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            m_shopfloorline = shopfloorlineSelList.SelectedItem as Shopfloorline;

            if (m_shopfloorline != null && CanLoadShopfloorline())
            {
                m_po.Shopfloorline = m_shopfloorline;                
                LoadDefaults(m_shopfloorline);
                LoadDomains(m_shopfloorline);
                LoadRoutes(m_shopfloorline);
                LoadPrograms(m_shopfloorline);
            }
        }

        private bool CanLoadShopfloorline()
        {
            if(m_po.ReturnType == ReturnType.NotDefined)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Select return type before the shopfloorline", UserMessageType.Warning);
                shopfloorlineSelList.EditValue = null;
                returnTypeLookup.Focus();
                return false;
            }

            return true;
        }

        private void LoadPrograms(Shopfloorline shopfloorline)
        {
            programLookup.Properties.DataSource = shopfloorline.ProgramList;   
        }

        private void LoadDefaults(Shopfloorline shopfloorline)
        {
            m_po.RoutingRequired = shopfloorline.RoutingRequired;           
        }

        private void LoadRoutes(Shopfloorline shopfloorline)
        {
            if (shopfloorline == null)
                return;

            routeSelList.DataSource = shopfloorline.GetServiceRoutesByReturnType(m_po.ReturnType);
            routeSelList.DisplayMember = "Name";
            routeSelList.ValueMember = "This";

            headerRouteSelList.Properties.DataSource = shopfloorline.GetServiceRoutesByReturnType(m_po.ReturnType);
            headerRouteSelList.Properties.DisplayMember = "Name";
            headerRouteSelList.Properties.ValueMember = "This";
        }

        // Need this because SelectedItem binding does not update the business object.
        private void recDomainSelList_SelectedValueChanged(object sender, EventArgs e)
        {
            m_domain = recDomainSelList.SelectedItem as Domain;

            if (m_domain != null)
            {
                m_po.RecDomain = m_domain;
            }
        }

        private void suppSelList_EditValueChanged(object sender, EventArgs e)
        {
            int orgId = (int) suppSelList.EditValue;
            m_po.OrgId = orgId;
            if (m_po.Organization != null)
            {
                LoadContacts(m_po.Organization);
                LoadOrganizationDefaults(m_po.Organization);
            }
        }

        private void LoadOrganizationDefaults(Organization organization)
        {
            if(m_po.ReturnType == ReturnType.NotDefined)
                m_po.ReturnType = organization.DefaultReturnType;           
        }

        private void suppSelList_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Ellipsis:
                    EditSelectedOrg();
                    break;

                case ButtonPredefines.Plus:
                    CreateNewOrg();
                    break;
            }
        }

        private void lineItemNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                m_po.LineItems.DeleteObjectOnRemove = true;
                m_po.LineItems.Remove(
                    m_po.LineItems[lineItemsGrid.EmbeddedNavigator.NavigatableControl.Position]);
                e.Handled = true;
            }
        }

        private void loadDellPreAlertLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            if (!m_po.IsBlanket())
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("This order already contains line items and a pre-alert cannot be imported.", UserMessageType.Error);
                return;
            }

            ViewLoader.Instance().CreateFormWithArgs<PreAlertImportForm>(false, m_po);
        }

        #endregion

        #region methods

        private void LoadContacts(Organization organization)
        {
            contactBinding.DataSource = organization.Contacts;
            contactSelList.Properties.DataSource = contactBinding;
        }

        private void LoadDomains(Shopfloorline sfl)
        {
            // guard
            if (sfl == null)
                return;

            // Load only the domains that are defined as pre-process domains
            recDomainSelList.SelectedIndex = -1;
            recDomainSelList.Properties.Items.Clear();
            recDomainSelList.Properties.Items.AddRange(sfl.PreProcessDomains);

            itemRecDomainLookup.DataSource = sfl.PreProcessDomains;
        }

        private void Bind()
        {
            poBinding.DataSource = m_po;
            poErrors.DataSource = poBinding;

            lineItemsGrid.DataBindings.Add("DataSource", poBinding, "LineItems");
            workInstructionsText.DataBindings.Add("Text", poBinding, "WorkInstructions");
            notesText.DataBindings.Add("Text", poBinding, "Notes");
            buyerText.DataBindings.Add("Text", poBinding, "Buyer");

            shopfloorlineSelList.DataBindings.Add("SelectedItem", poBinding, "Shopfloorline");
            recDomainSelList.DataBindings.Add("SelectedItem", poBinding, "RecDomain");

            suppSelList.DataBindings.Add("EditValue", poBinding, "OrgId");
            contactSelList.DataBindings.Add("EditValue", poBinding, "ContactId");
            sourceTypeLookup.DataBindings.Add("EditValue", poBinding, "SourceType");


            suppSelList.Properties.DisplayMember = "Name";
            suppSelList.Properties.ValueMember = "Id";

            contactSelList.Properties.DisplayMember = "Name";
            contactSelList.Properties.ValueMember = "Id";

            deltaGrid.DataBindings.Add("DataSource", poBinding, "ReceiptDeltas");
            routingRequiredCheck.DataBindings.Add("Checked", poBinding, "RoutingRequired");           
            returnTypeLookup.DataBindings.Add("EditValue", poBinding, "ReturnType");
                       
            lineStatusesList.DataSource = Enum.GetValues(typeof (LineItemStatus));
            returnTypeLookup.Properties.DataSource = Enum.GetValues(typeof (ReturnType));
                                           
            if (m_po.Shopfloorline != null)
            {
                shopfloorlineSelList.SelectedItem = m_po.Shopfloorline;
                LoadDomains(m_po.Shopfloorline);
                recDomainSelList.SelectedItem = m_po.RecDomain;
                headerRouteSelList.EditValue = m_po.ServiceRoute;
                LoadPrograms(m_po.Shopfloorline);
            }

            programLookup.DataBindings.Add("EditValue", m_po, "Program");
            
        }

        private void WireEvents()
        {
            shopfloorlineSelList.SelectedValueChanged += shopfloorlineSelList_SelectedValueChanged;
            recDomainSelList.SelectedValueChanged += recDomainSelList_SelectedValueChanged;
            suppSelList.EditValueChanged += suppSelList_EditValueChanged;
            suppSelList.ButtonClick += suppSelList_ButtonClick;
            lineItemsGrid.EmbeddedNavigator.ButtonClick += lineItemNavigator_ButtonClick;
            pnButtons.ButtonClick += pnButtons_ButtonClick;
            headerRouteSelList.EditValueChanged += headerRouteSelList_EditValueChanged;
            headerRouteSelList.ButtonClick += new ButtonPressedEventHandler(headerRouteSelList_ButtonClick);
            routeSelList.ButtonClick += routeSelList_ButtonClick;           
        }

        void headerRouteSelList_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Delete)
            {
                m_po.ServiceRoute = null;
                headerRouteSelList.EditValue = null;
            }               
        }

        void routeSelList_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Undo)
            {
                PurchaseLineItem item = lineItemsView.GetFocusedRow() as PurchaseLineItem;
                if(item != null)
                    item.ServiceRoute = null;                
            }
        }

        void headerRouteSelList_EditValueChanged(object sender, EventArgs e)
        {
            m_po.ServiceRoute = headerRouteSelList.EditValue as ServiceRoute;
        }

        private void pnButtons_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                LoadPartEditor();
            }
        }

        private void LoadPartEditor()
        {
            PurchaseLineItem lineItem = lineItemsView.GetFocusedRow() as PurchaseLineItem;
            if (lineItem != null)
            {
                if (lineItem.Part != null)
                {
                    PartEditForm form = new PartEditForm(lineItem.Part);
                    form.ShowDialog();
                }
            }
        }

        private void InitLists()
        {
            Site site = Scout.Core.Service<IAreaService>()
                .GetSiteById(m_po.Session, SCOUT.Core.Data.Site.Current.Id);

            m_shopfloorlines = site.ShopfloorLines;
            shopfloorlineSelList.Properties.Items.AddRange(m_shopfloorlines);

            m_partIdentTypes = new List<PartIdentType>();
            m_partIdentTypes.AddRange(PartIdentType.GetPartIdentTypes(m_po.Session));

            repositoryItemComboBox1.Items.AddRange(m_partIdentTypes);

            LoadSuppliers();
            LoadRoutes(m_po.Shopfloorline);
            LoadSourceTypes();
        }


        private void LoadSourceTypes()
        {                       
            var sourceTypes = Scout.Core.Service<IInventoryService>()
                .GetAllAdjustmentTransactionTypes()
                .Where(s => s.Direction == "IN" && !s.Code.Contains("PARTS")).ToList();

            var poSource = new AdjustmentTransactionType("PURREC", "Purchase Order", "IN");
            sourceTypes.Add(poSource);

            sourceTypeLookup.Properties.ValueMember = "Code";
            sourceTypeLookup.Properties.DisplayMember = "Description";
            sourceTypeLookup.Properties.DataSource = sourceTypes;

            if (string.IsNullOrEmpty(m_po.SourceType))
                m_po.SourceType = poSource.Code;

        }

        private void LoadSuppliers()
        {
            m_organizations = Organization.GetActiveOrganizations();

            orgBinding.DataSource = m_organizations;
            suppSelList.Properties.DataSource = orgBinding;
        }

        private void EditSelectedOrg()
        {
            if (suppSelList.EditValue == null)
                return;

            Organization o =
                Organization.GetOrganization((int) suppSelList.EditValue);

            if (o != null)
            {
                EditOrganizationForm dlg =
                    new EditOrganizationForm(o);

                if (dlg.ShowDialog(Parent) == DialogResult.OK)
                    LoadSuppliers();
            }
        }

        private void CreateNewOrg()
        {
            EditOrganizationForm dlg = new EditOrganizationForm(null);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                m_organizations.Add(dlg.Organization);
                suppSelList.EditValue = dlg.Organization.Id;
            }
        }

        #endregion

        #region IValidationControl implementations

        public bool IsValid()
        {
            suppSelList.Focus();
            return m_po.Error.Length <= 0;
        }

        public string Error()
        {
            return m_po.Error;
        }

        #endregion
        
    }
}