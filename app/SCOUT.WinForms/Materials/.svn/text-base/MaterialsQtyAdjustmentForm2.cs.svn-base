using System;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules.Warehouse.Inventory;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Materials
{
    public partial class MaterialsQtyAdjustmentForm2 : XtraForm
    {
        private readonly IUnitOfWork m_session;
        private Part m_part;
        private Shopfloorline m_sfl;
        private Domain m_domain;
        private string m_rackLocation = null;
        private int m_qty = 1;
        private MessageListener m_messages;

        private Object thisLock = new Object();
        
        public MaterialsQtyAdjustmentForm2()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();                    
            m_messages = new MessageListener(new MessageBoxOutputHost());
            InitLists();
            WireEvents();
        }

        private void InitLists()
        {
            var adjustmentTypes = MaterialService.GetMaterialAdjustmentTransactionTypes();
            sourceTypeLookUp.Properties.DataSource = adjustmentTypes;

            shopfloorlineLookUp.Properties.DataSource =
                Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);

        }

        void shopfloorlineLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CurrentShopfloorline = shopfloorlineLookUp.EditValue as Shopfloorline;
        }

        private Shopfloorline CurrentShopfloorline
        {
            get { return m_sfl; }
            set
            {
                m_sfl = value;

                if (value != null)
                    domainLookUp.Properties.DataSource = m_sfl.LocatorControlledDomains;
                else
                    domainLookUp.Properties.DataSource = null;
            }
        }

        private string InventoryType
        {
            get { return inventoryTypeSelList.EditValue != null ? inventoryTypeSelList.EditValue.ToString() : ""; }
        }


        private void WireEvents()
        {
            partText.Validated += partText_Validated;            
            shopfloorlineLookUp.EditValueChanged += shopfloorlineLookUp_EditValueChanged;
            inventoryTypeSelList.EditValueChanged += inventoryTypeSelList_EditValueChanged;
            domainLookUp.EditValueChanged += domainLookUp_EditValueChanged;
            locationLookUp.EditValueChanged += locationLookUp_EditValueChanged;
        }

        void locationLookUp_EditValueChanged(object sender, EventArgs e)
        {
            var location = locationLookUp.EditValue;
            if(location != null)            
                m_rackLocation = location.ToString();           
        }

        void domainLookUp_EditValueChanged(object sender, EventArgs e)
        {
            m_domain = domainLookUp.EditValue as Domain;

            if (m_domain != null)
                locationLookUp.Properties.DataSource = m_domain.RackLocations;
            else
                locationLookUp.Properties.DataSource = null;           
        }

        void inventoryTypeSelList_EditValueChanged(object sender, EventArgs e)
        {
            if (InventoryType == "")
                return;

            locationLookUp.Properties.DataSource = null;

            bool readOnly = false;

            if (InventoryType == "Consumable")
                readOnly = true;

            domainLookUp.Properties.ReadOnly = readOnly;
            locationLookUp.Properties.ReadOnly = readOnly;                                           
        }

        private void partText_Validated(object sender, EventArgs e)
        {           
            if (string.IsNullOrEmpty(partText.Text))
            {
                ClearFields();
                return;
            }
                
            if(inventoryTypeSelList.EditValue == null)
                return;

            m_part = PartService.GetPartByPartNumber(m_session, partText.Text);
            if (m_part != null)            
                detailsGroup.Visibility = LayoutVisibility.Always;
            else           
                detailsGroup.Visibility = LayoutVisibility.Never;          
        }

        private void ClearFields()
        {
            shopfloorlineLookUp.EditValue = null;
            domainLookUp.Properties.DataSource = null;
            locationLookUp.Properties.DataSource = null;
            sourceTypeLookUp.EditValue = null;
            commentsText.Text = "";
            partText.Focus();
        }


        private void putAwayButton_Click(object sender, EventArgs e)
        {
                AdjustInventory();
                partText.Focus();
        }

        private void AdjustInventory()
        {

            
            if (!dxValidationProvider1.Validate())
                return;

            int qty = Int32.Parse(adjustmentQtyEdit.Value.ToString());
            var sourceType = sourceTypeLookUp.EditValue as AdjustmentTransactionType;

            var success = false;

            if (InventoryType == "Consumable")
                success = MaterialService.AdjustMaterialConsumableItem(m_part, m_sfl, qty, commentsText.Text, sourceType, m_messages);
            else
                success = MaterialService.AdjustMaterialWarehouseItem(m_part, m_domain, m_rackLocation, qty,
                                                                      commentsText.Text, sourceType, m_messages);

            if (success)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Material Qty Adjusted.", UserMessageType.Information);
                Reset();
            }

        }
        
        private void Reset()
        {
            partText.Text = "";
            partText_Validated(null, null);
            detailsGroup.Visibility = LayoutVisibility.Never;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}