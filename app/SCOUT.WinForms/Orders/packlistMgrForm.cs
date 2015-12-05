using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.WinForms.Reports;


namespace SCOUT.WinForms.Orders
{
    public partial class PacklistMgrForm : DevExpress.XtraEditors.XtraForm
    {        
        private ICollection<Packlist> m_packlists;
        private IUnitOfWork m_session;
        
        public PacklistMgrForm(SalesOrder salesOrder)
        {
            InitializeComponent();            
            Init(salesOrder);            
        }

        private void Init(SalesOrder salesOrder)
        {
            m_session = salesOrder.Session;
            m_packlists = salesOrder.Packlists;
            LoadPacklistTypes();

            packlistGrid.DataSource = m_packlists;
        }

        private void LoadPacklistTypes()
        {            
            packlistFormatSelList.DataSource = 
                PacklistController.GetAllPacklistControllers();
        }

        private void ShowPacklist()
        {
            PacklistController controller = 
                packlistFormatEditor.EditValue as PacklistController;

            if (controller == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Select packlist type:",
                                                  UserMessageType.Error);
                return;
            }
            
            Packlist packlist = packlistView.GetFocusedRow() as Packlist;
            if (packlist != null)
            {
                controller.LoadReport(packlist.PacklistId);                
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowPacklist();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void Save()
        {
            try
            {
                Scout.Core.Data.Save(m_session);                
            }   
            catch(Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
            }    
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}