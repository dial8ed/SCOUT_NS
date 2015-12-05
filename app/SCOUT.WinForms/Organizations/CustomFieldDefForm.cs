using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public partial class CustomFieldDefForm : Form
    {
        public CustomFieldDefForm()
        {
            InitializeComponent();

            custFeildDefList.DataSource = CustomFieldDef.AllDefs;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (custFeildDefList.SelectedCells.Count == 0)
                return;
        
            DataGridViewCell cell = custFeildDefList.SelectedCells[0];
            CustomFieldDef cfd = cell.OwningRow.DataBoundItem as
                CustomFieldDef;

            if (cfd == null)
                return;

            SuperConfirmForm scf = new SuperConfirmForm(cfd.Name);

            if (scf.ShowDialog(this) == DialogResult.OK)
            {
                CustomFieldDef.AllDefs.Remove(cfd);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            CustomFieldDef.AllDefs.Save();
        }
    }
}