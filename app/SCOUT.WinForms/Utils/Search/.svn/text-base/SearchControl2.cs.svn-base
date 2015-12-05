using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraPivotGrid;
using SCOUT.Core.Data;
using DevExpress.XtraGrid.Columns;

namespace SCOUT.WinForms
{
    public partial class SearchControl2 : XtraUserControl
    {
        #region Published Events

        /// <summary>
        /// The search has completed.
        /// </summary>
        public event EventHandler SearchCompleted;

        /// <summary>
        /// The user has aborted the search.
        /// </summary>
        public event EventHandler SearchAborted;

        /// <summary>
        /// The user has double clicked a row to open it.
        /// </summary>
        public event EventHandler<OpenRowEventArgs> OpenRow;

        #endregion

        #region Member Variables

        private ProcSearch m_proc = null;
        private string m_procName = "";
        private bool m_searchOnEnter = false;

        private DataTable m_searchResults = null;

        private WaitForm m_waitForm;

        private DateTime m_start = DateTime.Now;
        private TimeSpan m_lastRunTime;

        private Dictionary<string, object> m_hints = 
            new Dictionary<string, object>();

        private Dictionary<string, BaseEdit> m_paramEditors =
            new Dictionary<string, BaseEdit>();

        #endregion

        #region Constructor

        public SearchControl2()
        {
            InitializeComponent();

            m_waitForm = new WaitForm();            
        }

        #endregion

        #region Utility

        /// <summary>
        /// Initialize all the parameter fields for the currently given 
        /// stored proc.
        /// </summary>
        private void InitParameterFields()
        {
            IDictionaryEnumerator i;
            ProcSearchParam param;

            paramLayout.Controls.Clear();
            paramLayout.SuspendLayout();

            m_paramEditors.Clear();

            // Because .NET is retarted! *Cough or Bryce is Cough*
            i = (IDictionaryEnumerator)m_proc.Params.GetEnumerator();

            while (i.MoveNext())
            {
                param = (ProcSearchParam)i.Value;
                AddParam(param);
            }

            SetDefaultParameterValues();

            paramLayout.ResumeLayout();
        }

        /// <summary>
        /// Creates a single parameter field for the user to enter
        /// search criteria into.
        /// </summary>
        /// <param name="param"></param>
        private void AddParam(ProcSearchParam param)
        {
            string name = param.Name.Substring(1);
            BaseEdit paramEditor = null;

            switch (param.Type.ToLower())
            {
            case "bit":
                paramEditor = new CheckEdit();
                break;

            case "datetime":
                paramEditor = new DateEdit();
                break;

            default:
                paramEditor = new TextEdit();
                break;
            }

            paramEditor.Name = name + "Edit";
            paramEditor.Tag = param;

            paramEditor.ContextMenuStrip = CreateContextMenu(paramEditor);

            paramEditor.KeyPress += paramEdit_KeyPress;
            paramEditor.EditValueChanged += paramEdit_ValueChanged;

            m_paramEditors[param.Name] = paramEditor;
            
            BaseLayoutItem bli = 
                new LayoutControlItem(paramLayout, paramEditor);

            // Try for a nicer looking label.
            name = SCOUT.Core.Data.Helpers.UnderscoreToCamel(name);
            name = SCOUT.Core.Data.Helpers.SplitCamelCaps(name);

            bli.Text = name;
        }

