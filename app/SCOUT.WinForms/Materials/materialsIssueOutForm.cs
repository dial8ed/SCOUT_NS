using System;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsIssueOutForm : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private MaterialWarehouseItem m_selectedItem;

        public MaterialsIssueOutForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();
            WireEvents();
        }

        private MaterialWarehouseItem SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                if (m_selectedItem != null)
                {
                    selectedPartText.Text = m_selectedItem.Part.PartNumber;
                    selectedPartDomainText.Text = m_selectedItem.Domain.Label;
                    rackLocationText.Text = m_selectedItem.RackLocation;
                    shopfloorlineSelList.Properties.DataSource = 
                        Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);                    
                    qtyText.Text = m_selectedItem.Qty.ToString();
                    shopfloorlineSelList.Focus();
                }
                else
                {
                    selectedPartText.Text = "";
                    selectedPartDomainText.Text = "";
                    shopfloorlineSelList.Properties.DataSource = null;
                    qtyText.Text = "";
                }
            }
        }

        private void WireEvents()
        {
            partText.Validated += partText_Validated;
            domainItemsGrid.DoubleClick += domainItemsGrid_DoubleClick;
        }

        private void domainItemsGrid_DoubleClick(object sender, EventArgs e)
        {
            MaterialWarehouseItem selectedItem =
                domainItemsView.GetFocusedRow() as MaterialWarehouseItem;

            if (selectedItem != null)
            {
                SelectedItem = selectedItem;
            }
        }

        private void partText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(partText.Text))
                return;

            Part part = MaterialService.GetPartByPartNumber(m_session, partText.Text);

            if (part != null)
            {
                LoadIssuableItems(part);
            }
        }

        private void LoadIssuableItems(Part part)
        {
            domainItemsGrid.DataSource = MaterialService.GetIssuableItemsByPart(part);

            if(domainItemsGrid.DataSource == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("No results found.", UserMessageType.Warning);
        }

        private void putAwayButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            Shopfloorline shopfloorline = shopfloorlineSelList.EditValue as Shopfloorline;
            if (shopfloorline != null)
            {
                int qty = Int32.Parse(qtyText.Text);
                if (MaterialService.IssueOutMaterial(SelectedItem, shopfloorline, qty))
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage("Material Issued Out", UserMessageType.Information);
                    Reset();
                }
            }
        }

        private void Reset()
        {
            partText_Validated(null, null);
            SelectedItem = null;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}