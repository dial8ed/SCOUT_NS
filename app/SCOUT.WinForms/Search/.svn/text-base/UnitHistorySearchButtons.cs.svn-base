using System;
using System.Data;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Service;


namespace SCOUT.WinForms.Search
{
    public class UnitHistorySearchButtons: ISearchButtons
    {
        private  SearchForm m_SearchForm;

        public void LoadButtons(SearchForm form)
        {
            m_SearchForm = form;
            ToolStripButton button;

            button = new ToolStripButton();
            button.Text = "-View Service History-";
            button.Click += ViewProcessHistory_Click;
            m_SearchForm.AddToolButton(button);

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
    }
}