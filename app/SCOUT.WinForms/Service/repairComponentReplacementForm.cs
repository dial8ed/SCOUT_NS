using System;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms.Service
{
    public partial class RepairComponentReplacementForm : XtraForm
    {
        private RouteStationRepair m_repair;        
        private ReplacementComponentFacts m_facts;
        private string m_repairAction;        
        private IUnitOfWork m_session;
        
        
        public RepairComponentReplacementForm(RouteStationRepair repair)
        {
            InitializeComponent();            
            m_session = repair.Session;
            m_repair = repair;            
            Bind();
            WireEvents();
        }


        private void WireEvents()
        {
            cancelButton.Click +=cancelButton_Click;
            saveAndCloseButton.Click += saveAndCloseButton_Click;
            saveAndNewButton.Click += saveAndNewButton_Click;
            partInText.Validated += partInText_Validated;
            partOutText.Validated += partOutText_Validated;
            serialNumberInText.Validated += serialNumberInText_Validated;
            serialNumberOutText.Validated += serialNumberOutText_Validated;
            componentTypeLookup.EditValueChanged += componentTypeLookup_EditValueChanged;
            removeLink.Click += removeLink_Click;
        }

        void removeLink_Click(object sender, EventArgs e)
        {
            RepairComponent component = componentsView.GetFocusedRow() as RepairComponent;
            if (component != null)
                m_repair.Components.Remove(component);
        }

        void componentTypeLookup_EditValueChanged(object sender, EventArgs e)
        {
            ServiceCommodityComponent commodityComponent =
                componentTypeLookup.EditValue as ServiceCommodityComponent;

            m_facts.Component = commodityComponent;           
        }

        void serialNumberOutText_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(serialNumberOutText.Text)) return;
            ToUpper(serialNumberOutText);
            m_facts.SerialNumberOut = serialNumberOutText.Text;
        }

        void serialNumberInText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serialNumberInText.Text)) return;
            ToUpper(serialNumberInText);
            m_facts.SerialNumberIn = serialNumberInText.Text;
        }

        private void ToUpper(TextEdit edit)
        {
            edit.Text = edit.Text.ToUpper();
        }

        void partOutText_Validated(object sender, EventArgs e)
        {
            if(partOutText.Text.Length == 0) return;

            ToUpper(partOutText);

            m_facts.PartOut = 
                PartService.GetPartByPartNumber(m_session, partOutText.Text);

            if (m_facts.PartOut == null)
                ShowInvalidPartMessage(partOutText.Text);
            
        }

        private void ShowInvalidPartMessage(string partNumber)
        {
            string msg = string.Format("{0} is not a valid part number", partNumber);
            Scout.Core.UserInteraction.Dialog.ShowMessage(msg, UserMessageType.Error);          
        }

        void partInText_Validated(object sender, EventArgs e)
        {
            if (partInText.Text.Length == 0) return;

            ToUpper(partInText);
           
            m_facts.PartIn =
                PartService.GetPartByPartNumber(m_session, partInText.Text);

            if (m_facts.PartIn == null)
                ShowInvalidPartMessage(partInText.Text);
            
        }

      
        void saveAndNewButton_Click(object sender, EventArgs e)
        {
            SaveAndNew();
        }

        private bool Save()
        {
            if (!new PartReplacementValidator(m_facts).Validated())
                return false;

            if(MaterialService.ConsumeMaterial(m_facts))           
                return PartReplacementService.Save(m_repair, m_facts);

            return false;
        }

        private void SaveAndNew()
        {
            if (Save())            
                New();
        }

        private void New()
        {
            CreateFacts();
            partInText.Text = "";
            partOutText.Text = "";
            serialNumberOutText.Text = "";
            serialNumberInText.Text = "";
            partOutText.Focus();

            componentsGrid.DataSource = m_repair.Components;

            componentTypeLookup.EditValue = null;

            componentTypeLookup.Focus();
        }

        void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            SaveAndClose();                       
        }

        private void SaveAndClose()
        {
            if(Save())
                Close();            
        }

        private void Bind()
        {
            CreateFacts();
            m_repairAction = m_repair.Repair.ToString();
            actionText.Text = m_repairAction;

            componentTypeLookup.Properties.DataSource = 
                m_repair.Item.ServiceCommodity.Components;

            componentsGrid.DataSource = m_repair.Components;
        }


        private void CreateFacts()
        {
            m_facts = new ReplacementComponentFacts(m_repair);
            m_facts.UnitOfWork = m_session;
            m_facts.Shopfloorline = m_repair.Failure.Item.Shopfloorline;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createNoPartRecordLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            if (m_repair != null)
            {
                partInText.Text = "NoPart";
                partInText_Validated(this,null);
                partOutText.Text = "NoPart";
                partOutText_Validated(this, null);
                serialNumberOutText.Text = "NA";
                serialNumberInText.Text = "NA";
            }                
        }
    }
}