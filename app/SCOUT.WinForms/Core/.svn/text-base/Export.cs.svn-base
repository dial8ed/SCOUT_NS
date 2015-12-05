using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;

namespace SCOUT.WinForms.Core
{
    public class Export
    {
        public static void ExportGridToFile(GridControl grid, string ext)
        {           
            switch (ext)
            {
                case "xls":
                    grid.ExportToXls(File.ShowSaveFileDialog(ext));
                    return;
                case "pdf":
                    grid.ExportToPdf(File.ShowSaveFileDialog(ext));
                    return;
                case "htm":
                    grid.ExportToHtml(File.ShowSaveFileDialog(ext));
                    return;
                case "rtf":
                    grid.ExportToRtf(File.ShowSaveFileDialog(ext));
                    return;
            }
        }
        public static void ExportGridToFile(PivotGridControl grid, string ext)
        {
            switch (ext)
            {
                case "xls":
                    grid.ExportToXls(File.ShowSaveFileDialog(ext), true);
                    return;
                case "pdf":
                    grid.ExportToPdf(File.ShowSaveFileDialog(ext));
                    return;
                case "htm":
                    grid.ExportToHtml(File.ShowSaveFileDialog(ext));
                    return;
                case "rtf":
                    grid.ExportToRtf(File.ShowSaveFileDialog(ext));
                    return;
            }
        }
    }
}