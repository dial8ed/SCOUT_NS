using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Reports
{
    public partial class DellLpnPacklistReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DellLpnPacklistReport()
        {
            InitializeComponent();
            vw_shipping_configuration_packlist_detailsTableAdapter.Connection.ConnectionString = SCOUT.Core.Data.Helpers.CnnStr();
            vw_shipping_configuration_packlist_headersTableAdapter1.Connection.ConnectionString = SCOUT.Core.Data.Helpers.CnnStr();

            WireEvents();            
        }

        private void WireEvents()
        {
            this.AfterPrint += DellPacklistReport2_AfterPrint;            
        }

        void DellPacklistReport2_AfterPrint(object sender, EventArgs e)
        {
            string packlistId = this.Parameters["packlistId"].Value.ToString();

            Scout.Core.Service<IShippingService>()
                .SetPacklistPrintDate(packlistId, DateTime.Now);            
        }
    }
}
