using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.Core.Utils;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Inventory;

namespace SCOUT.WinForms.Views
{
    //TODO: Convert to MVC
    public partial class ManageInventoryHoldsView : Form
    {        
        private IUnitOfWork m_uow;

        public ManageInventoryHoldsView()
        {
            InitializeComponent();
            BuildPopUpMenu();
            WireEvents();
            LoadUnitOfWork();            
        }

        private void LoadUnitOfWork()
        {
            m_uow = Scout.Core.DefaultModuleProvider.Data.GetUnitOfWork();
        }
 
        private void WireEvents()
        {
            filterControl1.FilterStringChanged += filterControl1_FilterStringChanged;
        }

        void filterControl1_FilterStringChanged(object sender, EventArgs e)
        {
            filterString.Text = filterControl1.FilterString;
        }

        private void BuildPopUpMenu()
        {
            DXPopupMenu menu = new DXPopupMenu();
            menu.Items.Add(new DXMenuItem("High Priority Holds", filterMenuItem_Clicked));
            menu.Items.Add(new DXMenuItem("Multiple High Priority Captures", filterMenuItem_Clicked));
            findHoldsButton.DropDownControl = menu;
        }

        private void filterMenuItem_Clicked(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            if (item != null)
            {
                switch (item.Caption)
                {
                    case "High Priority Holds":
                        filterControl1.FilterString = "[CapturePriority]='High' AND [HoldStatus]='Open'";
                        break;
                    case "Multiple High Priority Captures":
                        filterControl1.FilterString = "[HoldReason]='MULTIPLE_CAPTURES' AND [HoldStatus]='Open'";
                        break;
                }

                if (!string.IsNullOrEmpty(filterControl1.FilterString))
                    Search();

            }            
        }

        private void findHoldsButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            ICaptureService service;
            service = Scout.Core.Service<ICaptureService>();
            resultsGrid.DataSource = service.Repository.GetHoldsByCriteriaString
                    (m_uow, filterControl1.FilterString);           
        }

        private void resolveLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            InventoryHoldDetails holdDetails = resultsView.GetFocusedRow() as InventoryHoldDetails;
           
            if(holdDetails == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Select a hold to resolve.", UserMessageType.Error);
                return;
            }

            if (holdDetails.Hold != null)
            {
                if (holdDetails.Hold.Status != HoldStatus.Open)
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage
                        ("This hold is " + holdDetails.HoldStatus + " and does not to be resolved.", UserMessageType.Information);
                    return;
                }

                if (holdDetails.Hold.Reason == null || !holdDetails.Hold.Reason.Equals("MULTIPLE_CAPTURES"))
                {
                    ViewLoader.Instance()
                        .CreateFormWithArgs<HoldResolutionForm>(false, holdDetails.Hold);
                }
                else
                {
                    ViewLoader.Instance().CreateFormWithArgs<ResolveMultipleCaptureView>
                        (false, new object[] { holdDetails.Hold });
                }

                // Refresh
                Search();
            }
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            Export.ExportGridToFile(resultsGrid, "xls");
        }
    }
}
