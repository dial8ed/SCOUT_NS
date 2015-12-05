using DevExpress.XtraReports.UI;

namespace SCOUT.WinForms.Reports
{
    public partial class DellPacklistReport : XtraReport
    {
        public DellPacklistReport()
        {
            InitializeComponent();
            vwPacklistDetailsTableAdapter.Connection.ConnectionString = SCOUT.Core.Data.Helpers.CnnStr();
            vwPacklistHeadersTableAdapter.Connection.ConnectionString = SCOUT.Core.Data.Helpers.CnnStr();
            WireEvents();
        }

        private void WireEvents()
        {
            this.ParametersRequestSubmit += PacklistReport_ParametersRequestSubmit;
        }

        void PacklistReport_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            var id = this.Parameters["packlistId"];
            if (id != null)
                FillDataSet(id.Value.ToString());
        }

        private void FillDataSet(string id)
        {
            vwPacklistHeadersTableAdapter.Fill(packlistDataset1.vwPacklistHeaders, id);
            vwPacklistDetailsTableAdapter.Fill(packlistDataset1.vwPacklistDetails, id);

            DataSource = packlistDataset1.vwPacklistHeaders;
            DetailReport.DataSource = packlistDataset1.vwPacklistDetails;
        }
    }
}
