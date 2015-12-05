using DevExpress.XtraReports.UI;

namespace SCOUT.WinForms.Reports
{
    public class DellPacklistController : PacklistController
    {       
        protected override XtraReport CreateReport()
        {
            return new DellPacklistReport();   
        }

        public override string DisplayName
        {
            get { return "Dell Packlist"; }
        }
    }
}