        private ContextMenuStrip CreateContextMenu(Control c)
        {
            ContextMenuStrip cms = new ContextMenuStrip();
	    ToolStripMenuItem tsmi;

	    cms.Tag = c;

	    if (c is TextEdit)
	    {
		/*
		 * So we can enable/disable menu items based on the
		 * status of the clipboard.
		 */
		cms.Opening += new CancelEventHandler(paramMenu_Opening);

		tsmi = new ToolStripMenuItem();

		tsmi.Text = "Cu&t";
		tsmi.Name = "CutMenu";
		tsmi.ShortcutKeyDisplayString = "Ctrl+X";
		tsmi.Click += new EventHandler(paramCutMenu_Click);

		cms.Items.Add(tsmi);

		tsmi = new ToolStripMenuItem();

		tsmi.Text = "&Copy";
		tsmi.Name = "CopyMenu";
		tsmi.ShortcutKeyDisplayString = "Ctrl+C";
		tsmi.Click += new EventHandler(paramCopyMenu_Click);

		cms.Items.Add(tsmi);

		tsmi = new ToolStripMenuItem();

		tsmi.Text = "&Paste";
		tsmi.Name = "PasteMenu";
		tsmi.ShortcutKeyDisplayString = "Ctrl+V";
		tsmi.Click += new EventHandler(paramPasteMenu_Click);

		cms.Items.Add(tsmi);

		cms.Items.Add(new ToolStripSeparator());
	    }
		
	    tsmi = new ToolStripMenuItem();

            tsmi.Text = "&Reset";
	    tsmi.Name = "ResetMenu";
            tsmi.Click += paramResetMenu_Click;

            cms.Items.Add(tsmi);

            return cms;
        }

	/// <summary>
        /// Sets the default parameter search values.
        /// </summary>
        private void SetDefaultParameterValues()
        {
            IDictionaryEnumerator i;

            // Because .NET is retarted!
            i = (IDictionaryEnumerator)m_proc.Params.GetEnumerator();

            while (i.MoveNext())
            {
                string name = (string)i.Key;

                BaseEdit be = m_paramEditors[name];
                object defValue = null;

                if (m_hints.ContainsKey(name))
                    defValue = m_hints[name];
                else
                {
                    ProcSearchParam param = (ProcSearchParam)i.Value;

                    switch (param.Type.ToLower())
                    {
                    case "bit":
                        defValue = 0;
                        break;

                    default:
                        defValue = null;
                        break;
                    }
                }

                be.EditValue = defValue;
            }
        }

        /// <summary>
        /// Raises event dictating how the search has terminated.
        /// </summary>
        /// <param name="aborted"></param>
        private void NotifyStatus(bool aborted)
        {
            if (aborted)
            {
                if (SearchAborted != null)
                    SearchAborted(this, EventArgs.Empty);
            }
            else
            {
                m_waitForm.Dismiss();

                if (SearchCompleted != null)
                    SearchCompleted(this, EventArgs.Empty);
            }
        }

        public void ShowPrintPreview()
        {
            resultGrid.ShowPrintPreview();
        }

        public void Export(string ext)
        {            
            switch(ext)
            {
                case "xls":
                    resultGrid.ExportToXls(ShowSaveFileDialog(ext));
                    return;
                case "pdf":
                    resultGrid.ExportToPdf(ShowSaveFileDialog(ext));
                    return;
                case "htm":
                    resultGrid.ExportToHtml(ShowSaveFileDialog(ext));
                    return;
                case "rtf":
                    resultGrid.ExportToRtf(ShowSaveFileDialog(ext));
                    return;
            }
        }

        private string ShowSaveFileDialog(string ext)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "." + ext;
            saveFileDialog.DefaultExt = "." + ext;
            saveFileDialog.Filter = string.Format("{0} files (*.{0})|*.{0}", ext);
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.ShowDialog();

            return saveFileDialog.FileName;
        }

        #region Thread

        /// <summary>
        /// Updates the search results grid with the results of
        /// a completed search.
        /// </summary>
        /// <param name="dt"></param>
        private void UpdateResults(DataTable dt)
        {
            m_searchResults = dt;
            resultGrid.DataSource = dt;            
            searchDataNavigator.DataSource = dt;
            LoadPivotGrid();

            mainView.BestFitColumns();

	    foreach (GridColumn c in mainView.Columns)
	    {
		c.OptionsColumn.ReadOnly = true;
		c.OptionsColumn.AllowEdit = true;
	    }

            DateTime end = DateTime.Now;
            m_lastRunTime = end.Subtract(m_start);

            NotifyStatus(false);
        }

