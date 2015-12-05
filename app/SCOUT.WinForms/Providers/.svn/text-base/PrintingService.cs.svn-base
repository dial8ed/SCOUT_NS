using System;
using System.IO;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;


namespace SCOUT.WinForms.Printing
{
    public class PrintingService : IPrintingService
    {

        public bool PrintZplLabel(ZPLLabel label)
        {
            bool enabled = false;
            PrinterStream printerStream;
            StreamWriter writer;

            bool.TryParse(SCOUT.Core.Data.Helpers.Config["EnablePrinter"], out enabled);

            if (!enabled)
                return false;

            printerStream = new PrinterStream(SCOUT.Core.Data.Helpers.Config["PrinterName"], "Generic Label");
            writer = new StreamWriter(printerStream);

            try
            {
                writer.WriteLine(label.LabelData, label.LabelValues);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to print label." + Environment.NewLine +
                                Environment.NewLine + ex.Message, Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            finally
            {
                writer.Flush();
                writer.Close();
                printerStream.Close();
            }
        }       
    }
}