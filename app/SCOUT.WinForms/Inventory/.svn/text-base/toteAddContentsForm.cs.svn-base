using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Inventory
{
    public partial class ToteAddContentsForm : DevExpress.XtraEditors.XtraForm
    {
        private Tote m_tote;
        private IUnitOfWork m_session;

        public ToteAddContentsForm(Tote tote)
        {
            m_tote = tote;
            m_session = tote.Session;
            InitializeComponent();
            WireEvents();
            RefreshContents();
        }

        private void WireEvents()
        {
            serialNumberText.Validated += serialNumberText_Validated;
            addButton.Click += addButton_Click;
        }

        void addButton_Click(object sender, EventArgs e)
        {
            serialNumberText_Validated(null,null);
        }

        void serialNumberText_Validated(object sender, EventArgs e)
        {
            if(serialNumberText.Text.Length == 0) return;
            AddItemToTote();
            Restart(); 
        }

        private void AddItemToTote()
        {
            InventoryItem item = Scout.Core.Service<IInventoryService>().GetItemBySN(m_tote.Session, serialNumberText.Text);
            if (item != null)
            {
                try
                {
                    Scout.Core.Service<IInventoryService>().AddItemToTote(m_tote, item);
                    Scout.Core.Data.Save(m_session);
                    RefreshContents();
                }
                catch (Exception ex)
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                }
            } 
            else
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Invalid inventory item", UserMessageType.Error);    
            }   
        }

        private void RefreshContents()
        {
            contentsGrid.DataSource = m_tote.Contents;
        }

        private void Restart()
        {
            serialNumberText.Text = "";
            serialNumberText.Focus();
        }
    }
}