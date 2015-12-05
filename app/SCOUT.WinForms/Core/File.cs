using System.Windows.Forms;

namespace SCOUT.WinForms.Core
{
    public class File
    {
        public static string ShowSaveFileDialog(string ext)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "." + ext;
            saveFileDialog.DefaultExt = "." + ext;
            saveFileDialog.Filter = string.Format("{0} files (*.{0})|*.{0}", ext);
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.ShowDialog();

            return saveFileDialog.FileName;
        }
    }
}