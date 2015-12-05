namespace SCOUT.CS.UI
{
    partial class SearchEditor
    {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
	    if (disposing && (components != null))
	    {
		components.Dispose();
	    }
	    base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
	    DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
	    DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
	    this.fieldView = new DevExpress.XtraGrid.Views.Grid.GridView();
	    this.colOrdering = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.fieldOrderEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
	    this.colOid1 = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.fieldTypeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
	    this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.searchGrid = new DevExpress.XtraGrid.GridControl();
	    this.searchCollection = new DevExpress.Xpo.XPCollection();
	    this.columnView = new DevExpress.XtraGrid.Views.Grid.GridView();
	    this.colOrdering1 = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.columnOrderEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
	    this.colOid2 = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colFunction = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.columnFuncEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
	    this.colPrimary = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colVisible = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colDisplayName1 = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.searchView = new DevExpress.XtraGrid.Views.Grid.GridView();
	    this.colOid = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.colStoredProc = new DevExpress.XtraGrid.Columns.GridColumn();
	    this.storedProcEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
	    this.listItemView = new DevExpress.XtraGrid.Views.Grid.GridView();
	    ((System.ComponentModel.ISupportInitialize)(this.fieldView)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.fieldOrderEdit)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.fieldTypeEdit)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.searchCollection)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.columnView)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.columnOrderEdit)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.columnFuncEdit)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.searchView)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.storedProcEdit)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.listItemView)).BeginInit();
	    this.SuspendLayout();
	    // 
	    // fieldView
	    // 
	    this.fieldView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrdering,
            this.colOid1,
            this.colName1,
            this.colType,
            this.colDisplayName});
	    this.fieldView.GridControl = this.searchGrid;
	    this.fieldView.Name = "fieldView";
	    this.fieldView.OptionsCustomization.AllowGroup = false;
	    this.fieldView.OptionsCustomization.AllowSort = false;
	    this.fieldView.OptionsDetail.AllowExpandEmptyDetails = true;
	    this.fieldView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
	    this.fieldView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
	    this.fieldView.OptionsView.ShowGroupPanel = false;
	    this.fieldView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOrdering, DevExpress.Data.ColumnSortOrder.Ascending)});
	    this.fieldView.ViewCaption = "Fields";
	    // 
	    // colOrdering
	    // 
	    this.colOrdering.ColumnEdit = this.fieldOrderEdit;
	    this.colOrdering.FieldName = "Ordering";
	    this.colOrdering.Name = "colOrdering";
	    this.colOrdering.OptionsColumn.AllowSize = false;
	    this.colOrdering.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
	    this.colOrdering.ToolTip = "Order";
	    this.colOrdering.Visible = true;
	    this.colOrdering.VisibleIndex = 0;
	    this.colOrdering.Width = 32;
	    // 
	    // fieldOrderEdit
	    // 
	    this.fieldOrderEdit.AutoHeight = false;
	    this.fieldOrderEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
	    this.fieldOrderEdit.Name = "fieldOrderEdit";
	    this.fieldOrderEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
	    this.fieldOrderEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.fieldOrderEdit_ButtonClick);
	    // 
	    // colOid1
	    // 
	    this.colOid1.Caption = "Oid";
	    this.colOid1.FieldName = "Oid";
	    this.colOid1.Name = "colOid1";
	    this.colOid1.OptionsColumn.ShowInCustomizationForm = false;
	    // 
	    // colName1
	    // 
	    this.colName1.Caption = "Name";
	    this.colName1.FieldName = "Name";
	    this.colName1.Name = "colName1";
	    this.colName1.Visible = true;
	    this.colName1.VisibleIndex = 1;
	    this.colName1.Width = 121;
	    // 
	    // colType
	    // 
	    this.colType.Caption = "Type";
	    this.colType.ColumnEdit = this.fieldTypeEdit;
	    this.colType.FieldName = "Type";
	    this.colType.Name = "colType";
	    this.colType.Visible = true;
	    this.colType.VisibleIndex = 2;
	    this.colType.Width = 121;
	    // 
	    // fieldTypeEdit
	    // 
	    this.fieldTypeEdit.AutoHeight = false;
	    this.fieldTypeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Edit Details...")});
	    this.fieldTypeEdit.Items.AddRange(new object[] {
            "String",
            "Boolean",
            "Integer",
            "DateTime",
            "List"});
	    this.fieldTypeEdit.Name = "fieldTypeEdit";
	    this.fieldTypeEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
	    // 
	    // colDisplayName
	    // 
	    this.colDisplayName.Caption = "Display Name";
	    this.colDisplayName.FieldName = "DisplayName";
	    this.colDisplayName.Name = "colDisplayName";
	    this.colDisplayName.Visible = true;
	    this.colDisplayName.VisibleIndex = 3;
	    this.colDisplayName.Width = 121;
	    // 
	    // searchGrid
	    // 
	    this.searchGrid.DataSource = this.searchCollection;
	    this.searchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.searchGrid.EmbeddedNavigator.Name = "";
	    gridLevelNode1.LevelTemplate = this.fieldView;
	    gridLevelNode1.RelationName = "Fields";
	    gridLevelNode2.LevelTemplate = this.columnView;
	    gridLevelNode2.RelationName = "Columns";
	    this.searchGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
	    this.searchGrid.Location = new System.Drawing.Point(0, 0);
	    this.searchGrid.MainView = this.searchView;
	    this.searchGrid.Name = "searchGrid";
	    this.searchGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.storedProcEdit,
            this.fieldTypeEdit,
            this.columnFuncEdit,
            this.fieldOrderEdit,
            this.columnOrderEdit});
	    this.searchGrid.ShowOnlyPredefinedDetails = true;
	    this.searchGrid.Size = new System.Drawing.Size(506, 347);
	    this.searchGrid.TabIndex = 0;
	    this.searchGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.columnView,
            this.searchView,
            this.listItemView,
            this.fieldView});
	    // 
	    // searchCollection
	    // 
	    this.searchCollection.ObjectType = typeof(SCOUT.Entities.CS.Search.Search);
	    // 
	    // columnView
	    // 
	    this.columnView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrdering1,
            this.colOid2,
            this.colName2,
            this.colFunction,
            this.colPrimary,
            this.colVisible,
            this.colDisplayName1});
	    this.columnView.GridControl = this.searchGrid;
	    this.columnView.Name = "columnView";
	    this.columnView.OptionsCustomization.AllowGroup = false;
	    this.columnView.OptionsCustomization.AllowSort = false;
	    this.columnView.OptionsDetail.AllowExpandEmptyDetails = true;
	    this.columnView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
	    this.columnView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
	    this.columnView.OptionsView.ShowGroupPanel = false;
	    this.columnView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colOrdering1, DevExpress.Data.ColumnSortOrder.Ascending)});
	    this.columnView.ViewCaption = "Columns";
	    // 
	    // colOrdering1
	    // 
	    this.colOrdering1.ColumnEdit = this.columnOrderEdit;
	    this.colOrdering1.FieldName = "Ordering";
	    this.colOrdering1.Name = "colOrdering1";
	    this.colOrdering1.OptionsColumn.AllowSize = false;
	    this.colOrdering1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
	    this.colOrdering1.ToolTip = "Order";
	    this.colOrdering1.Visible = true;
	    this.colOrdering1.VisibleIndex = 0;
	    this.colOrdering1.Width = 32;
	    // 
	    // columnOrderEdit
	    // 
	    this.columnOrderEdit.AutoHeight = false;
	    this.columnOrderEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Up),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
	    this.columnOrderEdit.Name = "columnOrderEdit";
	    this.columnOrderEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
	    this.columnOrderEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.columnOrderEdit_ButtonClick);
	    // 
	    // colOid2
	    // 
	    this.colOid2.Caption = "Oid";
	    this.colOid2.FieldName = "Oid";
	    this.colOid2.Name = "colOid2";
	    this.colOid2.OptionsColumn.ShowInCustomizationForm = false;
	    // 
	    // colName2
	    // 
	    this.colName2.Caption = "Name";
	    this.colName2.FieldName = "Name";
	    this.colName2.Name = "colName2";
	    this.colName2.Visible = true;
	    this.colName2.VisibleIndex = 1;
	    this.colName2.Width = 80;
	    // 
	    // colFunction
	    // 
	    this.colFunction.Caption = "Function";
	    this.colFunction.ColumnEdit = this.columnFuncEdit;
	    this.colFunction.FieldName = "Function";
	    this.colFunction.Name = "colFunction";
	    this.colFunction.Visible = true;
	    this.colFunction.VisibleIndex = 2;
	    this.colFunction.Width = 80;
	    // 
	    // columnFuncEdit
	    // 
	    this.columnFuncEdit.AutoHeight = false;
	    this.columnFuncEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
	    this.columnFuncEdit.Items.AddRange(new object[] {
            "None",
            "Sum",
            "Count",
            "Average",
            "Min",
            "Max"});
	    this.columnFuncEdit.Name = "columnFuncEdit";
	    this.columnFuncEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
	    // 
	    // colPrimary
	    // 
	    this.colPrimary.Caption = "Primary";
	    this.colPrimary.FieldName = "Primary";
	    this.colPrimary.Name = "colPrimary";
	    this.colPrimary.Visible = true;
	    this.colPrimary.VisibleIndex = 3;
	    this.colPrimary.Width = 80;
	    // 
	    // colVisible
	    // 
	    this.colVisible.Caption = "Visible";
	    this.colVisible.FieldName = "Visible";
	    this.colVisible.Name = "colVisible";
	    this.colVisible.Visible = true;
	    this.colVisible.VisibleIndex = 4;
	    this.colVisible.Width = 80;
	    // 
	    // colDisplayName1
	    // 
	    this.colDisplayName1.Caption = "Display Name";
	    this.colDisplayName1.FieldName = "DisplayName";
	    this.colDisplayName1.Name = "colDisplayName1";
	    this.colDisplayName1.Visible = true;
	    this.colDisplayName1.VisibleIndex = 5;
	    this.colDisplayName1.Width = 80;
	    // 
	    // searchView
	    // 
	    this.searchView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOid,
            this.colName,
            this.colStoredProc});
	    this.searchView.GridControl = this.searchGrid;
	    this.searchView.Name = "searchView";
	    this.searchView.OptionsCustomization.AllowGroup = false;
	    this.searchView.OptionsDetail.AllowExpandEmptyDetails = true;
	    this.searchView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
	    this.searchView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
	    this.searchView.OptionsView.ShowGroupPanel = false;
	    // 
	    // colOid
	    // 
	    this.colOid.Caption = "Oid";
	    this.colOid.FieldName = "Oid";
	    this.colOid.Name = "colOid";
	    // 
	    // colName
	    // 
	    this.colName.Caption = "Name";
	    this.colName.FieldName = "Name";
	    this.colName.Name = "colName";
	    this.colName.Visible = true;
	    this.colName.VisibleIndex = 0;
	    // 
	    // colStoredProc
	    // 
	    this.colStoredProc.Caption = "Stored Procedure";
	    this.colStoredProc.ColumnEdit = this.storedProcEdit;
	    this.colStoredProc.FieldName = "StoredProc";
	    this.colStoredProc.Name = "colStoredProc";
	    this.colStoredProc.Visible = true;
	    this.colStoredProc.VisibleIndex = 1;
	    // 
	    // storedProcEdit
	    // 
	    this.storedProcEdit.AutoHeight = false;
	    this.storedProcEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
	    this.storedProcEdit.Name = "storedProcEdit";
	    this.storedProcEdit.NullText = "[Select a stored proceedure]";
	    // 
	    // listItemView
	    // 
	    this.listItemView.GridControl = this.searchGrid;
	    this.listItemView.Name = "listItemView";
	    this.listItemView.OptionsCustomization.AllowGroup = false;
	    this.listItemView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
	    this.listItemView.OptionsView.ShowGroupPanel = false;
	    this.listItemView.ViewCaption = "List Items";
	    // 
	    // SearchEditor
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(506, 347);
	    this.Controls.Add(this.searchGrid);
	    this.Name = "SearchEditor";
	    this.Text = "Search Editor";
	    ((System.ComponentModel.ISupportInitialize)(this.fieldView)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.fieldOrderEdit)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.fieldTypeEdit)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.searchCollection)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.columnView)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.columnOrderEdit)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.columnFuncEdit)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.searchView)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.storedProcEdit)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.listItemView)).EndInit();
	    this.ResumeLayout(false);

	}

	#endregion

	private DevExpress.Xpo.XPCollection searchCollection;
	private DevExpress.XtraGrid.GridControl searchGrid;
	private DevExpress.XtraGrid.Views.Grid.GridView searchView;
	private DevExpress.XtraGrid.Columns.GridColumn colOid;
	private DevExpress.XtraGrid.Columns.GridColumn colName;
	private DevExpress.XtraGrid.Columns.GridColumn colStoredProc;
	private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit storedProcEdit;
	private DevExpress.XtraGrid.Views.Grid.GridView fieldView;
	private DevExpress.XtraGrid.Views.Grid.GridView columnView;
	private DevExpress.XtraGrid.Columns.GridColumn colOid1;
	private DevExpress.XtraGrid.Columns.GridColumn colName1;
	private DevExpress.XtraGrid.Columns.GridColumn colType;
	private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
	private DevExpress.XtraGrid.Columns.GridColumn colOid2;
	private DevExpress.XtraGrid.Columns.GridColumn colName2;
	private DevExpress.XtraGrid.Columns.GridColumn colFunction;
	private DevExpress.XtraGrid.Columns.GridColumn colPrimary;
	private DevExpress.XtraGrid.Columns.GridColumn colVisible;
	private DevExpress.XtraGrid.Columns.GridColumn colDisplayName1;
	private DevExpress.XtraGrid.Views.Grid.GridView listItemView;
	private DevExpress.XtraEditors.Repository.RepositoryItemComboBox fieldTypeEdit;
	private DevExpress.XtraEditors.Repository.RepositoryItemComboBox columnFuncEdit;
	private DevExpress.XtraGrid.Columns.GridColumn colOrdering;
	private DevExpress.XtraGrid.Columns.GridColumn colOrdering1;
	private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit fieldOrderEdit;
	private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit columnOrderEdit;
    }
}