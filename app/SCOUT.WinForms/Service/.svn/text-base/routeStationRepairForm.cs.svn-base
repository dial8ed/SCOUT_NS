using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.WinForms.Core;


namespace SCOUT.WinForms.Service
{
    public partial class RouteStationRepairForm : XtraForm
    {
        private RouteStationFailure m_failure;
        
        public RouteStationRepairForm(RouteStationFailure failure)
        {
            InitializeComponent();
            m_failure = failure;            
            InitLists();
            Bind();
            WireEvents();
            SetupEnvironment();
        }

        private void SetupEnvironment()
        {
            repairsView.ExpandAllGroups();
        }


        private void WireEvents()
        {
            replaceComponentsEditor.ButtonClick += replaceComponentsEditor_ButtonClick;
            repairLookup.EditValueChanged += repairLookup_EditValueChanged;            
        }

        void repairLookup_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit edit = (LookUpEdit) sender;

            RepairAction action =
                (RepairAction)
                edit.Properties.GetDataSourceRowByKeyValue(edit.EditValue);
           
            if(action == null)
                return;

            if((action != RepairAction.None))
                AddReplacementComponents();
        }

        void replaceComponentsEditor_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e == null)
                return;

            switch(e.Button.Kind)
            {
                case ButtonPredefines.Plus:
                    AddReplacementComponents();
                    break;                
            }                
        }


        /// <summary>
        /// Opens the component replacement form
        /// </summary>
        private void AddReplacementComponents()
        {
            RouteStationRepair repair = repairsView.GetFocusedRow() as RouteStationRepair;
            if(repair != null)
            {
                ViewLoader.Instance()
                    .CreateFormWithArgs<RepairComponentReplacementForm>(false, repair);
            }
        }

        private void InitLists()
        {
            repairLookup.DataSource = Enum.GetValues(typeof (RepairAction));
            componentLookup.DataSource = m_failure.StationProcess.Item.Part.ServiceCommodity.Components;
        }

        private void Bind()
        { 
            failureText.Text = m_failure.FailCode.Code + " " + m_failure.FailCode.Description;
            repairsGrid.DataSource = m_failure.Repairs;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void removeRepairLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            RouteStationRepair repair = repairsView.GetFocusedRow() as RouteStationRepair;
            if(repair != null)
            {
                if(VerifyDelete(repair))
                    m_failure.Repairs.Remove(repair);                                   
            }
        }

        private bool VerifyDelete(RouteStationRepair repair)
        {
            if (repair.HasConsumedRepairParts)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Repair cannot be deleted until the parts consumed are reversed", UserMessageType.Error);
                return false;
            }

            return (MessageBox.Show("Are you sure you want to delete this repair?",
                                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes);

        }

        private void createNoRepairRecord_OpenLink(object sender, OpenLinkEventArgs e)
        {
           PartReplacementService.CreateNoRepairRecord(m_failure);
        }

        private void createNoPartRecordLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            RouteStationRepair repair =
                repairsView.GetFocusedRow() as RouteStationRepair;

            if (repair != null)
                PartReplacementService.CreateNoPartRecord(repair);
        }
    }
}