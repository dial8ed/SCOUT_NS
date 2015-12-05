using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

using SCOUT.Core.Data;
using DevExpress.XtraExport;

namespace SCOUT.CS.UI
{
    public partial class GenericSearchForm : Form
    {
        public event EventHandler<OpenRowEventArgs> OpenRow;

        private bool m_gotExtraButtons = false;

        public GenericSearchForm()
        {
            InitializeComponent();
            exportExcelLink.Click += exportLink_Click;
            exportPDFLink.Click += exportLink_Click;
            exportHTMLLink.Click += exportLink_Click;
            exportRTFLink.Click += exportLink_Click;
        }

        public string StoredProc
        {
            get { return searchControl.StoredProc; }
            set { searchControl.StoredProc = value; }
        }

        public IList<DataRow> SelectedRows
        {
            get { return searchControl.SelectedRows; }
        }

        public Dictionary<string, object> Hints
        {
            get { return searchControl.Hints; }
        }

        public void AddToolButton(ToolStripButton tsb)
        {
            if (!m_gotExtraButtons)
            {
                toolStrip1.Items.Add(new ToolStripSeparator());
                m_gotExtraButtons = true;
            }

            toolStrip1.Items.Add(tsb);
        }

        public void RunSearch()
        {
            searchControl.RunSearch();
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

        private void searchControl_OpenRow(object sender, OpenRowEventArgs e)
        {
            if (OpenRow != null)
                OpenRow(this, e);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            searchControl.ShowPrintPreview();
        }

        private void exportLink_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = ((ToolStripMenuItem) sender);
            searchControl.Export(item.Tag.ToString());            
        }
    }
}