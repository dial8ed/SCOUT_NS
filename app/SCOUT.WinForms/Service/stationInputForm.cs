using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Mvc;
using SCOUT.Core.Services;
using SCOUT.WinForms.Controls;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Materials;
using SCOUT.WinForms.Views;
using IPartsConsumptionView = SCOUT.Core.Modules.Materials.IPartsConsumptionView;


namespace SCOUT.WinForms.Service
{
    public partial class StationInputForm : PassiveViewBase, IStationTaskView
    {
        private InventoryItem m_item;
        private ICollection<StationOutcome> m_outcomes;
        private RouteStationProcess m_process;
        private RouteStation m_routeStation;
        private IUnitOfWork m_session;
        private bool m_loadingOutcomes = false;

        private StationTaskModel m_taskModel = null;
        private StationTaskController m_taskController;

        private EventHandler<ServiceCodeEventArgs> m_codeByCategoryReturnHandler;

        private PartsConsumptionView m_consumptionView;

        private ViewHelper.ProcessLayoutItem
            m_processLayoutItem;

        private StationInspectionTaskView m_inspectionView;
        private ControlStateController<RouteStationProcess> m_cancelControlStateController;


        public StationInputForm()
        {
            InitializeComponent();
            Init();            
            WireEvents();
                       
            m_codeByCategoryReturnHandler = CodeByCategoryReturnHandler;

            snText.Focus();

        }

        private void CodeByCategoryReturnHandler(object sender, ServiceCodeEventArgs serviceCodeEventArgs)
        {
            m_process.AddFailure(serviceCodeEventArgs.Code, serviceCodeEventArgs.Comments);
        }


        private StationOutcome Outcome
        {
            get { return outcomeSelList.EditValue as StationOutcome; }
            set
            {
                if(m_loadingOutcomes)
                    return;

                if (value != null)
                    ProcessOutcome(value);
            }
        }


        public StationInputForm(InventoryItem item)
        {
            InitializeComponent();
            Init();
            WireEvents();
            m_item = item;
            snText.Text = item.SerialNumber;
        }


        private void Init()
        {
            m_session = Scout.Core.Data.GetUnitOfWork();
            m_item = null;
            m_process = null;
            m_routeStation = null;
            tasksGrid.DataSource = null;
            inspectionsGrid.DataSource = null;            
            ClearEditors();
            snText.Focus();
        }

        private void SetupCancelButtonStateController(RouteStationProcess process)
        {
            m_cancelControlStateController =                 
                new ControlStateController<RouteStationProcess>(cancelButton, process);

            m_cancelControlStateController
                .AddDisableCondition((p) => p.HasNewMaterialsConsumed());

            m_cancelControlStateController
                .AddDisableCondition((p) => p.HasReversedMaterialsConsumed());

            m_cancelControlStateController.SetState(process);
        }

        private void WireEvents()
        {
            outcomeSelList.EditValueChanged += outcomeSelList_EditValueChanged;
            snText.Validated += lotIdText_Validated;
            documentsList.DoubleClick += documentsList_DoubleClick;
            repairButton.Click += repairButton_Click;
            partDocumentsList.DoubleClick += partDocumentsList_DoubleClick;
            viewProcessHistoryLink.OpenLink += viewProcessHistoryLink_OpenLink;
            tasksGrid.DoubleClick += tasksGrid_DoubleClick;
            deleteInspectionResultLink.Click += deleteInspectionResultLink_Click;
            editInspectionResultLink.Click += editInspectionResultLink_Click;
            repairFailureLink.Click += repairFailureLink_Click;            
        }

        void repairFailureLink_Click(object sender, EventArgs e)
        {
            RouteStationFailure failure = failuresView.GetFocusedRow() as RouteStationFailure;
            if(failure != null && failure.FailCode != null)
                LoadRepairView(failure);                
        }

   
        void editInspectionResultLink_Click(object sender, EventArgs e)
        {
            StationInspectionTaskResult result =
                    inspectionsView.GetFocusedRow() as StationInspectionTaskResult;

            if (result == null)
                return;

            if (EditInspectionResult != null)
                EditInspectionResult(this, new SingleChoiceActionRequestEventArgs<StationInspectionTaskResult>(result));
   
        }

        void deleteInspectionResultLink_Click(object sender, EventArgs e)
        {
            StationInspectionTaskResult result =
                inspectionsView.GetFocusedRow() as StationInspectionTaskResult;

            if(result == null)
                return;

            if(DeleteInspectionResult != null)
                DeleteInspectionResult(this, new SingleChoiceActionRequestEventArgs<StationInspectionTaskResult>(result));
            
        }

