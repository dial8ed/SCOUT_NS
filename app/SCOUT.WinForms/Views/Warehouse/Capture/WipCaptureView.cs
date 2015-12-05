using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Views
{
    public partial class WipCaptureView : Form
    {
        public WipCaptureView()
        {
            InitializeComponent();
        }

        public WipCaptureView(InventoryCapture capture)
        {            
            InitializeComponent();

            string criteria = capture.Criteria;
            criteria = "(" + criteria + ")";

            criteria += " AND [Shopfloorline]=" + capture.Shopfloorline.Id;
            criteria += " AND [Qty] > 0";

            filterControl1.FilterString = criteria;
            searchButton_Click(null, null);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filterControl1.FilterString))
                GetResults(filterControl1.FilterString);
        }

        private void GetResults(string filterString)
        {
            try
            {
                gridControl1.DataSource =
                    Scout.Core.Service<IInventoryService>()
                        .GetAllCaptureUnitsByCritieriaString(Scout.Core.Data.GetUnitOfWork(), filterString);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);             
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToXlsLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            Export.ExportGridToFile(gridControl1, "xls");
        }
    }
}