        private void LoadPivotGrid()
        {
            resultPivotGrid.DataSource = m_searchResults;
            CreatePivotFields();
        }

        private void CreatePivotFields()
        {
            foreach (DataColumn column in m_searchResults.Columns)
            {
                PivotGridField field = new PivotGridField();
                field.FieldName = column.ColumnName;
                field.Caption = column.ColumnName;
                resultPivotGrid.Fields.Add(field);
            }
        }


        private delegate void UpdateDel(DataTable dt);

        /// <summary>
        /// Independent thread that runs a search.
        /// </summary>
        private void SearchThread()
        {
            DateTime m_start = DateTime.Now;
            DataTable dt = m_proc.Execute();

            if (InvokeRequired)
            {
                UpdateDel update = UpdateResults;
                Invoke(update, dt);
            }
            else
                UpdateResults(dt);
        }  

        #endregion

        #endregion

        #region Public Interface

        /// <summary>
        /// Starts the searching thread.
        /// </summary>
        public void RunSearch()
        {
            if ((m_proc == null) || DesignMode)
                return;

            // Start the search thread.
            Thread st = new Thread(new ThreadStart(SearchThread));
            st.Start();

            // Display the wait dialog
            if (m_waitForm.ShowDialog(this) == DialogResult.Cancel)
            {
                // The user clicked "cancel" in the wait dialog, abort.

                if (st.IsAlive)
                {
                    st.Abort(); // Kill the thread
                    st.Join();  // Wait for it to fully finish terminating.
                }

                // Notify intrested parties that the search was aborted.
                NotifyStatus(true);
            }
        }

        /// <summary>
        /// Clears the result grid.
        /// </summary>
        public void ClearResults()
        {
            if ((m_proc == null) || DesignMode)
                return;

            m_searchResults = null;
            resultGrid.DataSource = null;
        }

	/// <summary>
	/// Clears all data in the search parameters, and resets them
	/// to the default values.
	/// </summary>
	public void ClearParams()
	{
	    SetDefaultParameterValues();
	}

        #endregion

        #region Properties

