using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Warehouse.Inventory;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsQtyAdjustmentForm : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private IMaterialItem m_selectedItem;

        public MaterialsQtyAdjustmentForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();
            InitLists();
            WireEvents();
        }

        private void InitLists()
        {
            var adjustmentTypes = MaterialService.GetMaterialAdjustmentTransactionTypes();
            sourceTypeLookUp.Properties.DataSource = adjustmentTypes;
        }

        private IMaterialItem SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                m_selectedItem = value;
                if (m_selectedItem != null)
                {
                    selectedPartText.Text = m_selectedItem.Part.PartNumber;
                    locationText.Text = m_selectedItem.RackLocation;

                    domainText.Text = m_selectedItem.Domain == null
                                          ? ""
                                          : m_selectedItem.Domain.ToString();

                    shopfloorlineText.Text = m_selectedItem.Shopfloorline ==
                                             null
                                                 ? ""
                                                 : m_selectedItem.Shopfloorline.
                                                       ToString();

                    adjustmentQtyEdit.Properties.MaxValue = m_selectedItem.Qty;
                    adjustmentQtyEdit.Properties.MinValue = 1;
                }
                else
                {
                    selectedPartText.Text = "";
                    locationText.Text = "";
                    shopfloorlineText.Text = "";
                    domainText.Text = "";
                    commentsText.Text = "";
                    adjustmentQtyEdit.Properties.MinValue = 0;
                    adjustmentQtyEdit.Properties.MaxValue = 0;
                    sourceTypeLookUp.EditValue = null;
                    adjustmentQtyEdit.EditValue = 0;
                }
            }
        }

        private void WireEvents()
        {
            partText.Validated += partText_Validated;
            materialItemsGrid.DoubleClick += domainItemsGrid_DoubleClick;            
        }

        private void domainItemsGrid_DoubleClick(object sender, EventArgs e)
        {
            IMaterialItem selectedItem =
                materialItemsView.GetFocusedRow() as IMaterialItem;

            if (selectedItem != null)
            {
                SelectedItem = selectedItem;
            }
        }

        private void partText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(partText.Text))
                return;


            if(inventoryTypeSelList.EditValue == null)
                return;

            Part part = PartService.GetPartByPartNumber(m_session, partText.Text);
            if (part != null)
            {
                LoadItemsByInventoryType(inventoryTypeSelList.EditValue.ToString(), part);                        
            }            
        }

        private void LoadItemsByInventoryType(string text, Part part)
        {
            switch(text)
            {                    
                case("Warehouse"):
                    LoadWarehouseItems(part);
                    break;

                case("Consumable"):
                    LoadConsumableItems(part);
                    break;
            }
        }

        private void LoadWarehouseItems(Part part)
        {
            materialItemsGrid.DataSource = MaterialService.GetWarehouseItemsByPart(part);

            if(materialItemsGrid.DataSource == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage
                    ("No results found.", UserMessageType.Warning);
        }

        private void LoadConsumableItems(Part part)
        {
            materialItemsGrid.DataSource = MaterialService.GetConsumableItemsByPart(part);

            if (materialItemsGrid.DataSource == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("No results found.", UserMessageType.Warning);
        }

        private void putAwayButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            if (SelectedItem == null)
                return;

            int qty = Int32.Parse(adjustmentQtyEdit.Value.ToString());
            var sourceType = sourceTypeLookUp.EditValue as AdjustmentTransactionType;

            // if(inventoryTypeSelList.EditValue.ToString() == "Consumable")
            //     MaterialService.AdjustMaterialConsumableItem()
            //if (MaterialService.(SelectedItem, qty, m_session, commentsText.Text, sourceType))                                
            //     {
            //         Scout.Core.UserInteraction.Dialog.ShowMessage("Material Qty Adjusted.", UserMessageType.Information);
            //         Reset();
            //     }
            // }
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