using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.Core.Messaging;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class ServiceSetupForm : XtraForm
    {        
        public ServiceSetupForm()
        {
            InitializeComponent();           
            WireEvents();
        }

        private void WireEvents()
        {
            resultListsLink.LinkClicked += resultListsLink_LinkClicked;
            commLink.LinkClicked += commLink_LinkClicked;
            stationOutcomesLink.LinkClicked += stationOutcomesLink_LinkClicked;
            stationsLink.LinkClicked += stationsLink_LinkClicked;
            openConditionManagerLink.LinkClicked += openConditionManagerLink_LinkClicked;
            okButton.Click += okButton_Click;
            Closing += ServiceSetupForm_Closing;           
        }

        void openConditionManagerLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActiveEditor = LoadControl<ShopfloorConditionManager>();
        }

        void ServiceSetupForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ActiveEditor != null)
            {
                if(ActiveEditor.UnitOfWork.HasChanges())
                {
                    e.Cancel = true;
                }
            }
        }

        void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void stationsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActiveEditor = LoadControl<StationManager2>();
        }

        void stationOutcomesLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActiveEditor = LoadControl<StationOutcomeManager2>();
        }

        void commLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActiveEditor = LoadControl<ServiceCommodityManager>();  
        }

        void resultListsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           ActiveEditor = LoadControl<ResultListManager2>();
        }

        public PersistentBaseControl ActiveEditor
        {
            get
            {
                if (activeEditorPanel.Controls.Count > 0)
                    return activeEditorPanel.Controls[0] as PersistentBaseControl;
                else
                    return null;
            }
            set
            {
                if (value == null)
                    return;

                value.CancelChanges += ActiveEditor_CancelChanges;
                activeEditorPanel.Controls.Add(value);                 
            }
        }

        void ActiveEditor_CancelChanges(object sender, EventArgs args)
        {
            RemoveActiveEditor();                       
        }

        private void RemoveActiveEditor()
        {
            if (ActiveEditor != null)
                ActiveEditor.CancelChanges -= ActiveEditor_CancelChanges;

            activeEditorPanel.Controls.Clear();
        }

        private T LoadControl<T>() where T : Control 
        {            
            if(ActiveEditor != null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Save or Cancel the current editor", UserMessageType.Warning);
                return default(T);
            }

            // Create new instance of editor to be displayed
            T control = Activator.CreateInstance(typeof(T)) as T;
            
            // Add the control
            if(control != null)
            {
                control.Dock = DockStyle.Fill;
                return control;
            }

            throw new NullReferenceException("Control was not created.");            
        }

        private void configGroupsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ActiveEditor = LoadControl<QuestionConfigGroupManager2>();
        }
    }
}