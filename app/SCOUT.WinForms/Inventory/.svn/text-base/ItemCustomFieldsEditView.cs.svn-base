using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.Core;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Inventory
{   
    public partial class ItemCustomFieldsEditView : Form
    {
        private PersistenceController m_persistence;
        private ItemCustomFields m_customFields;

        public ItemCustomFieldsEditView(string lotId) 
        {
            InitializeComponent();
            m_persistence = new PersistenceController(Scout.Core.Data.GetUnitOfWork());                       
            inventoryIdentText.Text = lotId;
            LoadItem();
        }

        private void LoadItem()
        {
            GetInventoryItem();            

        }

        private void GetInventoryItem()
        {
            string ident = inventoryIdentText.Text;

            InventoryItem item =  Scout.Core.Service<IInventoryService>()
                .GetItemByLotIdOrSerialNumber(m_persistence.UnitOfWork, ident);

            if(item != null)
            {
                LoadCustomFields(item.CustomFields);
            }            
        }
        private void LoadCustomFields(ItemCustomFields customFields)
        {
            m_customFields = customFields;
            try
            {
                foreach (KeyValuePair<string, string> field in customFields.GetCustomFieldsDictionary())
                {
                    if(!string.IsNullOrEmpty(field.Value))
                        CreateCustomFieldTextBox(field.Key, field.Value);
                }    
            }
            catch(Exception e)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(e.Message, UserMessageType.Exception);
            }                               
        }

        private void CreateCustomFieldTextBox(string fieldName, string fieldValue)
        {
            TextEdit editor = new TextEdit();
            editor.Name =fieldName + "text";
            editor.Dock = DockStyle.Top;
            editor.EnterMoveNextControl = true;
            editor.TabStop = true;
            editor.EditValue = fieldValue;
            customFieldsLayout.AddItem(fieldName, editor);
            editor.DataBindings.Add("Text", m_customFields, fieldName);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(m_persistence.Cancel())
                Close();           
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(m_persistence.Save())
                Close();
        }       
    }
}
