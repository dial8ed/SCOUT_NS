using System;
using DevExpress.Xpo;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Inventory
{
    public partial class ToteContentsPutAwayForm : DevExpress.XtraEditors.XtraForm
    {
        private Tote m_tote;
        private ToteContentsTransferCommandArguments m_args;        
        private IUnitOfWork m_session;

        public ToteContentsPutAwayForm(ToteContentsTransferCommandArguments args)            
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
            locationLookup.GotFocus += toteLookup_GotFocus;
        }

        void toteLookup_GotFocus(object sender, EventArgs e)
        {
            locationLookup.ShowPopup();
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
            locationLookup.Properties.DataSource = m_tote.Domain.RackLocations;          
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            RackLocation rackLocation = locationLookup.EditValue as RackLocation;
           
            if (rackLocation == null)
                return;

            try
            {
                bool removeFromTote = removeitemsFromToteCheck.Checked;

                Scout.Core.Service<IToteService>().PutSelectedItemsInLocation
                    (m_args.ItemsToMove, rackLocation, removeFromTote);

                Scout.Core.Data.Save(m_session);
                
                string msg = "Put away complete";

                if (removeFromTote)
                    msg += " and the items have been removed from the tote";
                
                Scout.Core.UserInteraction.Dialog.ShowMessage(msg, UserMessageType.Information);

                Close();
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
            }
        }
    }
}