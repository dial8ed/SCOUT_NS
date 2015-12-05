using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using SCOUT.Entities.CS.Search;
using SCOUT.Core.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace SCOUT.CS.UI
{
    public partial class SearchEditor : DevExpress.XtraEditors.XtraForm
    {
	public SearchEditor()
	{
	    InitializeComponent();

	    InitStoredProcList();
	}

	#region Utility Functions

	private void InitStoredProcList()
	{
	    Query q = new Select("name")
		.From("sysobjects")
		.Where("type = 'P'")
		.OrderBy("name");

	    storedProcEdit.DataSource = q.ExecuteList<string>();
	}

	#endregion

	#region Events

	private void fieldOrderEdit_ButtonClick(object sender, 
	    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
	{
	    bool moveUp = (e.Button.Kind ==
		DevExpress.XtraEditors.Controls.ButtonPredefines.Up);

	    ColumnView cv = searchGrid.FocusedView as ColumnView;
	    Field curr = cv.GetRow(cv.FocusedRowHandle) as Field;

	    if (curr != null)
		curr.Search.MoveField(curr, moveUp);
	}

	private void columnOrderEdit_ButtonClick(object sender, 
	    DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
	{
	    bool moveUp = (e.Button.Kind ==
		DevExpress.XtraEditors.Controls.ButtonPredefines.Up);

	    ColumnView cv = searchGrid.FocusedView as ColumnView;
	    Column curr = cv.GetRow(cv.FocusedRowHandle) as Column;

	    if (curr != null)
		curr.Search.MoveColumn(curr, moveUp);
	}

	#endregion
    }
}