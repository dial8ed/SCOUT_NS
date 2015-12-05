using System;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsPurchaseOrderForm : XtraForm
    {
        private readonly MaterialPurchaseOrder m_materialPurchaseOrder;
        private readonly IUnitOfWork m_session;

        public MaterialsPurchaseOrderForm(MaterialPurchaseOrder order)
        {
            InitializeComponent();
            m_materialPurchaseOrder = order;
            m_session = order.Session;
            LoadLists();
            Bind();
            WireEvents();
        }

        private void WireEvents()
        {
            shopfloorlineLookupEdit.EditValueChanged += shopfloorlineLookupEdit_EditValueChanged;
            receiveDomainLookupEdit.EditValueChanged += receiveDomainLookupEdit_EditValueChanged;
            supplierLookupEdit.EditValueChanged += supplierLookupEdit_EditValueChanged;
            saveButton.ItemClick += saveButton_ItemClick;
            closeButton.ItemClick += closeButton_ItemClick;
        }

        private void supplierLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            Organization organization = supplierLookupEdit.EditValue as Organization;
            if (organization != null)
            {
                m_materialPurchaseOrder.OrganizationId = organization.Id;
            }
        }

        private void closeButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void saveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            // Validate required fields.
            if (!dxValidationProvider1.Validate())
                return;

            // Validate Business Logic
            if (new MaterialPOValidator(m_materialPurchaseOrder).Validated())
            {
                Scout.Core.Data.Save(m_session);                
                Scout.Core.UserInteraction.Dialog.ShowMessage("Save Successful.", UserMessageType.Information);
                Close();
            }
        }

        private void receiveDomainLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            Domain domain = receiveDomainLookupEdit.EditValue as Domain;
            if (domain != null)
            {
                m_materialPurchaseOrder.ReceiveDomain = domain;
            }
        }

        private void shopfloorlineLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            Shopfloorline shopfloorline = shopfloorlineLookupEdit.EditValue as Shopfloorline;
            if (shopfloorline != null)
            {
                LoadDomains(shopfloorline);
            }
        }

        private void LoadDomains(Shopfloorline shopfloorline)
        {
            receiveDomainLookupEdit.Properties.DataSource = shopfloorline.LocatorControlledDomains;
            receiveDomainLookupEdit.Properties.DisplayMember = "Label";
            receiveDomainLookupEdit.Properties.ValueMember = "This";
            receiveDomainLookupEdit.Reset();
        }

        private void Bind()
        {
            rmaText.DataBindings.Add("Text", m_materialPurchaseOrder, "RMA");
            poText.DataBindings.Add("Text", m_materialPurchaseOrder, "PO");
            otherText.DataBindings.Add("Text", m_materialPurchaseOrder, "Other");
            supplierLookupEdit.DataBindings.Add("EditValue", m_materialPurchaseOrder, "Organization");
            lineItemsGrid.DataBindings.Add("DataSource", m_materialPurchaseOrder, "LineItems");

            supplierLookupEdit.EditValue = m_materialPurchaseOrder.Organization;

            // Load a existing order for editing.
            if (m_materialPurchaseOrder.ReceiveDomain != null)
                LoadPersistedOrder();
        }

        private void LoadPersistedOrder()
        {
            Shopfloorline sfl = m_materialPurchaseOrder.ReceiveDomain.Parent;
            shopfloorlineLookupEdit.EditValue = sfl;
            LoadDomains(sfl);
            receiveDomainLookupEdit.EditValue = m_materialPurchaseOrder.ReceiveDomain;
        }

        private void LoadLists()
        {
            supplierLookupEdit.Properties.DataSource = Organization.GetActiveOrganizations();

            shopfloorlineLookupEdit.Properties.DataSource =
                Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);

            lineStatusesList.DataSource = Enum.GetValues(typeof (LineItemStatus));
        }

        private void removeLineItemLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            MaterialPurchaseLineItem lineItem = lineItemsView.GetFocusedRow() as MaterialPurchaseLineItem;
            if (lineItem != null)
                m_materialPurchaseOrder.LineItems.Remove(lineItem);
        }
    }
}