        [Bindable(true)]
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Gets or sets a value indicating if the user is allowed" +
            " to select more than one row at a time.")]
        public bool MultiSelect
        {
            get 
            { 
                return mainView.OptionsSelection.MultiSelect;
            }
            set 
            {
                mainView.OptionsSelection.MultiSelect = value;
            }
        }

        [Bindable(true)]
        [Browsable(true)]
        [Category("Data")]
        [Description("Gets or sets the stored procedure to execute for the " +
            "search.")]
        public string StoredProc
        {
            get { return m_procName; }
            set
            {
                if (m_procName != value)
                {
                    m_procName = value;
                    m_proc = new ProcSearch(value);

                    if (!DesignMode)
                        InitParameterFields();
                }
            }
        }

        [Bindable(true)]
        [Browsable(true)]
        [Category("Behavior")]
        [Description("Gets or sets the value indicating if the control " +
            "should automatically search when the enter key is pressed.")]
        public bool SearchOnEnter
        {
            get { return m_searchOnEnter; }
            set { m_searchOnEnter = value; }
        }

        /// <summary>
        /// Returns how long the last search ran for.
        /// </summary>
        [Bindable(true)]
        [Browsable(false)]
        public TimeSpan LastRunTime
        {
            get { return m_lastRunTime; }
        }

        /// <summary>
        /// Gets a list of the currently selected rows.
        /// </summary>
        [Bindable(true)]
        [Browsable(false)]
        public IList<DataRow> SelectedRows
        {
            get
            {
                List<DataRow> rval = new List<DataRow>();

                int[] rows = mainView.GetSelectedRows();
                for (int i = 0; i < rows.Length; ++i)
                    rval.Add(mainView.GetDataRow(rows[i]));

                return rval;
            }
        }

        /// <summary>
        /// Gets a list of all the search results.
        /// </summary>
        [Bindable(true)]
        [Browsable(false)]
        public DataTable SearchResults
        {
            get { return m_searchResults; }
        }

        /// <summary>
        /// Used to specify default search parameters.
        /// </summary>
        /// <remarks>
        /// A bit brain dead at the moment, you must specify these
        /// _before_ you set the stored proc.....
        /// </remarks>
        [Bindable(true)]
        [Browsable(false)]
        public Dictionary<string, object> Hints
        {
            get { return m_hints; }
        }

        #endregion

        #region Events

        void paramEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle the user hitting "enter" to being searching.

            if (e.KeyChar == '\r')
            {
                e.Handled = true;

                if (m_searchOnEnter)
                    RunSearch();
            }
        }

        void paramEdit_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Update parameter value when the user changes the value.
             * 
             * Done this way because MS databinding is a bit weird.
             */
            BaseEdit be = (BaseEdit)sender;
            ProcSearchParam p = (ProcSearchParam)be.Tag;

            if (be.EditValue != null)
            {
                string s = be.EditValue.ToString().Trim();

                p.Value = (s == "") ? DBNull.Value : be.EditValue;
            }
            else
                p.Value = DBNull.Value;
        }

        private void resultGrid_DoubleClick(object sender, EventArgs e)
        {
            if (OpenRow == null)
                return;

            int[] rows = mainView.GetSelectedRows();
            if (rows.Length > 0)
            {
                DataRowView drv;

                drv = mainView.GetRow(rows[rows.Length - 1]) as DataRowView;
                OpenRow(this, new OpenRowEventArgs(drv.Row));
            }
        }

	void paramMenu_Opening(object sender, CancelEventArgs e)
	{
	    ContextMenuStrip cms = (ContextMenuStrip)sender;
	    BaseEdit be = (BaseEdit)cms.Tag;
	    ToolStripMenuItem tsmi;
	    bool enabled;

	    tsmi = (ToolStripMenuItem)cms.Items["PasteMenu"];
	    tsmi.Enabled = Clipboard.ContainsText();

	    enabled = (be.EditValue != null) && (be.EditValue.ToString() != "");

	    tsmi = (ToolStripMenuItem)cms.Items["CutMenu"];
	    tsmi.Enabled = enabled;

	    tsmi = (ToolStripMenuItem)cms.Items["CopyMenu"];
	    tsmi.Enabled = enabled;
	}

	void paramPasteMenu_Click(object sender, EventArgs e)
	{
	    ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
	    BaseEdit be = (BaseEdit)tsmi.Owner.Tag;

	    be.EditValue = Clipboard.GetText();
	}

	void paramCopyMenu_Click(object sender, EventArgs e)
	{
	    ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
	    BaseEdit be = (BaseEdit)tsmi.Owner.Tag;

	    Clipboard.SetText(be.EditValue.ToString());
	}

	void paramCutMenu_Click(object sender, EventArgs e)
	{
	    ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
	    BaseEdit be = (BaseEdit)tsmi.Owner.Tag;

	    Clipboard.SetText(be.EditValue.ToString());
	    be.EditValue = null;
	}

        private void paramResetMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            BaseEdit be = (BaseEdit)tsmi.Owner.Tag;
            ProcSearchParam p = (ProcSearchParam)be.Tag;

            object defValue = null;

            if (m_hints.ContainsKey(p.Name))
                defValue = m_hints[p.Name];

            be.EditValue = defValue;
        }

        #endregion
    }

    public class OpenRowEventArgs2 : EventArgs
    {
        private DataRow m_row;

        public OpenRowEventArgs2(DataRow row): base()
        {
            m_row = row;
        }

        public DataRow DataRow
        {
            get { return m_row; }
        }
    }
}
