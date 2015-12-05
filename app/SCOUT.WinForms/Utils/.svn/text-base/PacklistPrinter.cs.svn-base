using DevExpress.XtraReports.Parameters;
using SCOUT.Core.Data;
using SCOUT.WinForms.Reports;

namespace SCOUT.WinForms
{
    public class PacklistPrinter
    {        
        public void Print(Packlist packlist)
        {
            if (packlist.ShippingConfiguration != null)
                PrintConfigurationPacklist(packlist);              
        }

        private void PrintConfigurationPacklist(Packlist packlist)
        {

            switch (packlist.ShippingConfiguration.PacklistAllocationMethod)
            {
                case PacklistAllocation.MultipleOrders:

                    if(packlist.ShippingConfiguration.ShopfloorlineProgram == "LPN")
                    {
                        DellLpnPacklistReport report = new DellLpnPacklistReport();
                        Parameter param = report.Parameters["packlistId"];
                        param.Value = packlist.PacklistId;
                        report.ShowPreview();
                        break; 
                    } 
                    else
                    {
                        DellPoPacklistReport report = new DellPoPacklistReport();
                        Parameter param = report.Parameters["packlistId"];
                        param.Value = packlist.PacklistId;
                        report.ShowPreview();
                        break; 
                    }

                case PacklistAllocation.SingleOrder:
                    PacklistController controller = new StsPacklistController();
                    controller.LoadReport(packlist.PacklistId);
                    break;
            }   
        }        
    }
}