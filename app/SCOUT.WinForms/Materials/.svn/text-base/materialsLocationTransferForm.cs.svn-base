using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsLocationTransferForm : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private MaterialWarehouseItem m_selectedItem;

        public MaterialsLocationTransferForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();

            domainSelList.Properties.DataSource =
                Scout.Core.Service<IAreaService>().GetAllLocatorControlledDomains(m_session);
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
                    locationText.Text = m_selectedItem.RackLocation;                                        
                    qtyText.Text = m_selectedItem.Qty.ToString();
                    domainSelList.EditValue = m_selectedItem.Domain;
                    domainSelList.Focus();
                }
                else
                {
                    selectedPartText.Text = "";
                    locationText.Text = "";
                    domainSelList.EditValue = null;
                    rackSelList.Properties.DataSource = null;
                    qtyText.Text = "";
                }
            }
        }

        private void WireEvents()
        {
            partText.Validated += partText_Validated;
            warehouseItemsGrid.DoubleClick += domainItemsGrid_DoubleClick;
            domainSelList.EditValueChanged += domainSelList_EditValueChanged;
            warehouseItemsView.FocusedRowChanged += warehouseItemsView_FocusedRowChanged;
        }

        void warehouseItemsView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadItemResults();   
        }

        void domainSelList_EditValueChanged(object sender, EventArgs e)
        {
            Domain domain = domainSelList.EditValue as Domain;
            if(domain != null)
            {
                LoadRackLocations(domain);
            }            
        }


        private void LoadRackLocations(Domain domain)
        {
            rackSelList.Properties.DataSource = domain.RackLocations;
        }


        private void LoadItemResults()
        {
            MaterialWarehouseItem selectedItem =
                warehouseItemsView.GetFocusedRow() as MaterialWarehouseItem;

            if (selectedItem != null)
            {
                SelectedItem = selectedItem;
            }
        }

        private void domainItemsGrid_DoubleClick(object sender, EventArgs e)
        {
            LoadItemResults();
        }

        private void partText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(partText.Text))
                return;

            Part part = PartService.GetPartByPartNumber(m_session, partText.Text);

            if (part != null)
            {
                LoadWarehouseLocationItems(part);                    
            }            
        }

        private void LoadWarehouseLocationItems(Part part)
        {
            warehouseItemsGrid.DataSource = MaterialService.GetIssuableItemsByPart(part);

            if(warehouseItemsGrid.DataSource == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("No results found.", UserMessageType.Warning);
        }

        private void putAwayButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            if (SelectedItem == null)
                return;

            RackLocation location = rackSelList.EditValue as RackLocation;
            if (location != null)
            {
                int qty = Int32.Parse(qtyText.Text);
                Domain domain = domainSelList.EditValue as Domain;
                string comments = commentsText.Text;
                if (MaterialService.TransferMaterialToLocation(SelectedItem,domain, location.Label, qty, comments))
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage("Material Transferred.", UserMessageType.Information);
                    Reset();
                }
            }
        }

        private void Reset()
        {
            partText_Validated(null, null);
            SelectedItem = null;
            partText.SelectAll();
            partText.Focus();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}