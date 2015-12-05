using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.BandedGrid;

using SCOUT.Entities.CS.Search;

namespace SCOUT.CS.UI
{
    public partial class SearchControl : DevExpress.XtraEditors.XtraUserControl
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
	public event EventHandler<OpenItemEventArgs> OpenItem;

	#endregion

	#region Member Variables

	private Search m_search;
	private bool m_searchOnEnter = false;

	private DataTable m_searchResults = null;

	private Column m_priColumn = null;

	private Dictionary<string, BaseEdit> m_fieldEditors =
	    new Dictionary<string, BaseEdit>();

	private Dictionary<string, string> m_fieldValues =
	    new Dictionary<string, string>();

	private Dictionary<string, string> m_hints =
	    new Dictionary<string, string>();

	private WaitForm m_waitForm;

	private DateTime m_start = DateTime.Now;
	private TimeSpan m_lastRunTime;

	#endregion

	#region Constructor

	public SearchControl()
	{
	    InitializeComponent();

	    m_waitForm = new WaitForm();
	}

	#endregion

	#region Utility

	private void InitParameterFields()
	{
	    fieldLayout.Controls.Clear();
	    fieldLayout.SuspendLayout();

	    m_fieldEditors.Clear();

	    if (m_search != null)
	    {
		foreach (Field fld in m_search.SearchFields)
		    AddField(fld);

		SetDefaultFieldValues();
	    }

	    fieldLayout.ResumeLayout();
	}

	/// <summary>
	/// Creates a single parameter field for the user to enter
	/// search criteria into.
	/// </summary>
	/// <param name="param"></param>
	/// <param name="defValue"></param>
	private void AddField(Field fld)
	{
	    BaseEdit fieldEdit = null;

	    switch (fld.Type)
	    {
	    default:
	    case FieldType.String:
		fieldEdit = new TextEdit();
		break;

	    case FieldType.Integer:
		fieldEdit = new SpinEdit();
		break;

	    case FieldType.DateTime:
		fieldEdit = new DateEdit();
		break;

	    case FieldType.Boolean:
		fieldEdit = new CheckEdit();
		break;

	    case FieldType.List:
		{
		    LookUpEdit lue = new LookUpEdit();

		    lue.Properties.DataSource = fld.ListItems;
		    lue.Properties.DisplayMember = "DisplayName";
		    lue.Properties.ValueMember = "Value";

		    fieldEdit = lue;
		}
		break;
	    }

	    fieldEdit.Name = fld.Name.Substring(1) + "Edit";
	    fieldEdit.Tag = fld;

	    //fieldEdit.ContextMenuStrip = CreateContextMenu(fieldEdit);

	    fieldEdit.KeyPress += fieldEdit_KeyPress;
	    fieldEdit.EditValueChanged += fieldEdit_EditValueChanged;

	    m_fieldEditors[fld.Name] = fieldEdit;

	    BaseLayoutItem bli =
		new LayoutControlItem(fieldLayout, fieldEdit);

	    bli.CustomizationFormText = fld.DisplayName;
	    bli.Text = fld.DisplayName + ":";
	}

	private void SetDefaultFieldValues()
	{
	    foreach (Field fld in m_search.SearchFields)
	    {
		BaseEdit be = m_fieldEditors[fld.Name];
		object defValue = null;

		if (m_hints.ContainsKey(fld.Name))
		    defValue = m_hints[fld.Name];
		else
		{
		    switch (fld.Type)
		    {
		    case FieldType.Boolean:
			defValue = false;
			break;

		    case FieldType.Integer:
			defValue = fld.MinimumValue;
			break;
		    }
		}

		be.EditValue = defValue;
	    }
	}

	private void InitColumns()
	{
	    mainView.Columns.Clear();
	    mainView.Bands[0].Columns.Clear();

	    bool anySummary = false;
	    m_priColumn = null;

	    if (m_search != null)
	    {
		foreach (Column col in m_search.Columns)
		    anySummary |= AddColumn(col);
	    }

	    mainView.OptionsView.ShowFooter = anySummary;
	}

	private bool AddColumn(Column col)
	{
	    BandedGridColumn gridcol = new BandedGridColumn();
	    bool hasSummary = false;

	    if (col.Primary)
		m_priColumn = col;

	    gridcol.Tag = col;

	    gridcol.Name = col.Name + "col";
	    gridcol.FieldName = col.Name;

	    gridcol.Caption = col.DisplayName;
	    gridcol.Visible = col.Visible;

	    gridcol.OptionsColumn.ReadOnly = true;
	    gridcol.OptionsColumn.AllowEdit = false;

	    if (col.Function != ColumnFunction.None)
		hasSummary = true;

	    switch (col.Function)
	    {
	    default:
	    case ColumnFunction.None:
		gridcol.SummaryItem.SummaryType =
		    DevExpress.Data.SummaryItemType.None;
		break;

	    case ColumnFunction.Sum:
		gridcol.SummaryItem.SummaryType =
		    DevExpress.Data.SummaryItemType.Sum;
		break;

	    case ColumnFunction.Count:
		gridcol.SummaryItem.SummaryType =
		    DevExpress.Data.SummaryItemType.Count;
		break;

	    case ColumnFunction.Average:
		gridcol.SummaryItem.SummaryType =
		    DevExpress.Data.SummaryItemType.Average;
		break;

	    case ColumnFunction.Min:
		gridcol.SummaryItem.SummaryType =
		    DevExpress.Data.SummaryItemType.Min;
		break;

	    case ColumnFunction.Max:
		gridcol.SummaryItem.SummaryType =
		    DevExpress.Data.SummaryItemType.Max;
		break;
	    }

	    mainView.Bands[0].Columns.Add(gridcol);
	    return hasSummary;
	}

