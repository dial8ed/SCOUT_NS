using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms
{
    public partial class PrinterSetupForm : DevExpress.XtraEditors.XtraForm
    {
        public PrinterSetupForm()
        {
            InitializeComponent();
        }

        private void printerSetupForm_Load(object sender, EventArgs e)
        {
            Printer[] printers;
            printers = Util.GetPrinterList();

            if (printers.Length == 0)
            {
                MessageBox.Show("No printers to select from.",
                                Application.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);

                DialogResult = DialogResult.Cancel;
                return;
            }

            printerSelList.Properties.Items.AddRange(printers);
            printerSelList.Text = SCOUT.Core.Data.Helpers.Config["PrinterName"];

            bool enablePrinter = false;

            bool.TryParse(SCOUT.Core.Data.Helpers.Config["EnablePrinter"], out enablePrinter);
            enableCheck.Checked = enablePrinter;

            UpdateEnableCheckInfo();
        }

        private void UpdateEnableCheckInfo()
        {
            printerSelList.Enabled = enableCheck.Checked;
        }

        private void enableCheck_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnableCheckInfo();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SCOUT.Core.Data.Helpers.Config["PrinterName"] = printerSelList.Text;
            SCOUT.Core.Data.Helpers.Config["EnablePrinter"] = enableCheck.Checked.ToString();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}