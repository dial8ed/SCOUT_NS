using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsWarehouseReturnForm : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private MaterialConsumableItem m_selectedItem;

        public MaterialsWarehouseReturnForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();
            WireEvents();
        }

        private MaterialConsumableItem SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                if (m_selectedItem != null)
                {
                    selectedPartText.Text = m_selectedItem.Part.PartNumber;
                    selectedPartShopfloorlineText.Text = m_selectedItem.Shopfloorline.Label;
                    domainSelList.Properties.DataSource = m_selectedItem.Shopfloorline.LocatorControlledDomains;                 
                    qtyText.Text = m_selectedItem.Qty.ToString();
                    domainSelList.Focus();
                }
                else
                {
                    selectedPartText.Text = "";
                    selectedPartShopfloorlineText.Text = "";
                    domainSelList.Properties.DataSource = null;
                    qtyText.Text = "";
                }
            }
        }

        private void WireEvents()
        {
            partText.Validated += partText_Validated;
            consumableItemsGrid.DoubleClick += domainItemsGrid_DoubleClick;
        }

        private void domainItemsGrid_DoubleClick(object sender, EventArgs e)
        {
            MaterialConsumableItem selectedItem =
                consumableItemsView.GetFocusedRow() as MaterialConsumableItem;

            if (selectedItem != null)
            {
                SelectedItem = selectedItem;
            }
        }

        private void partText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(partText.Text))
                return;

            Part part = PartService.GetPartByPartNumber(m_session, partText.Text);

            if (part != null)
            {
                LoadConsumableItems(part);
            } 
        }

        private void LoadConsumableItems(Part part)
        {
            consumableItemsGrid.DataSource = MaterialService.GetConsumableItemsByPart(part);

            if(consumableItemsGrid.DataSource == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("No results found.", UserMessageType.Warning); 
        }

        private void putAwayButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            Domain domain  = domainSelList.EditValue as Domain;
            if (domain != null)
            {
                int qty = Int32.Parse(qtyText.Text);
                if (MaterialService.ReturnMaterialToWarehouse(SelectedItem, domain, qty))                       
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage("Material Returned to the Warehouse", UserMessageType.Information);
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