using System;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using SCOUT.Core;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Views;

namespace SCOUT.WinForms.Inventory
{
    public partial class InventoryCaptureManager : PassiveViewBase
    {
        private readonly InventoryCapture m_capture;
        private readonly IUnitOfWork m_session;
        private  XPCollection<InventoryCaptureProperties> m_captureProperties;
        
        public InventoryCaptureManager(InventoryCapture capture)
        {
            m_capture = capture;
            m_session = capture.Session;

            InitializeComponent();
            Init();
            Bind();
            WireEvents();
        }

        private void WireEvents()
        {
            sflLookup.EditValueChanged += sflLookup_EditValueChanged;
            holdCheck.CheckedChanged += holdCheck_CheckedChanged;
            saveButton.ItemClick += saveButton_ItemClick;
            closeButton.ItemClick += closeButton_ItemClick;
            domainLookup.Properties.ButtonClick += domainLookup_Properties_ButtonClick;
            resolveLink.OpenLink += resolveLink_OpenLink;
            conditionLookup.ButtonClick += conditionLookup_ButtonClick;
            holdRouteLookup.EditValueChanged += holdRouteLookup_EditValueChanged;
        }

        void holdRouteLookup_EditValueChanged(object sender, EventArgs e)
        {
            var route = holdRouteLookup.EditValue as ServiceRoute;
            if (route == null)
                return;

            if(m_capture.HoldStation != null && m_capture.HoldStation.ServiceRoute.Id != route.Id)
            {
                m_capture.HoldStation = null;
                m_capture.ReleaseStation = null;
            }

            holdStationLookup.Properties.DataSource = route.ActiveStations();
            releaseStationLookup.Properties.DataSource = route.ActiveStations();
        }

        void conditionLookup_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Delete)
            {
                m_capture.ApplyCondition = "";
            }
        }

        private void sflLookup_EditValueChanged(object sender, EventArgs e)
        {
            if (sflLookup.EditValue == null)
            {
                domainLookup.Properties.DataSource = null;
                domainLookup.EditValue = null;
                m_capture.HoldDomain = null;

                m_capture.HoldStation = null;
                m_capture.ReleaseStation = null;
                return;
            }

            var line = sflLookup.EditValue as Shopfloorline;
            if (line != null)
            {
                holdRouteLookup.Properties.DataSource = line.ActiveServiceRoutes;
                domainLookup.Properties.DataSource = line.Domains;
            }
        }

        private void Init()
        {
            LoadDisplayableProperties();

            if (m_capture.Shopfloorline != null)
            {
                sflLookup.TabStop = false;
                prioritySelList.TabStop = false;
                captureTypeSelList.TabStop = false;
                activeCheck.TabStop = false;
            }

            if (m_capture.HoldStation != null)
            {
                holdRouteLookup.EditValue = m_capture.HoldStation.ServiceRoute;
                holdRouteLookup_EditValueChanged(this,null);
            }
                                            
            conditionLookup.Properties.DataSource =
                Scout.Core.Data.GetList<ShopfloorCondition>(m_session).All();

            conditionLookup.Properties.DisplayMember = "Condition";
            conditionLookup.Properties.ValueMember = "Condition";            
            sflLookup.Properties.DataSource =
                Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);
        }

        private void LoadDisplayableProperties()
        {
            m_captureProperties = 
                Scout.Core.Data
                    .GetList<InventoryCaptureProperties>(m_session)
                    .Top(1) as XPCollection<InventoryCaptureProperties>;

            string displayableProperties = "RMA;PO;Shopfloorline;SerialNumber;PartNumber;PPID;";
            displayableProperties += "ReturnCount;TimeInField;DPS;Revision;ReceiptWarnings;XipReturnCount;Model;";
            displayableProperties += "Program;ReturnSeed;ServiceCommodity";

            m_captureProperties.DisplayableProperties = displayableProperties;
                
            captureFilters.SourceControl = m_captureProperties;
        }

        private void Bind()
        {
            holdCheck.DataBindings.Add("Checked", m_capture, "Hold");
            activeCheck.DataBindings.Add("Checked", m_capture, "Active");
            sflLookup.DataBindings.Add("EditValue", m_capture, "Shopfloorline!");
            descriptionText.DataBindings.Add("Text", m_capture, "Description");
            messageText.DataBindings.Add("Text", m_capture, "Message");
            captureFilters.DataBindings.Add("FilterString", m_capture, "Criteria");
            domainLookup.DataBindings.Add("EditValue", m_capture, "HoldDomain!");
            holdStationLookup.DataBindings.Add("EditValue", m_capture, "HoldStation!");
            releaseStationLookup.DataBindings.Add("EditValue", m_capture, "ReleaseStation!");
            allowStationDataCheck.DataBindings.Add("Checked", m_capture, "AllowStationData");
            prioritySelList.DataBindings.Add("EditValue", m_capture, "Priority");
            captureTypeSelList.DataBindings.Add("Text", m_capture, "Type");
            conditionLookup.DataBindings.Add("EditValue", m_capture, "ApplyCondition");

            prioritySelList.Properties.DataSource = Enum.GetValues(typeof (CapturePriority));

            LoadUnresolvedHolds();
        }

        private void LoadUnresolvedHolds()
        {
            capturedItemsGrid.DataSource =
                Scout.Core.Service<ICaptureService>()
                    .Repository.GetUnresolvedHoldsForCapture(m_capture);
        }

        private void holdCheck_CheckedChanged(object sender, EventArgs e)
        {
            switch (holdCheck.Checked)
            {
                case true:
                    domainLookup.Enabled = true;
                    holdStationLookup.Enabled = true;
                    releaseStationLookup.Enabled = true;
                    allowStationDataCheck.Enabled = true;
                    break;

                case false:
                    domainLookup.Enabled = false;
                    domainLookup.EditValue = null;
                    holdStationLookup.Enabled = false;
                    releaseStationLookup.Enabled = false;
                    m_capture.HoldStation = null;
                    m_capture.ReleaseStation = null;
                    m_capture.AllowStationData = false;
                    allowStationDataCheck.Enabled = false;
                    break;
            }
        }

        private void saveButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            focusCheck.Focus();
            SaveCapture();
        }

        private void SaveCapture()
        {
            if (Scout.Core.Service<ICaptureService>()
                .Repository.SaveCapture(m_capture))
            {
                Close();
            }
        }

        private void closeButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void domainLookup_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Undo)
                m_capture.HoldDomain = null;
        }

        private void resolveLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            var hold = capturedItemsView.GetFocusedRow() as InventoryHold;
            if (hold != null)
            {
                if (hold.Item.Hold == null)
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage
                        ("A valid hold was not found. Contact IT to resolve.", UserMessageType.Error);
                    return;
                }

                ViewLoader.Instance()
                    .CreateFormWithArgs<HoldResolutionForm>(false, hold);

                LoadUnresolvedHolds();
            }
        }

        private void showUnitsInWipButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<WipCaptureView>(false, m_capture);
        }
    }
}