	public void RunSearch()
	{
	    if ((m_search == null) || DesignMode)
		return;

	    // Start the search thread.
	    Thread st = new Thread(new ThreadStart(SearchThread));
	    st.Start();

	    // Display the wait dialog.
	    if (m_waitForm.ShowDialog(this) == DialogResult.Cancel)
	    {
		// The user clicked "cancel" in the wait dialog, abort.

		if (st.IsAlive)
		{
		    st.Abort(); // Kill the thread.
		    st.Join(); // Wait for it to fully finish terminating.
		}

		// Notify instrested parties that the search was aborted.
		NotifyStatus(true);
	    }
	}

    public void ShowPrintPreview()
    {
        resultGrid.ShowPrintPreview();
    }

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

	public void ClearResults()
	{
	    if ((m_search == null) || DesignMode)
		return;

	    m_searchResults = null;
	    resultGrid.DataSource = null;
	}

	public void ClearFields()
	{
	    SetDefaultFieldValues();
	}

	#region Thread

	/// <summary>
	/// Updates teh search results grid with the results of
	/// a completed search.
	/// </summary>
	/// <param name="dt"></param>
	private void UpdateResults(DataTable dt)
	{
	    m_searchResults = dt;
	    resultGrid.DataSource = dt;
	    resultNavigator.DataSource = dt;

	    DateTime end = DateTime.Now;
	    m_lastRunTime = end.Subtract(m_start);

	    NotifyStatus(false);
	}

	private delegate void UpdateDel(DataTable dt);

	/// <summary>
	/// Independent thread that runs a search.
	/// </summary>
	private void SearchThread()
	{
	    DateTime m_start = DateTime.Now;
	    DataTable dt = m_search.Execute(m_fieldValues);

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

	#region Properties

	[Bindable(true)]
	[Browsable(true)]
	[Category("Data")]
	[Description("Gets or sets the search object to execute.")]
	public Search Search
	{
	    get { return m_search; }
	    set
	    {
		m_search = value;

		if (!DesignMode)
		{
		    InitParameterFields();
		    InitColumns();
		}
	    }
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
	public Dictionary<string, string> Hints
	{
	    get { return m_hints; }
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
	/// Gets a list of all the search results.
	/// </summary>
	[Bindable(true)]
	[Browsable(false)]
	public DataTable SearchResults
	{
	    get { return m_searchResults; }
	}

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
	[Category("Behavior")]
	[Description("Gets or sets the value indicating if the control " +
	    "should automatically search when the enter key is pressed.")]
	public bool SearchOnEnter
	{
	    get { return m_searchOnEnter; }
	    set { m_searchOnEnter = value; }
	}

	#endregion

	#region Events

	void fieldEdit_EditValueChanged(object sender, EventArgs e)
	{
	    /*
             * Update field value when the user changes the value.
             * 
             * Done this way because MS databinding is a bit weird.
             */
	    BaseEdit be = (BaseEdit)sender;
	    Field f = (Field)be.Tag;

	    if (be.EditValue != null)
	    {
		string s = be.EditValue.ToString().Trim();
		m_fieldValues[f.Name] = s;
	    }
	    else
	    {
		if (m_fieldValues.ContainsKey(f.Name))
		    m_fieldValues.Remove(f.Name);
	    }
	}

	void fieldEdit_KeyPress(object sender, KeyPressEventArgs e)
	{
	    // Handle the user hitting "enter" to begin searching.

	    if (e.KeyChar == '\r')
	    {
		e.Handled = true;

		if (m_searchOnEnter)
		    RunSearch();
	    }
	}

	private void mainView_DoubleClick(object sender, EventArgs e)
	{
	    if ((OpenItem == null) || (m_priColumn == null))
		return;

	    int[] rows = mainView.GetSelectedRows();
	    if (rows.Length > 0)
	    {
		DataRowView drv;

		drv = mainView.GetRow(rows[rows.Length - 1]) as DataRowView;

		object keyVal = drv.Row[m_priColumn.Name];

		if (keyVal != null)
		    OpenItem(this, new OpenItemEventArgs(keyVal));
	    }
	}

	#endregion
	
    }

    public class OpenItemEventArgs : EventArgs
    {
	private object m_keyValue;

	public OpenItemEventArgs(object keyValue)
	    : base()
	{
	    m_keyValue = keyValue;
	}

	public object KeyValue
	{
	    get { return m_keyValue; }
	}
    }
}
