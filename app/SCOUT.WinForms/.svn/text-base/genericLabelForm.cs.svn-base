 using System;
 using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public partial class GenericLabelForm : DevExpress.XtraEditors.XtraForm
    {
        public GenericLabelForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            labelText.Validated += labelText_Validated;
            printButton.Click += printButton_Click;
            clearButton.Click += clearButton_Click;
        }

        void clearButton_Click(object sender, EventArgs e)
        {
            labelText.Text = "";
            labelCount.Value = 1;
        }

        void printButton_Click(object sender, EventArgs e)
        {
            if(labelText.Text.Length <= 0)
                return;

            GenericLabel lbl = GenericLabel.GetGenericLabel();
            lbl.SetLabelValues(labelText.Text);

            ZPLLabel zplLabel = ZPLLabel.GetLabelByName("CHARTER_UNIVERSAL");
            zplLabel.SetLabelValues(lbl.LabelValues);


            //DellAslLpnLabel label = DellAslLpnLabel.GetDellAslLpnLabel();
            //label.SetLabelValues("ASL5815204","D5551");

            //ZPLLabel zplLabel = ZPLLabel.GetLabelByName("DELL_ASL_LPN");
            //zplLabel.SetLabelValues(label.LabelValues);
           
            for (int i = 1; i <= labelCount.Value; i++)
            {
                zplLabel.Print();
            }
        }

        void labelText_Validated(object sender, EventArgs e)
        {
            labelText.Text = labelText.Text.ToUpper();
        }
    }
}