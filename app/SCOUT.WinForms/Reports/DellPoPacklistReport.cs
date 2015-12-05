using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Reports
{
    public partial class DellPoPacklistReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DellPoPacklistReport()
        {
            InitializeComponent();
            vw_shipping_configuration_packlist_detailsTableAdapter.Connection.ConnectionString = SCOUT.Core.Data.Helpers.CnnStr();
            vw_shipping_configuration_packlist_headersTableAdapter1.Connection.ConnectionString = SCOUT.Core.Data.Helpers.CnnStr();

            WireEvents();            
        }

        private void WireEvents()
        {
            this.AfterPrint += DellPoPacklistReport_AfterPrint;            
        }

        void DellPoPacklistReport_AfterPrint(object sender, EventArgs e)
        {
            string packlistId = this.Parameters["packlistId"].Value.ToString();

            Scout.Core.Service<IShippingService>()
                .SetPacklistPrintDate(packlistId, DateTime.Now);            
        }
    }
}
