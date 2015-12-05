using System;
using System.Data;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Inventory;
using SCOUT.WinForms.Search;
using SCOUT.WinForms.Service;


namespace SCOUT.WinForms
{
    public class InventorySearchButtons : ISearchButtons
    {
        private SearchForm m_SearchForm;

        public void LoadButtons(SearchForm form)
        {
            m_SearchForm = form;
            ToolStripButton button;

            button = new ToolStripButton();
            button.Text = "-Change PN-";
            button.Click += ChangePartNumberButton_Click;
            m_SearchForm.AddToolButton(button);

            button = new ToolStripButton();
            button.Text = "-Edit Tokens-";
            button.Click += EditTokensButton_Click;
            m_SearchForm.AddToolButton(button);

            button = new ToolStripButton();
            button.Text = "-Record Serials-";
            button.Click += RecordSerialsButton_Click;
            m_SearchForm.AddToolButton(button);

            button = new ToolStripButton();
            button.Text = "-View Service History-";
            button.Click += ViewProcessHistory_Click;
            m_SearchForm.AddToolButton(button);

            button = new ToolStripButton();
            button.Text = "-Change Product Grade-";
            button.Click += ChangeProductGrade_Click;
            m_SearchForm.AddToolButton(button);


            button = new ToolStripButton();
            button.Text = "-Edit Unit Configuration-";
            button.Click += EditUnitConfiguration_Click;
            m_SearchForm.AddToolButton(button);


            button = new ToolStripButton();
            button.Text = "-Change SN-";
            button.Click += ChangeSN_Click;
            m_SearchForm.AddToolButton(button);


            button = new ToolStripButton();
            button.Text = "-Edit Custom Fields-";
            button.Click += EditCustomFields_Click;
            m_SearchForm.AddToolButton(button);
        }

        private  void EditCustomFields_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string lotId = row["Lot ID"].ToString();

            InventoryItem item = 
                Scout.Core.Service<IInventoryService>()
                    .GetItemById(Scout.Core.Data.GetUnitOfWork(), lotId);

            if(item != null && item.CustomFields != null)
            {
                ViewLoader.Instance()
                    .CreateFormWithArgs<ItemCustomFieldsEditView>(false, lotId); 
            }
            else
            {
                Scout.Core.UserInteraction.Dialog
                    .ShowMessage("This item does not have any custom fields defined.", UserMessageType.Error);

                return;
            }
        }

        private void ChangeSN_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string lotId = row["Lot ID"].ToString();

            InventoryItem item = 
                Scout.Core.Service<IInventoryService>()
                    .GetItemById(Scout.Core.Data.GetUnitOfWork(), lotId);

            if (item != null)
            {
                ViewLoader.Instance()
                    .CreateFormWithArgs<SerialNumberChangeForm>(false, item);
            }
        }

        private void EditUnitConfiguration_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string lotId = row["Lot ID"].ToString();

            InventoryItem item = 
                Scout.Core.Service<IInventoryService>()
                    .GetItemById(Scout.Core.Data.GetUnitOfWork(), lotId);

            if (item != null)
            {
                UnitConfigurationForm form = new UnitConfigurationForm(item);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        private void ChangeProductGrade_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string lotId = row["Lot ID"].ToString();

            InventoryItem item = 
                Scout.Core.Service<IInventoryService>()
                    .GetItemById(Scout.Core.Data.GetUnitOfWork(), lotId);

            if (item != null)
            {
                InventoryGradeForm form = new InventoryGradeForm(item);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        private void ViewProcessHistory_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string lotId = row["Lot ID"].ToString();

            InventoryItem item = 
                Scout.Core.Service<IInventoryService>()
                    .GetItemRecordById(Scout.Core.Data.GetUnitOfWork(), lotId);

            if (item == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Invalid inventory item", UserMessageType.Error);
                return;
            }

            if (item.SerializedUnit == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("This unit is not serialized and cannot be serviced", UserMessageType.Error);
                return;
            }

            if (item.Processes.Count == 0)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("This unit has no service processes", UserMessageType.Error);
                return;
            }

            RouteProcessViewerForm form = new RouteProcessViewerForm(item);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
         
        }

        private void RecordSerialsButton_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string serialNumber = row["Serial Number"].ToString();

            if (serialNumber != "NON SERIALIZED")
            {
                MessageBox.Show("You cannot record serial numbers for units that are already serialized.",
                                Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NSSerializationForm nsSerializationForm = new NSSerializationForm(row["Lot ID"].ToString());
            nsSerializationForm.StartPosition = FormStartPosition.CenterScreen;
            nsSerializationForm.ShowDialog();
        }

        private void EditTokensButton_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;

            DataRow row = m_SearchForm.SelectedRows[0];
            string serialNumber = row["Serial Number"].ToString();

            if (serialNumber == "NON SERIALIZED")
            {
                MessageBox.Show("Cannot edit tokens for non-serialized unit.", Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TokenTravelerForm tokenTravelerEditForm = new TokenTravelerForm(row);
            tokenTravelerEditForm.ShowDialog();
        }

        private void ChangePartNumberButton_Click(object sender, EventArgs e)
        {
            if (m_SearchForm.SelectedRows.Count <= 0)
                return;
            
            DataRow row = m_SearchForm.SelectedRows[0];
            
            ChangeForm changeForm = new ChangeForm(row["Lot ID"].ToString());
                        
            if (changeForm.ShowDialog() == DialogResult.OK)
            {
                m_SearchForm.RunSearch();
            }

            changeForm.Dispose();
        }
    }
}