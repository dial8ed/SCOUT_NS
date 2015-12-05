namespace SCOUT.WinForms.Service
{
    partial class ServiceCommodityManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commodityGrid = new DevExpress.XtraGrid.GridControl();
            this.commodityView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.serviceCodeTypeList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.serviceCategoryList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.codeEditor = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.codesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rootLayout)).BeginInit();
            this.rootLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCodeTypeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCategoryList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.Controls.Add(this.commodityGrid);
            this.rootLayout.Size = new System.Drawing.Size(568, 478);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Size = new System.Drawing.Size(568, 478);
            // 
            // commodityGrid
            // 
            this.commodityGrid.DataMember = null;
            this.commodityGrid.Location = new System.Drawing.Point(4, 4);
            this.commodityGrid.MainView = this.commodityView;
            this.commodityGrid.Name = "commodityGrid";
            this.commodityGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemComboBox1,
            this.serviceCodeTypeList,
            this.serviceCategoryList,
            this.codeEditor});
            this.commodityGrid.ShowOnlyPredefinedDetails = true;
            this.commodityGrid.Size = new System.Drawing.Size(560, 470);
            this.commodityGrid.TabIndex = 6;
            this.commodityGrid.UseEmbeddedNavigator = true;
            this.commodityGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.commodityView,
            this.gridView2,
            this.codesView});
            // 
            // commodityView
            // 
            this.commodityView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.commodityView.GridControl = this.commodityGrid;
            this.commodityView.Name = "commodityView";
            this.commodityView.NewItemRowText = "New Service Commodity";
            this.commodityView.OptionsBehavior.AllowIncrementalSearch = true;
            this.commodityView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.commodityView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Failure",
            "Repair",
            "Scrap"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // serviceCodeTypeList
            // 
            this.serviceCodeTypeList.AutoHeight = false;
            this.serviceCodeTypeList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.serviceCodeTypeList.Name = "serviceCodeTypeList";
            this.serviceCodeTypeList.NullText = "Select fail/repair";
            // 
            // serviceCategoryList
            // 
            this.serviceCategoryList.AutoHeight = false;
            this.serviceCategoryList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.serviceCategoryList.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Category", "Category")});
            this.serviceCategoryList.DisplayMember = "Category";
            this.serviceCategoryList.Name = "serviceCategoryList";
            this.serviceCategoryList.NullText = "Select category";
            this.serviceCategoryList.UseCtrlScroll = false;
            this.serviceCategoryList.ValueMember = "This";
            // 
            // codeEditor
            // 
            this.codeEditor.AutoHeight = false;
            this.codeEditor.Name = "codeEditor";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.commodityGrid;
            this.gridView2.Name = "gridView2";
            // 
            // codesView
            // 
            this.codesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colType,
            this.colCode,
            this.colDescription,
            this.colCategory});
            this.codesView.GridControl = this.commodityGrid;
            this.codesView.Name = "codesView";
            this.codesView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.codesView.ViewCaption = "Service Codes";
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.ColumnEdit = this.serviceCodeTypeList;
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            this.colType.Width = 185;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.ColumnEdit = this.codeEditor;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 173;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 193;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Category";
            this.colCategory.ColumnEdit = this.serviceCategoryList;
            this.colCategory.FieldName = "Category!";
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 3;
            this.colCategory.Width = 197;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.commodityGrid;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(564, 474);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // ServiceCommodityManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ServiceCommodityManager";
            this.Size = new System.Drawing.Size(592, 534);
            ((System.ComponentModel.ISupportInitialize)(this.rootLayout)).EndInit();
            this.rootLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commodityView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCodeTypeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceCategoryList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl commodityGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView commodityView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit serviceCodeTypeList;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit serviceCategoryList;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit codeEditor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView codesView;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
