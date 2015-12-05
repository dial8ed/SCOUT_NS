using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsPutAwayForm : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private MaterialWarehouseItem m_selectedItem;

        public MaterialsPutAwayForm()
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
                    rackSelList.Properties.DataSource = m_selectedItem.Domain.RackLocations;
                    qtyText.Text = m_selectedItem.Qty.ToString();
                    rackSelList.Focus();
                }
                else
                {
                    selectedPartText.Text = "";
                    selectedPartDomainText.Text = "";
                    rackSelList.Properties.DataSource = null;
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

            Part part = PartService.GetPartByPartNumber(m_session, partText.Text);

            if (part != null)
            {
                LoadWarehouseItemsNeedingPutAway(part);                    
            }            
        }

        private void LoadWarehouseItemsNeedingPutAway(Part part)
        {
            domainItemsGrid.DataSource = MaterialService.GetItemsNeedingPutAway(part);

            if(domainItemsGrid.DataSource == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("No results found.", UserMessageType.Warning);
        }

        private void putAwayButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;


            RackLocation location = rackSelList.EditValue as RackLocation;
            if (location != null)
            {
                int qty = Int32.Parse(qtyText.Text);
                string comments = "";
                if (MaterialService.PutAwayMaterial(SelectedItem, location, qty, comments))
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage("Material Put Away", UserMessageType.Information);
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