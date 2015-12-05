using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Service
{
    public partial class ServiceStationForm : XtraForm
    {
        private ICollection<ServiceCodeCategory> m_codeCategories;
        private ICollection<StationOutcome> m_stationOutcomes;
        private IUnitOfWork m_unitOfWork;
        private RouteStation m_station;
        private RouteStationConfiguration m_activeConfig;        

        public ServiceStationForm(RouteStation station)
        {
            InitializeComponent();

            m_station = station;
            m_unitOfWork = station.Session;

            Init();
            Bind();
            WireEvents();
        }

        private void Bind()
        {
            stationNameText.DataBindings.Add("EditValue", m_station, "Name");
            stationTypeSelList.DataBindings.Add("EditValue", m_station, "StationType");            
            allowRepairsCheck.DataBindings.Add("Checked", m_station, "AllowRepairs");

            repairComponentsRequiredCheck.DataBindings.Add("Checked", m_station,
                                                           "IsRepairComponentsRequired");
            
            documentsGrid.DataSource = m_station.Documents;


            routeConfigLookUp.Properties.DataSource = 
                Scout.Core.Service<IShopfloorService>().GetAllRouteConfigurations(m_unitOfWork);


            bomConfigurationLookup.DataSource = 
                MaterialService.GetStationBomConfigurations(m_unitOfWork,
                                                            m_station.Shopfloorline);

            Tasks = 
               Scout.Core.Service<IShopfloorService>().GetStationMaterialTasks(m_unitOfWork, m_station);


            validationTypeLookup.DataSource =
                Enum.GetValues(typeof (StepResultValidationType));
        }

        public ICollection<StationMaterialsTask> Tasks
        {
            get {
                return
                    materialTasksGrid.DataSource as
                    XPCollection<StationMaterialsTask>; }

            set { materialTasksGrid.DataSource = value;}
        }

        private void WireEvents()
        {            
            filePathHyperLink.ButtonClick += filePathHyperLink_ButtonClick;
            filePathHyperLink.Click += filePathHyperLink_Click;
            outcomeChkList.ItemCheck += outcomeChkList_ItemCheck;
            failCategoriesChkList.ItemCheck += failCategoriesChkList_ItemCheck;
            stationTabs.SelectedPageChanged += stationTabs_SelectedPageChanged;
            resultListSelList.ButtonClick += resultListSelList_ButtonClick;                  
            routeConfigLookUp.EditValueChanged += routeConfigLookUp_EditValueChanged;
            materialTasksView.InitNewRow += materialTasksView_InitNewRow;
        }

        void materialTasksView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            StationMaterialsTask task = materialTasksView.GetRow(e.RowHandle) as StationMaterialsTask;
            if (task != null)
                task.RouteStation = m_station;            
        }

        void routeConfigLookUp_EditValueChanged(object sender, EventArgs e)
        {
            RouteConfiguration config = routeConfigLookUp.EditValue as RouteConfiguration;
            if(config != null)
            {
                LoadSteps(config);
                return;
            }

            m_activeConfig = null;
            stepsGrid.Enabled = false;
        }

        private void LoadSteps(RouteConfiguration config)
        {
            RouteStationConfiguration stationConfig = m_station.GetConfigurationFor(config);
            if (stationConfig == null)
            {
                stationConfig = m_station.AddConfiguration(config);
            }

            m_activeConfig = stationConfig;
            stepsGrid.Enabled = true;
            stepsGrid.DataSource = stationConfig.Steps;            
        }

        void resultListSelList_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Delete)
            {
                RouteStationStep step = stepsView.GetFocusedRow() as RouteStationStep;
                if(step != null)
                {
                    if(MessageBox.Show("Are you sure that you want to remove this list?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        step.ResultList = null;
                        MessageBox.Show("List Removed");
                    }                                    
                }
            }
        }

        void stationTabs_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(e.Page.Name == "transitionsPage")
            {
                m_station.MapOutcomeTransitions
                    (Scout.Core.Service<IShopfloorService>().GetAllStationOutcomes(m_unitOfWork));

                transitionsGrid.DataSource = m_station.OutcomeTransitions;
                               
                nextStationSelList.DataSource = m_station.ServiceRoute.IncludedStations;                
                nextStationSelList.ValueMember = "This";
                nextStationSelList.DisplayMember = "Name";
            }
        }

        void failCategoriesChkList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            RouteStationFailCategory failCategory = m_station.FailCategories[e.Index];
            if(failCategory != null)
            {
                if(e.State == CheckState.Checked)
                    m_station.FailCategories[e.Index].Active = true;
                if(e.State == CheckState.Unchecked)
                    m_station.FailCategories[e.Index].Active = false;
            }
        }

        void outcomeChkList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            //RouteStationOutcome outcome = m_station.Outcomes[e.Index];
            //if(outcome != null)
            //{
            //    if (e.State == CheckState.Checked)
            //        m_station.Outcomes[e.Index].Active = true;
            //    if (e.State == CheckState.Unchecked)
            //        m_station.Outcomes[e.Index].Active = false;
            //}            
        }

        void filePathHyperLink_Click(object sender, EventArgs e)
        {
            RouteStationDocument document = documentsView.GetFocusedRow() as RouteStationDocument;
            if(document != null)
            {
               document.Document.Open(); 
            }
        }

        void filePathHyperLink_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
           OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            documentsView.ActiveEditor.EditValue = ofd.FileName;
        }

        private void Init()
        {
            stationErrors.DataSource = m_station;                        
            resultLists.Session = m_unitOfWork as XpoUnitOfWork;
           
            LoadCodeCategories();
            LoadOutcomes();            
            
            m_station.Documents.DeleteObjectOnRemove = true;

            stepTypeSelList.DataSource = 
                Scout.Core.Service<IShopfloorService>().GetAllStepTypes(m_unitOfWork);
        }

        private void LoadCodeCategories()
        {
            failCategoriesChkList.Items.Clear();

            m_codeCategories = Scout.Core.Data
                .GetList<ServiceCodeCategory>(m_unitOfWork).All();

            m_station.MapCodeCategories(m_codeCategories);

            foreach (RouteStationFailCategory codeCategory in m_station.FailCategories)
            {
                failCategoriesChkList.Items.Add(codeCategory.Category, codeCategory.Active);
            }
        }

        private void LoadOutcomes()
        {
            outcomeChkList.Items.Clear();
            m_stationOutcomes = Scout.Core.Service<IShopfloorService>().GetAllStationOutcomes(m_unitOfWork);

            foreach (StationOutcome outcome in m_stationOutcomes)
            {
                outcomeChkList.Items.Add(outcome.Label,true);
            }                       
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (stationErrors.HasErrors)
                e.Cancel = true;   
                   
            base.OnClosing(e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void configLayoutButton_Click(object sender, EventArgs e)
        {
            if(m_activeConfig == null)
                return;
            
                StepLayoutForm layoutForm = new StepLayoutForm(m_activeConfig);
                layoutForm.StartPosition = FormStartPosition.CenterScreen;
                layoutForm.ShowDialog();
        }

        private void copyStepsButton_Click(object sender, EventArgs e)
        {
            if(m_activeConfig == null)
                return;

            CopyStepsForm form = new CopyStepsForm(m_activeConfig);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }

        private void deleteMaterialsTaskLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            StationMaterialsTask task =
                materialTasksView.GetFocusedRow() as StationMaterialsTask;
          
            if (task != null)
                task.Delete();
                //Tasks.Remove(task);
        }
    }
}