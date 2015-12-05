using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Printing;

namespace SCOUT.WinForms.Providers
{
    public class DefaultUserInteractionProvider : IUserInteractionProvider
    {
        private IDialogService m_dialogService;              
        private IPrintingService m_printingService;

        public IPrintingService Printing
        {
            get
            {
                if(m_printingService == null)
                    m_printingService = new PrintingService();

                return m_printingService;
            }
            set { m_printingService = value; }
        }

        public IDialogService Dialog
        {            
            get
            {
                if (m_dialogService == null)
                    m_dialogService =  new DialogService();

                return m_dialogService;
            }
            set
            {
                m_dialogService = value;
            }
        }

        public IViewService Views
        {
            get { throw new NotImplementedException(); }
        }

        public void ShowMessage(string msg, UserMessageType type)
        {
            Dialog.ShowMessage(msg, type);
        }        
    }
}