        void tasksGrid_DoubleClick(object sender, EventArgs e)
        {
            IStationTask task = tasksView.GetFocusedRow() as IStationTask;
            if(task != null)
            {
                if(RunTask != null)
                    RunTask(this, new SingleChoiceActionRequestEventArgs<IStationTask>(task));
            }
        }

 
        void viewProcessHistoryLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            ViewProcessHistory();
        }

     
        private void documentsList_DoubleClick(object sender, EventArgs e)
        {
            RouteStationDocument doc =
                documentsList.SelectedItem as RouteStationDocument;
            if (doc != null)
                doc.Document.Open();
        }


        private void partDocumentsList_DoubleClick(object sender, EventArgs e)
        {
            PartDocument doc = partDocumentsList.SelectedItem as PartDocument;
            if (doc != null)
                doc.Document.Open();
        }


        private void lotIdText_Validated(object sender, EventArgs e)
        {
            if (snText.Text.Length == 0)
                return;

            LoadUnitBySN(snText.Text);
        }


        private void LoadUnitBySN(string text)
        {
            // Find the unit by serial number
            m_item = new InventoryLocator().LocateOrWarn(m_session,text);

            if (m_item == null)
            {
                Init();
                return;
            }
                           
            LoadUnitForProcess();
            LoadPartAttributes();
            
        }


        private void LoadTaskController(RouteStationProcess process)
        {
            if(m_taskController != null)
            {
                m_taskController.Dispose();                
                m_taskController = null;
                m_taskModel = null;
            }
                          
            tasksGrid.DataSource = null;
            inspectionsGrid.DataSource = null;

            m_taskModel = 
                new StationTaskModel(process);

            m_taskController =
                new StationTaskController(m_taskModel, this);

        }


        private void LoadUnitForProcess()
        {
            if (m_item == null) return;

            if (ItemIsOnHold(m_item))
                return;

            if (!ItemHasServiceCommodity(m_item))
                return;
           
            if (m_item.CurrentProcess != null)
            {
                m_process = m_item.CurrentProcess;
                LoadEditors(m_process.Station);
                LoadTaskController(m_item.CurrentProcess);
                LoadPartsUsed(m_item.LotId);
                SetupCancelButtonStateController(m_process);
                return;
            }


            Scout.Core.UserInteraction.Dialog.ShowMessage(
                "This unit is not currently on a process route",
                UserMessageType.Warning);        
        }

        private void LoadPartsUsed(string lotId)
        {
            //var uow = Scout.Core.Data.GetUnitOfWork();
            var datasource = MaterialRepository.GetMaterialsConsumed(m_session, lotId);
            partsUsedGrid.DataSource = datasource;
        }


