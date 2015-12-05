using System;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Inventory
{
    public partial class SerialNumberChangeForm : DevExpress.XtraEditors.XtraForm
    {
        private InventoryItem m_item;

        public SerialNumberChangeForm(InventoryItem item)
        {
            InitializeComponent();
            m_item = item;
            Bind();
            WireEvents();
        }

        private void Bind()
        {
            lotIdText.DataBindings.Add("EditValue", m_item, "LotId");            
            currentSNText.Text = m_item.SerialNumber;
            newSNText.Text = m_item.SerialNumber;
        }

        private void WireEvents()
        {
            okButton.Click += okButton_Click;
            cancelButton.Click += cancelButton_Click;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (Scout.Core.Service<IInventoryService>().ChangeSerialNumber(m_item, newSNText.Text))
            {
                Scout.Core.Service<IInventoryService>().PrintTravelerLabel(m_item);
                Scout.Core.UserInteraction.Dialog.ShowMessage("SN Changed", UserMessageType.Information);
                Close();
            }
        }
    }
}