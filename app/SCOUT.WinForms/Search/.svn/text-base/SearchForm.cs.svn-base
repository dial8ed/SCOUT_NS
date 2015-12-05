using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Wizard;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms
{
    public partial class SearchForm : Form
    {
        #region Member Variables

        private bool m_gotExtraButtons;
        private Type m_searchObjectType;

        private Dictionary<string, object> m_hints =
            new Dictionary<string, object>();

        private TimeSpan m_lastRunTime;

        private Dictionary<string, BaseEdit> m_paramEditors =
            new Dictionary<string, BaseEdit>();

        private ProcSearch m_proc;
        private string m_procName = "";
        private bool m_searchOnEnter;

        private DataTable m_searchResults;

        private DateTime m_start = DateTime.Now;
        private WaitForm m_waitForm;

        private MRUListController m_listController = new MRUListController();
        private UserQueryController m_queryController = null;

        #endregion

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

        public SearchForm()
        {
            InitializeComponent();
            WireEvents();
            m_waitForm = new WaitForm();
            LoadDefaultGrid();
        }

        public PivotGridControl PivotGrid
        {
            get { return resultsPivotGrid; }
        }

        public GridControl DataGrid
        {
            get { return resultsGrid; }
        }

        public ProcSearch StoredProcedure
        {
            get { return m_proc; }
        }

        public Dictionary<string, BaseEdit> ParamEditors
        {
            get { return m_paramEditors; }
        }

        public Type SearchObjectType
        {
            get { return m_searchObjectType; }
            set { m_searchObjectType = value;}
        }

        public FilterControl SearchFilterControl
        {
            get { return searchFilter;  }
        }

        public GridView DataGridView
        {
            get { return resultsView;  }
        } 

        private void LoadDefaultGrid()
        {
            pivotGridLayoutItem.Visibility = LayoutVisibility.Never;
            gridLayoutItem.Visibility = LayoutVisibility.Always;
        }

        private void WireEvents()
        {
            exportExcelLink.LinkClicked += exportLink_Click;
            exportPDFLink.LinkClicked += exportLink_Click;
            exportHTMLLink.LinkClicked += exportLink_Click;
            exportRTFLink.LinkClicked += exportLink_Click;
            clearButton.Click += clearBtn_Click;
            resultsGrid.DoubleClick += resultsGrid_DoubleClick;
            printLink.LinkClicked += printLink_LinkClicked;
            printPreviewLink.LinkClicked += printPreviewLink_LinkClicked;
            resultsPivotGrid.CellDoubleClick += resultsPivotGrid_CellDoubleClick;
            gridContextMenu.Click += gridContextMenu_Click;
        }

        void gridContextMenu_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(((GridView)resultsGrid.DefaultView)
                .GetFocusedDisplayText());            
        }

        void resultsPivotGrid_CellDoubleClick(object sender, PivotCellEventArgs e)
        {
            // Create a new form.
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGrid grid = new DataGrid();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = e.CreateDrillDownDataSource();
            form.Bounds = new Rectangle(100, 100, 500, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();

        }

        private void printPreviewLink_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (pivotGridLayoutItem.Visibility == LayoutVisibility.Always)
                resultsPivotGrid.ShowPrintPreview();
            else
                resultsGrid.ShowPrintPreview();
        }

        private void printLink_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (resultsGrid != null) resultsGrid.Print();
        }

        public void AddToolButton(ToolStripButton tsb)
        {
            if (!m_gotExtraButtons)
            {
                searchToolstrip.Items.Add(new ToolStripSeparator());
                m_gotExtraButtons = true;
            }

            searchToolstrip.Items.Add(tsb);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearResults();
            ClearParams();
        }

        private void exportLink_Click(object sender, EventArgs e)
        {
            NavBarItem item = ((NavBarItem) sender);

            if (pivotGridLayoutItem.Visibility == LayoutVisibility.Always)
            {
                Export.ExportGridToFile(resultsPivotGrid, item.Tag.ToString());
            }
            else
            {
                Export.ExportGridToFile(resultsGrid, item.Tag.ToString());
            }
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            searchFilter.ApplyFilter();
        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            RunSearch();       

            if(m_queryController != null)
            {
                m_queryController.LoadQueryFilter();
                m_queryController.LoadQueryLayout();
            }
        }

        private void dataGridLink_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            pivotGridLayoutItem.Visibility = LayoutVisibility.Never;
            gridLayoutItem.Visibility = LayoutVisibility.Always;
        }

        private void pivotGridLink_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            pivotGridLayoutItem.Visibility = LayoutVisibility.Always;
            gridLayoutItem.Visibility = LayoutVisibility.Never;
        }

        private void chartWizardLink_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ChartControl chart = new ChartControl();
            chart.DataSource = resultsGrid.DataSource;

            ChartWizard wizard = new ChartWizard(chart);
            wizard.ShowDialog();

            if (chart.Created)
            {
                Form form = new Form();
                chart.Dock = DockStyle.Fill;
                form.Controls.Add(chart);
                form.Show();
            }
        }

        #region Utility

        /// <summary>
        /// Initialize all the parameter fields for the currently given 
        /// stored proc.
        /// </summary>
        private void InitParameterFields()
        {
            IDictionaryEnumerator i;
            ProcSearchParam param;

            paramsLayout.Controls.Clear();
            paramsLayout.SuspendLayout();

            m_paramEditors.Clear();

            // Because .NET is retarted! *Cough or Bryce is Cough*
            i = (IDictionaryEnumerator) m_proc.Params.GetEnumerator();

            while (i.MoveNext())
            {
                param = (ProcSearchParam) i.Value;
                AddParam(param);
            }

            SetDefaultParameterValues();

            paramsLayout.ResumeLayout();
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

                case "smalldatetime":
                    paramEditor = new DateEdit();
                    break;

                case "int":
                    paramEditor = new SpinEdit();
                    ((SpinEdit) paramEditor).Properties.IsFloatValue = false;
                    break;
                    
                default:
                    paramEditor = m_listController.NewMRUEdit(name);
                    break;
            }

            paramEditor.Name = name + "Edit";
            paramEditor.Tag = param;

            paramEditor.ContextMenuStrip = CreateContextMenu(paramEditor);
            paramEditor.KeyPress += paramEdit_KeyPress;
            paramEditor.EditValueChanged += paramEdit_ValueChanged;

          
            m_paramEditors[param.Name] = paramEditor;

            BaseLayoutItem bli =
                new LayoutControlItem(paramsLayout, paramEditor);

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
                cms.Opening += paramMenu_Opening;

                tsmi = new ToolStripMenuItem();

                tsmi.Text = "Cu&t";
                tsmi.Name = "CutMenu";
                tsmi.ShortcutKeyDisplayString = "Ctrl+X";
                tsmi.Click += paramCutMenu_Click;

                cms.Items.Add(tsmi);

                tsmi = new ToolStripMenuItem();

                tsmi.Text = "&Copy";
                tsmi.Name = "CopyMenu";
                tsmi.ShortcutKeyDisplayString = "Ctrl+C";
                tsmi.Click += paramCopyMenu_Click;

                cms.Items.Add(tsmi);

                tsmi = new ToolStripMenuItem();

                tsmi.Text = "&Paste";
                tsmi.Name = "PasteMenu";
                tsmi.ShortcutKeyDisplayString = "Ctrl+V";
                tsmi.Click += paramPasteMenu_Click;

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
            i = (IDictionaryEnumerator) m_proc.Params.GetEnumerator();

            while (i.MoveNext())
            {
                string name = (string) i.Key;

                BaseEdit be = m_paramEditors[name];
                object defValue = null;

                if (m_hints.ContainsKey(name))
                    defValue = m_hints[name];
                else
                {
                    ProcSearchParam param = (ProcSearchParam) i.Value;

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


        private string ShowSaveFileDialog(string ext)
        {
            return File.ShowSaveFileDialog(ext);
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
            resultsGrid.DataSource = dt;
            resultsPivotGrid.DataSource = dt;
            LoadPivotFields(dt, resultsPivotGrid);
            searchFilter.SourceControl = dt;
            resultsView.BestFitColumns();

            DateTime end = DateTime.Now;
            m_lastRunTime = end.Subtract(m_start);

            NotifyStatus(false);
        }

        private void LoadPivotFields(DataTable dt, PivotGridControl grid)
        {
            grid.Fields.Clear();
            foreach (DataColumn column in dt.Columns)
            {
                grid.Fields.Add(new PivotGridField(column.Caption, PivotArea.FilterArea));
            }
        }


        /// <summary>
        /// Independent thread that runs a search.
        /// </summary>
        private void SearchThread()
        {
            DateTime m_start = DateTime.Now;

            try
            {

            DataTable dt = m_proc.Execute();
                if (InvokeRequired)
                {
                    UpdateDel update = UpdateResults;
                    Invoke(update, dt);
                }
                else
                    UpdateResults(dt);
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "There was an error during the execution of this query. Please wait two minutes and re-run.", UserMessageType.Exception);                
            }

        }

        private delegate void UpdateDel(DataTable dt);

        #endregion

        #endregion

        #region Public Interface

        /// <summary>
        /// Starts the searching thread.
        /// </summary>
        public void RunSearch()
        {

            searchButton.Focus();

            if ((m_proc == null) || DesignMode)
                return;

            // Start the search thread.
            Thread st = new Thread(SearchThread);
            st.Start();

            // Display the wait dialog
            if (m_waitForm.ShowDialog(this) == DialogResult.Cancel)
            {
                // The user clicked "cancel" in the wait dialog, abort.

                if (st.IsAlive)
                {
                    st.Abort(); // Kill the thread
                    st.Join(); // Wait for it to fully finish terminating.
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
            resultsGrid.DataSource = null;            
            resultsPivotGrid.DataSource = null;
            resultsPivotGrid.Fields.Clear();
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
            get { return resultsView.OptionsSelection.MultiSelect; }
            set { resultsView.OptionsSelection.MultiSelect = value; }
        }

        [Bindable(true)]
        [Browsable(true)]
        [Category("Behavior")]
        public bool ShowModal
        {
            get; set;
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

                    m_queryController = new UserQueryController(this);

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

                int[] rows = resultsView.GetSelectedRows();
                for (int i = 0; i < rows.Length; ++i)
                    rval.Add(resultsView.GetDataRow(rows[i]));

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

        private void paramEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle the user hitting "enter" to being searching.

            if (e.KeyChar == '\r')
            {
                e.Handled = true;

                //if (m_searchOnEnter)
                RunSearch();
            }
        }

        private void paramEdit_ValueChanged(object sender, EventArgs e)
        {
            /*
             * Update parameter value when the user changes the value.
             * 
             * Done this way because MS databinding is a bit weird.
             */
            BaseEdit be = (BaseEdit) sender;
            ProcSearchParam p = (ProcSearchParam) be.Tag;

            if (be.EditValue != null)
            {
                string s = be.EditValue.ToString().Trim();

                p.Value = (s == "") ? DBNull.Value : be.EditValue;
            }
            else
                p.Value = DBNull.Value;
        }

        private void resultsGrid_DoubleClick(object sender, EventArgs e)
        {
            if (OpenRow == null)
                return;

            int[] rows = resultsView.GetSelectedRows();
            if (rows.Length > 0)
            {
                DataRowView drv;

                drv = resultsView.GetRow(rows[rows.Length - 1]) as DataRowView;
                OpenRow(this, new OpenRowEventArgs(drv.Row));
            }
        }

        private void paramMenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip cms = (ContextMenuStrip) sender;
            BaseEdit be = (BaseEdit) cms.Tag;
            ToolStripMenuItem tsmi;
            bool enabled;

            tsmi = (ToolStripMenuItem) cms.Items["PasteMenu"];
            tsmi.Enabled = Clipboard.ContainsText();

            enabled = (be.EditValue != null) && (be.EditValue.ToString() != "");

            tsmi = (ToolStripMenuItem) cms.Items["CutMenu"];
            tsmi.Enabled = enabled;

            tsmi = (ToolStripMenuItem) cms.Items["CopyMenu"];
            tsmi.Enabled = enabled;
        }

        private void paramPasteMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            BaseEdit be = (BaseEdit) tsmi.Owner.Tag;

            be.EditValue = Clipboard.GetText();
        }

        private void paramCopyMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            BaseEdit be = (BaseEdit) tsmi.Owner.Tag;

            Clipboard.SetText(be.EditValue.ToString());
        }

        private void paramCutMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            BaseEdit be = (BaseEdit) tsmi.Owner.Tag;

            Clipboard.SetText(be.EditValue.ToString());
            be.EditValue = null;
        }

        private void paramResetMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem) sender;
            BaseEdit be = (BaseEdit) tsmi.Owner.Tag;
            ProcSearchParam p = (ProcSearchParam) be.Tag;

            object defValue = null;

            if (m_hints.ContainsKey(p.Name))
                defValue = m_hints[p.Name];

            be.EditValue = defValue;
        }

        #endregion

        private void saveLink_LinkClicked(object sender, NavBarLinkEventArgs e)
        {            
            m_queryController.SaveUserQuery();
        }

        public void LoadUserQuery(UserQuery query)
        {
            m_queryController = new UserQueryController(this);
            m_queryController.LoadParamValues(query);
            RunSearch();
            m_queryController.LoadQueryLayout();            
        }
    }

    public class OpenRowEventArgs : EventArgs
    {
        private DataRow m_row;

        public OpenRowEventArgs(DataRow row)
        {
            m_row = row;
        }

        public DataRow DataRow
        {
            get { return m_row; }
        }
    }
}