        private bool ItemIsOnHold(InventoryItem item)
        {
            if (item.Hold != null && !item.Hold.AllowStationData)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "This unit is on hold and cannot be processed.",
                    UserMessageType.Error);
                return true;
            }

            if(item.Hold != null && item.Hold.AllowStationData)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "This unit is on hold. Data can be inputted and saved, but no outcome routing is available.",
                    UserMessageType.Warning);                
            }

            return false;
        }


        private void LoadPartAttributes()
        {
            if (m_item.Part.Attributes != null)
            {
                partAttributesControl.DataSource = m_item.Part;

                // Set the attribute label above the value.
                partAttributesControl.TextLocation = Locations.Top;
            }
            else
            {
                partAttributesControl.DataSource = null;
            }
        }


        private bool ConfigDefinedForPart(Part part)
        {
            RouteStationConfiguration config =
                m_process.Station.GetConfigurationFor(part);



            if (config == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "There is not a step configuration loaded for this part.",
                    UserMessageType.Warning);

                return false;
            }

            m_process.MapStepsToResults(config);

            return true;
        }


        private bool ItemHasServiceCommodity(InventoryItem item)
        {
            if (item.Part.ServiceCommodity == null)
            {
                MessageBox.Show(
                    "This part does not have a service commodity defined and cannot be serviced.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }


        private void outcomeSelList_EditValueChanged(object sender, EventArgs e)
        {
            var outcome = outcomeSelList.EditValue as StationOutcome;

            Outcome = outcome;
        }


        private void ProcessOutcome(StationOutcome outcome)
        {
            // TODO: Decouple this method from the form
            // Use a state pattern

            // If the item is on hold, but allows station data
            // then update the outcome, but no do not perform routing.
            if(m_item.Hold != null && m_item.Hold.AllowStationData)
            {
                m_process.StationOutcome = outcome;
                return;
            }

            if (!IsTransitionValid())
            {
                outcomeSelList.EditValue = null;
                return;
            }
                
            StationOutcomeTransition transition = GetTransition(outcome.Label);

            if (transition.EndProcessRoute)
                SetupEndProcess(outcome);
            else
                SetupNextStation(outcome);
        }


        private bool IsTransitionValid()
        {
            if (IsMissingRequiredFields())
                return false;

            return true;
        }


        private bool IsMissingRequiredFields()
        {
            // Guard
            if (outcomeSelList.EditValue == null)
            {
                return true;
            }

            // Only validate required fields if the station outcome is pass or fail
            StationOutcome outcome = (StationOutcome)outcomeSelList.EditValue;
            if(outcome.Label.Equals("NOT PERFORMED"))
                return false;

                       
            // Verify required fields are valid prior to outcome selection.
            if (!m_process.ValidRequiredFields() )
            {
                MessageBox.Show(
                    "This unit cannot be routed because required results are missing.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                outcomeSelList.EditValue = null;
                return true;
            }


            // Verify all repairs are valid             
            if(m_process.Station.AllowRepairs)
            foreach (RouteStationFailure failure in m_process.AllProcessFailures)
            {
                foreach (RouteStationRepair repair in failure.Repairs)
                {
                    if (repair.Repair != RepairAction.None && m_process.Station.IsRepairComponentsRequired)
                    {
                        if (repair.Components.Count == 0)
                        {
                            string msg = "Repair action [ " + repair.Repair +
                                         " ] for failure [ " +
                                         repair.Failure.FailCode +
                                         " ] requires a component tracking entry.";

                            Scout.Core.UserInteraction.Dialog.ShowMessage(msg, UserMessageType.Validation);
                            return true;
                        }
                    }
                }
            }

   
            if (m_taskController.HasOpenTasks())
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("There are open tasks that must be completed before moving to the next station", UserMessageType.Validation);
                return true;
            }

            return false;
        }


        private StationOutcomeTransition GetTransition(string outcome)
        {
            StationOutcomeTransition transition;
            transition = m_routeStation.TransitionForOutcome(outcome);
            if (transition == null)
            {
                MessageBox.Show(
                    "Error Getting transition for outcome " + outcome,
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return null;
            }

            return transition;
        }


        private void SetupEndProcess(StationOutcome outcome)
        {
            m_process.StationOutcome = outcome;
            m_process.NextStation = null;
            nextStationText.Text = "End of process";
        }


        private void SetupNextStation(StationOutcome outcome)
        {
            if (m_routeStation.NextStationForOutcome(outcome.Label) == null)
            {
                MessageBox.Show(
                    "There is not a station transition defined for this outcome",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            m_process.StationOutcome = outcome;
            m_process.NextStation =
                m_routeStation.NextStationForOutcome(outcome.Label);
            nextStationText.Text = m_process.NextStationName;
        }


        private void Bind()
        {
            stationText.Text = m_routeStation.Station.Name;
            routeText.Text = m_routeStation.ServiceRoute.Name;
            repairGroup.Enabled = m_process.Station.AllowRepairs;
            programText.Text = m_process.Item.ShopfloorProgram;
            conditionsText.Text = m_process.Item.ShopfloorConditions;

            if(m_process.Station.AllowRepairs)
                repairFailureContainer.Visibility = LayoutVisibility.Always;
            else
                repairFailureContainer.Visibility = LayoutVisibility.Never;

        }           


        private void LoadEditors(RouteStation station)
        {
            // Guard
            if (station == null)
                return;

            ClearEditors();
            m_routeStation = station;

            Bind();

            LoadOutcomes();
            LoadDocuments();
            LoadFailures();
            processBinding.Clear();
            processBinding.ResetBindings(false);

            // Verify there is a step configuration 
            // for this part at this station
            if (!ConfigDefinedForPart(m_item.Part))
                return;

            // Sort the collection by seq no.            
            m_process.SortResultsBySeqNo();

            try
            {
                stepsLayout.SuspendLayout();
                foreach (RouteStationResult result in m_process.Results)
                {
                    processBinding.Add(result);

                    Control control;

                    if (result.Step.ResultList != null)
                    {
                        control = new StationStepLookUpMapper().MapFrom(result);
                        stepsLayout.AddItem(result.Step.DisplayPrompt, control);
                    }
                    else
                    {
                        control = new StationStepTextEditMapper().MapFrom(result);
                        stepsLayout.AddItem(result.Step.DisplayPrompt, control);
                    }

                    // Additional Layout Item Formatting
                    LayoutControlItem layoutItem =
                        stepsLayout.GetItemByControl(control);
                    if (layoutItem != null)
                    {
                        //Make the required fields captions bold.
                        if (result.Step.Required)
                            layoutItem.AppearanceItemCaption.Font =
                                new Font("Verdana", 8.25F, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message,
                                                  UserMessageType.Error);
            }
            finally
            {
                stepsLayout.ResumeLayout(true);
            }
        }


        private void LoadDocuments()
        {
            documentsList.DataSource = m_routeStation.Documents;
            documentsList.ImageIndexMember = "ImageIndex";

            partDocumentsList.DataSource = m_item.Part.Documents;
            partDocumentsList.ImageIndexMember = "ImageIndex";
        }


        private void LoadOutcomes()
        {
            m_loadingOutcomes = true;
            m_outcomes = Scout.Core.Service<IShopfloorService>().GetAllStationOutcomes(m_session);

            //m_outcomes.DisplayableProperties = "This;Label";
            outcomeSelList.Properties.DataSource = m_outcomes;
            outcomeSelList.Properties.DisplayMember = "Label";
            outcomeSelList.Properties.ValueMember = "This";
            m_loadingOutcomes = false;
        }


        private void LoadFailures()
        {
            // Filter the fail codes by model if the part has a model defined.
            if (m_item.Part.Model != null)
                failCodeLookup.DataSource =
                    m_item.Part.ServiceCommodity.ServiceCodesByModel(
                        m_item.Part.Model);
            else
                failCodeLookup.DataSource =
                    m_item.Part.ServiceCommodity.ServiceCodes;

            failuresGrid.DataSource = m_process.Failures;
            repairFailuresGrid.DataSource = m_process.AllProcessFailures;
                                
        }

        private void ClearEditors()
        {
            stepsLayout.SuspendLayout();
            stepsLayout.Controls.Clear();
            stepsLayout.Clear();
            failCodeLookup.DataSource = null;
            failuresGrid.DataSource = null;
            repairFailuresGrid.DataSource = null;
            documentsList.DataSource = null;
            outcomeSelList.Properties.DataSource = null;
            outcomeSelList.EditValue = null;
            nextStationText.Text = "";
            stationText.Text = "";
            routeText.Text = "";
            programText.Text = "";
            snText.SelectAll();
            partAttributesControl.DataSource = null;
            stepsLayout.ResumeLayout(true);
            tabControl.SelectedTabPage = stepsTab;
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {               
            if (Cancel())
                return;
          
            try
            {
                if (Scout.Core.Service<IShopfloorService>().ProcessStation(m_process))
                {
                    Scout.Core.Data.Save(m_session);                    
                    VerifySaveClose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "There was an error saving the data for this station " +
                    ex.Message);
            }
        }


        private bool Cancel()
        {
            if (m_item == null)
                return true;

            // Validate the item is still at this station before saving the results.
            Scout.Core.Data.GetUnitOfWork().DropIdentityMap();

            InventoryItem compareItem =
                Scout.Core.Service<IInventoryService>().GetItemBySN(Scout.Core.Data.GetUnitOfWork(),
                                             m_item.SerialNumber);

            if (compareItem == null || compareItem.CurrentProcess == null ||
                compareItem.CurrentProcess.Id != m_process.Id)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "This unit is no longer at this station. Please close and re-open the form.",
                    UserMessageType.Error);

                return true;
            }
            /////---->


            if (m_process.ValidRequiredFields() &&
                m_process.StationOutcome == null)
            {
                return
                    (MessageBox.Show(
                         "All required fields have been populated, but a station outcome is missing. " +
                         Environment.NewLine + "Are you sure you want to save?",
                         Application.ProductName, MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question) != DialogResult.Yes);
            }

            if (m_process.Station.AllowRepairs && m_process.HasOpenFailures())
            {
                return
                    (MessageBox.Show(
                         "There are failures that do not have repairs." +
                         Environment.NewLine +
                         "Are you sure you want to continue?",
                         Application.ProductName, MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question) != DialogResult.Yes);
            }

            return false;
        }


        private void VerifySaveClose()
        {
            MessageBox.Show("Save Complete.", Application.ProductName,
                            MessageBoxButtons.OK, MessageBoxIcon.Question);

            New();
        }


        private void New()
        {
            snText.Text = m_item.SerialNumber;
            snText.SelectAll();
            snText.Focus();
            ClearEditors();
            Init();
        }


        private void repairButton_Click(object sender, EventArgs e)
        {
            RouteStationFailure failure =
                repairFailuresView.GetFocusedRow() as RouteStationFailure;

            if (failure != null)
            {
                LoadRepairView(failure);
            }
        }

            
        private void LoadRepairView(RouteStationFailure failure)
        {
            RouteStationRepairForm form = new RouteStationRepairForm(failure);
            form.ShowDialog();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void removeFailureLink_OpenLink(object sender,
                                                OpenLinkEventArgs e)
        {
            RouteStationFailure failure =
                failuresView.GetFocusedRow() as RouteStationFailure;

            if (failure != null)
            {
                if (VerifyDelete(failure))
                    m_process.Failures.Remove(failure);
            }
        }


        private bool VerifyDelete(RouteStationFailure failure)
        {
            if (failure.HasConsumedRepairParts)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("This failure cannot be deleted until the repair parts consumed are reversed.", UserMessageType.Error);
                return false;
            }

            return
                (MessageBox.Show(
                     "Are you sure you want to delete this failure?",
                     Application.ProductName, MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes);
        }


        private void f9CommentsLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            if (m_item == null)
            {
                return;
            }

            FrontController.GetInstance().RunCommand(
                ServiceCommands.ViewF9Comments, m_item);
        }

        private void ViewProcessHistory()
        {
            if (m_item != null)
            {
                RouteProcessViewerForm form = new RouteProcessViewerForm(m_item);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        private void refreshFailuresLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            LoadFailures();
        }
       
        public event EventHandler<SingleChoiceActionRequestEventArgs<IStationTask>> RunTask;
        public event EventHandler<SingleChoiceActionRequestEventArgs<StationInspectionTaskResult>> DeleteInspectionResult;
        public event EventHandler<SingleChoiceActionRequestEventArgs<StationInspectionTaskResult>> EditInspectionResult;
        public event EventHandler<ActionRequestEventArgs> RunInspectionTask;

        public IPartsConsumptionView PartsConsumptionTaskView
        {
            get 
            {

                if (m_consumptionView != null)
                    m_consumptionView.Dispose();

                m_consumptionView = new PartsConsumptionView();

                return m_consumptionView;
                        
            }
        }

        public Collection<IStationTask> Tasks
        {
            set
            {
                if (value == null)
                    ClearTree();
                else
                    BindToTree(value);
            }
        }

        private void BindToTree(Collection<IStationTask> tasks)
        {
            tasksGrid.DataSource = tasks;

            if (tasks.Count == 0)
                tasksTab.Visibility = LayoutVisibility.Never;
            else
                tasksTab.Visibility = LayoutVisibility.Always;

        }

        private void ClearTree()
        {
            tasksGrid.DataSource = null;         
        }

        public void ShowMaterialsTaskView()
        {
            if(m_consumptionView != null)
                ViewLoader.Instance().ShowForm(m_consumptionView, false);
        }

  
        public ICollection<StationInspectionTaskResult> InspectionResults
        {
            set
            {
                inspectionsGrid.DataSource = value;
            }
        }

        public RouteStationProcess Process
        {
            get { return m_process; }
        }

        public IStationInspectionTaskView InspectionTaskView
        {
            get
            {
                if (m_inspectionView != null)
                    m_inspectionView.Dispose();

                m_inspectionView = new StationInspectionTaskView();
                return m_inspectionView;
            }
        }

        public void ShowInspectionTaskView()
        {           
                ViewLoader.Instance().ShowForm(m_inspectionView, false);           
        }

        private void reportInspectionDamageLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this,
                                                      "create_inspection_result");
                       
        }

        private void failCodeByCategoryLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            FailCodeByCategoryView view = 
                new FailCodeByCategoryView(m_item.Part.ServiceCommodity.ServiceCodes, m_codeByCategoryReturnHandler);
            view.StartPosition = FormStartPosition.CenterParent;
            view.ShowDialog(this);
        }

        private void setFpErrorCodeLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            var failure = repairFailuresView.GetFocusedRow() as RouteStationFailure;
            if(failure != null)
            {
                m_process.ChangeFpErrorCodeOwner(failure);                   
            }
        }

        private void undoConsumptionLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            var transaction = partsUsedView.GetFocusedRow() as Transaction;

            //var rc = from f in m_process.AllProcessFailures
            //         from r in f.Repairs
            //         from c in r.Components.Where(c => c.ConsumptionId == transaction.TransId)
            //         select c;
            //var component = rc.First();

            RepairComponent component = null;

            foreach (var failure in m_process.AllProcessFailures)
            {
                foreach (var repair in failure.Repairs)
                {
                    foreach (var c in repair.Components)
                    {
                        if (c.ConsumptionId == transaction.TransId)
                            component = c;
                    }
                }
            }

                                     
            if (transaction != null)
            {               
                if (MaterialService.UndoMaterialsConsumption(component, transaction))
                {
                    LoadPartsUsed(m_item.LotId);
                }
            }
        }
    }
}