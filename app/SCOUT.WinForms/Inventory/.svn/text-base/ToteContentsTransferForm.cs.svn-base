using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Inventory
{
    public partial class ToteContentsTransferForm : DevExpress.XtraEditors.XtraForm
    {
        private Tote m_tote;
        private IToteService m_totes = Scout.Core.Service<IToteService>();
        private IAreaService m_areas = Scout.Core.Service<IAreaService>();

        private ToteContentsTransferCommandArguments m_args;        
        private IUnitOfWork m_session;

        public ToteContentsTransferForm(ToteContentsTransferCommandArguments args)            
        {
            InitializeComponent();
            
            m_tote = args.CurrentTote;
            m_args = args; 

            Init();
            Bind();
            WireEvents();            
        }

        private void WireEvents()
        {
            cancelButton.Click +=cancelButton_Click;
            transferButton.Click += transferButton_Click;
            toteLookup.GotFocus += toteLookup_GotFocus;
        }

        void toteLookup_GotFocus(object sender, EventArgs e)
        {
            toteLookup.ShowPopup();
        }

        private void Init()
        {
            m_session = m_tote.Session;

            if(m_session == null)
                throw new NotImplementedException("Tote.Session must be of type UnitOfWork!");

        }

        private void Bind()
        {
            contentsPivot.DataSource = m_args.ItemsToMove;
            toteNameText.Text = m_tote.Label;
            domainText.Text = m_tote.Domain.ToString();
            toteLookup.Properties.DataSource = m_areas.GetAllTotes(m_session);            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            Tote destinationTote = toteLookup.EditValue as Tote;

            if (destinationTote == null)
                return;
            try
            {
                m_totes.TransferSelectedItemsToNewTote(m_args.ItemsToMove, destinationTote);

                Scout.Core.Data.Save(m_session);
                
                Scout.Core.UserInteraction.Dialog.ShowMessage
                    ("Transfer Complete", UserMessageType.Information);                

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}