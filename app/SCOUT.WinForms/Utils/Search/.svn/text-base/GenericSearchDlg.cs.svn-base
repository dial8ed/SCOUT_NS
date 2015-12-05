using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SCOUT.WinForms
{
    public partial class GenericSearchDlg : Form
    {
        public GenericSearchDlg()
        {
            InitializeComponent();
        }

        public IList<DataRow> SelectedRows
        {
            get { return searchControl.SelectedRows; }
        }

        public string StoredProc
        {
            get { return searchControl.StoredProc; }
            set { searchControl.StoredProc = value; }
        }

        public Dictionary<string, object> Hints
        {
            get { return searchControl.Hints; }
        }

        public bool MultiSelect
        {
            get { return searchControl.MultiSelect; }
            set { searchControl.MultiSelect = value; }
        }

        public bool ShowOperations
        {
            get { return operationGrp.Visible; }
            set { operationGrp.Visible = value; }
        }

        public bool Append
        {
            get { return appRadio.Checked; }
            set
            {
                appRadio.Checked = value;
                repRadio.Checked = !value;
            }
        }

        public bool Replace
        {
            get { return repRadio.Checked; }
            set
            {
                repRadio.Checked = value;
                appRadio.Checked = !value;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            searchControl.RunSearch();
        }

	private void clearBtn_Click(object sender, EventArgs e)
	{
	    searchControl.ClearResults();
	    searchControl.ClearParams();
	}
    }
}