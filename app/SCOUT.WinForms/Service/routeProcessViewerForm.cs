using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class RouteProcessViewerForm : XtraForm
    {
        
        public RouteProcessViewerForm(InventoryItem item)
        {
            InitializeComponent();        
            LoadHistory(item);
            WireEvents();
        }

        private void WireEvents()
        {
            processHistoryGrid.DoubleClick += processHistoryGrid_DoubleClick;
            okButton.Click += okButton_Click;
        }

        void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void processHistoryGrid_DoubleClick(object sender, EventArgs e)
        {
            RouteStationProcess process = processHistoryView.GetFocusedRow() as RouteStationProcess;
            if(process != null)
            {
                LoadResultsViewer(process);
            }
        }

        private void LoadResultsViewer(RouteStationProcess process)
        {
            StationResultsViewerForm form = new StationResultsViewerForm(process);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();                
        }

        private void LoadHistory(InventoryItem item)
        {
            processHistoryGrid.DataSource = item.Processes;
            snText.Text = item.SerialNumber;
            partNumberText.Text = item.PartNumber;
        }
    }
}