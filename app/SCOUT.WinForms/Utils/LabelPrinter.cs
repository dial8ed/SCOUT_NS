using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public class LabelPrinter
    {
        public static bool PrintReceivingLabel()
        {
            return false;
        }

        public static bool PrintDellLpnLabel(string lpn, string partNumber)
        {
            DellAslLpnLabel label = DellAslLpnLabel.GetDellAslLpnLabel();
            label.SetLabelValues(lpn, partNumber);
            ZPLLabel zplLabel = ZPLLabel.GetLabelByName("DELL_ASL_LPN");
            zplLabel.SetLabelValues(label.LabelValues);
            return zplLabel.Print();           
        }
  
    }
}