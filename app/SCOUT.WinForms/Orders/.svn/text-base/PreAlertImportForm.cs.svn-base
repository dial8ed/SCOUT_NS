using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Orders
{
    public partial class PreAlertImportForm : DevExpress.XtraEditors.XtraForm
    {
        private List<PartToImport> m_importList;
        private PurchaseOrder m_purchaseOrder;              
        private IPreAlert m_preAlert;

        public PreAlertImportForm(PurchaseOrder purchaseOrder)
        {
            InitializeComponent();
            WireEvents();
            LoadLists();
            m_purchaseOrder = purchaseOrder;
        }

        private void LoadLists()
        {
            preAlertTypeSelList.Properties.DataSource = OrderService.GetPreAlertTypeList();            
        }

        public IPreAlert PreAlert
        {
            get { return m_preAlert; }
            set
            {
                m_preAlert = value;

                if(m_preAlert != null)
                {
                    m_preAlert.PurchaseOrder = m_purchaseOrder;
                    m_purchaseOrder.PreAlertType = m_preAlert.GetType().ToString();
                }
            }
        }

        private void WireEvents()
        {
            fileEdit.ButtonClick += fileEdit_ButtonClick;
            preAlertTypeSelList.EditValueChanged += preAlertTypeSelList_EditValueChanged;
        }

        void preAlertTypeSelList_EditValueChanged(object sender, EventArgs e)
        {
            IPreAlert preAlert = preAlertTypeSelList.EditValue as IPreAlert;
            if(preAlert != null)
            {               
                PreAlert = preAlert;
            }            
        }

        void fileEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!PreAlertTypeIsSelected()) return;

            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {               
                FileInfo file = new FileInfo(@ofd.FileName);
                if(file.Exists)
                {
                    dirPathText.Text = file.Directory.FullName;
                    fileNameText.Text = file.Name;
                    fileEdit.Text = ofd.FileName;
                    LoadDataFromFile(file);
                }
            }
        }

        private bool PreAlertTypeIsSelected()
        {
            if(preAlertTypeSelList.EditValue == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "Pre Alert type must be selected before loading the file.",UserMessageType.Error);

                return false;
            }

            return true;
        }

        private void LoadDataFromFile(FileInfo file)
        {            
            //try
            //{
                m_preAlert.LoadFromFile(file);                             
                
                gridControl1.DataSource = m_preAlert.DataTable;

                ValidatePreAlertWithStatusWindow();

                gridControl2.DataSource = m_preAlert.ImportList;
     
            //} 
            //catch(Exception ex)
            //{
            //    UserMessagingService.RaiseMessage(ex.Message, UserMessageType.Error);    
            //}                     
        }

        private void ValidatePreAlertWithStatusWindow()
        {
            PreAlertImportProgressForm validationProgress = new PreAlertImportProgressForm(m_preAlert.Validator);
            validationProgress.StartPosition = FormStartPosition.CenterParent;
            validationProgress.ShowDialog();
        }

        private void importLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {           
            if(m_preAlert.Import())
                Close();                    
        }
    }
}