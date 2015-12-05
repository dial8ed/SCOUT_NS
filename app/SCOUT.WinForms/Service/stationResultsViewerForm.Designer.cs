namespace SCOUT.WinForms.Service
{
    partial class StationResultsViewerForm
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
            this.repairsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.failRepairsGrid = new DevExpress.XtraGrid.GridControl();
            this.failuresView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.componentsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.createDateText = new DevExpress.XtraEditors.TextEdit();
            this.createdByText = new DevExpress.XtraEditors.TextEdit();
            this.nextStationText = new DevExpress.XtraEditors.TextEdit();
            this.outcomeText = new DevExpress.XtraEditors.TextEdit();
            this.stepResultsLayout = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.stationText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repairsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failRepairsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.failuresView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createDateText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createdByText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextStationText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outcomeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepResultsLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // repairsView
            // 
            this.repairsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.repairsView.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Right;
            this.repairsView.GridControl = this.failRepairsGrid;
            this.repairsView.Name = "repairsView";
            this.repairsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Repair";
            this.gridColumn7.FieldName = "Repair";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Comments";
            this.gridColumn9.FieldName = "Comments";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Created By";
            this.gridColumn10.FieldName = "CreatedBy";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Create Date";
            this.gridColumn11.FieldName = "CreatedDate";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Computer";
            this.gridColumn12.FieldName = "MachineName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // failRepairsGrid
            // 
            gridLevelNode1.LevelTemplate = this.repairsView;
            gridLevelNode2.LevelTemplate = this.componentsView;
            gridLevelNode2.RelationName = "Components";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Repairs";
            this.failRepairsGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.failRepairsGrid.Location = new System.Drawing.Point(24, 81);
            this.failRepairsGrid.MainView = this.failuresView;
            this.failRepairsGrid.Name = "failRepairsGrid";
            this.failRepairsGrid.ShowOnlyPredefinedDetails = true;
            this.failRepairsGrid.Size = new System.Drawing.Size(736, 433);
            this.failRepairsGrid.TabIndex = 7;
            this.failRepairsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.failuresView,
            this.componentsView,
            this.repairsView});
            // 
            // failuresView
            // 
            this.failuresView.ChildGridLevelName = "Repairs";
            this.failuresView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.failuresView.GridControl = this.failRepairsGrid;
            this.failuresView.Name = "failuresView";
            this.failuresView.OptionsBehavior.Editable = false;
            this.failuresView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.failuresView.OptionsView.ShowPreview = true;
            this.failuresView.PreviewFieldName = "Comments";
            this.failuresView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fail Code";
            this.gridColumn1.FieldName = "FailCode!";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Created By";
            this.gridColumn3.FieldName = "CreatedBy";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Create Date";
            this.gridColumn4.FieldName = "CreatedDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Station";
            this.gridColumn5.FieldName = "Station!";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Computer";
            this.gridColumn6.FieldName = "MachineName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // componentsView
            // 
            this.componentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15});
            this.componentsView.GridControl = this.failRepairsGrid;
            this.componentsView.Name = "componentsView";
            this.componentsView.OptionsBehavior.Editable = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Component";
            this.gridColumn2.FieldName = "Component!";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Part In";
            this.gridColumn8.FieldName = "PartIn.PartNumber";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Part Out";
            this.gridColumn13.FieldName = "PartOut.PartNumber";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "SerialNumberIn";
            this.gridColumn14.FieldName = "SerialNumberIn";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "SerialNumberOut";
            this.gridColumn15.FieldName = "SerialNumberOut";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 4;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.createDateText);
            this.layoutControl1.Controls.Add(this.createdByText);
            this.layoutControl1.Controls.Add(this.nextStationText);
            this.layoutControl1.Controls.Add(this.outcomeText);
            this.layoutControl1.Controls.Add(this.stepResultsLayout);
            this.layoutControl1.Controls.Add(this.failRepairsGrid);
            this.layoutControl1.Controls.Add(this.stationText);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(784, 562);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // createDateText
            // 
            this.createDateText.Location = new System.Drawing.Point(653, 12);
            this.createDateText.Name = "createDateText";
            this.createDateText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.createDateText.Properties.Appearance.Options.UseBackColor = true;
            this.createDateText.Properties.ReadOnly = true;
            this.createDateText.Size = new System.Drawing.Size(119, 20);
            this.createDateText.StyleController = this.layoutControl1;
            this.createDateText.TabIndex = 9;
            // 
            // createdByText
            // 
            this.createdByText.Location = new System.Drawing.Point(350, 12);
            this.createdByText.Name = "createdByText";
            this.createdByText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.createdByText.Properties.Appearance.Options.UseBackColor = true;
            this.createdByText.Properties.ReadOnly = true;
            this.createdByText.Size = new System.Drawing.Size(231, 20);
            this.createdByText.StyleController = this.layoutControl1;
            this.createdByText.TabIndex = 8;
            // 
            // nextStationText
            // 
            this.nextStationText.Location = new System.Drawing.Point(462, 530);
            this.nextStationText.Name = "nextStationText";
            this.nextStationText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.nextStationText.Properties.Appearance.Options.UseBackColor = true;
            this.nextStationText.Properties.ReadOnly = true;
            this.nextStationText.Size = new System.Drawing.Size(310, 20);
            this.nextStationText.StyleController = this.layoutControl1;
            this.nextStationText.TabIndex = 6;
            // 
            // outcomeText
            // 
            this.outcomeText.Location = new System.Drawing.Point(80, 530);
            this.outcomeText.Name = "outcomeText";
            this.outcomeText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.outcomeText.Properties.Appearance.Options.UseBackColor = true;
            this.outcomeText.Properties.ReadOnly = true;
            this.outcomeText.Size = new System.Drawing.Size(310, 20);
            this.outcomeText.StyleController = this.layoutControl1;
            this.outcomeText.TabIndex = 5;
            // 
            // stepResultsLayout
            // 
            this.stepResultsLayout.Location = new System.Drawing.Point(24, 81);
            this.stepResultsLayout.Name = "stepResultsLayout";
            this.stepResultsLayout.Root = this.layoutControlGroup4;
            this.stepResultsLayout.Size = new System.Drawing.Size(736, 433);
            this.stepResultsLayout.TabIndex = 10;
            this.stepResultsLayout.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(736, 433);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // stationText
            // 
            this.stationText.Location = new System.Drawing.Point(80, 12);
            this.stationText.Name = "stationText";
            this.stationText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.stationText.Properties.Appearance.Options.UseBackColor = true;
            this.stationText.Properties.ReadOnly = true;
            this.stationText.Size = new System.Drawing.Size(198, 20);
            this.stationText.StyleController = this.layoutControl1;
            this.stationText.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.tabbedControlGroup1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 562);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.stationText;
            this.layoutControlItem1.CustomizationFormText = "Station:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(270, 24);
            this.layoutControlItem1.Text = "Station:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 13);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 35);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(764, 483);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Step Results";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1058, 437);
            this.layoutControlGroup2.Text = "Step Results";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.stepResultsLayout;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(740, 437);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Fail / Repairs";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1058, 437);
            this.layoutControlGroup3.Text = "Fail / Repairs";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.failRepairsGrid;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(740, 437);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.outcomeText;
            this.layoutControlItem2.CustomizationFormText = "Outcome:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 518);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(382, 24);
            this.layoutControlItem2.Text = "Outcome:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.nextStationText;
            this.layoutControlItem3.CustomizationFormText = "Next Station:";
            this.layoutControlItem3.Location = new System.Drawing.Point(382, 518);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(382, 24);
            this.layoutControlItem3.Text = "Next Station:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(764, 11);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.createdByText;
            this.layoutControlItem5.CustomizationFormText = "Created by:";
            this.layoutControlItem5.Location = new System.Drawing.Point(270, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(303, 24);
            this.layoutControlItem5.Text = "Created by:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.createDateText;
            this.layoutControlItem6.CustomizationFormText = "Create Date:";
            this.layoutControlItem6.Location = new System.Drawing.Point(573, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(191, 24);
            this.layoutControlItem6.Text = "Create Date:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(64, 13);
            // 
            // StationResultsViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.layoutControl1);
            this.Name = "StationResultsViewerForm";
            this.Text = "Station results viewer";
            ((System.ComponentModel.ISupportInitialize)(this.repairsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failRepairsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.failuresView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.createDateText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createdByText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextStationText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outcomeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepResultsLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit stationText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.TextEdit nextStationText;
        private DevExpress.XtraEditors.TextEdit outcomeText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl failRepairsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView failuresView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit createDateText;
        private DevExpress.XtraEditors.TextEdit createdByText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraDataLayout.DataLayoutControl stepResultsLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.Grid.GridView repairsView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Views.Grid.GridView componentsView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
    }
}