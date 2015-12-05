namespace SCOUT.WinForms.Service
{
    partial class RouteProcessViewerForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.partNumberText = new DevExpress.XtraEditors.TextEdit();
            this.snText = new DevExpress.XtraEditors.TextEdit();
            this.processHistoryGrid = new DevExpress.XtraGrid.GridControl();
            this.processHistoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutViewColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partNumberText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processHistoryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processHistoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.partNumberText);
            this.layoutControl1.Controls.Add(this.snText);
            this.layoutControl1.Controls.Add(this.processHistoryGrid);
            this.layoutControl1.Controls.Add(this.okButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(835, 529);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // partNumberText
            // 
            this.partNumberText.Location = new System.Drawing.Point(493, 12);
            this.partNumberText.Name = "partNumberText";
            this.partNumberText.Properties.ReadOnly = true;
            this.partNumberText.Size = new System.Drawing.Size(330, 20);
            this.partNumberText.StyleController = this.layoutControl1;
            this.partNumberText.TabIndex = 7;
            this.partNumberText.TabStop = false;
            // 
            // snText
            // 
            this.snText.Location = new System.Drawing.Point(86, 12);
            this.snText.Name = "snText";
            this.snText.Properties.ReadOnly = true;
            this.snText.Size = new System.Drawing.Size(329, 20);
            this.snText.StyleController = this.layoutControl1;
            this.snText.TabIndex = 6;
            this.snText.TabStop = false;
            // 
            // processHistoryGrid
            // 
            this.processHistoryGrid.Location = new System.Drawing.Point(12, 36);
            this.processHistoryGrid.MainView = this.processHistoryView;
            this.processHistoryGrid.Name = "processHistoryGrid";
            this.processHistoryGrid.ShowOnlyPredefinedDetails = true;
            this.processHistoryGrid.Size = new System.Drawing.Size(811, 455);
            this.processHistoryGrid.TabIndex = 5;
            this.processHistoryGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.processHistoryView,
            this.gridView2});
            // 
            // processHistoryView
            // 
            this.processHistoryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.layoutViewColumn1,
            this.layoutViewColumn2,
            this.layoutViewColumn3,
            this.layoutViewColumn5,
            this.layoutViewColumn4});
            this.processHistoryView.GridControl = this.processHistoryGrid;
            this.processHistoryView.Name = "processHistoryView";
            this.processHistoryView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.layoutViewColumn5, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.processHistoryView.ViewCaption = "Unit service process history";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Service Route";
            this.gridColumn1.FieldName = "ServiceRoute!";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Program";
            this.gridColumn2.FieldName = "ShopfloorProgram";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "Station";
            this.layoutViewColumn1.FieldName = "Station!";
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            this.layoutViewColumn1.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn1.Visible = true;
            this.layoutViewColumn1.VisibleIndex = 2;
            // 
            // layoutViewColumn2
            // 
            this.layoutViewColumn2.Caption = "Outcome";
            this.layoutViewColumn2.FieldName = "StationOutcome!";
            this.layoutViewColumn2.Name = "layoutViewColumn2";
            this.layoutViewColumn2.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn2.Visible = true;
            this.layoutViewColumn2.VisibleIndex = 3;
            // 
            // layoutViewColumn3
            // 
            this.layoutViewColumn3.Caption = "Next Station";
            this.layoutViewColumn3.FieldName = "NextStationName";
            this.layoutViewColumn3.Name = "layoutViewColumn3";
            this.layoutViewColumn3.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn3.Visible = true;
            this.layoutViewColumn3.VisibleIndex = 4;
            // 
            // layoutViewColumn5
            // 
            this.layoutViewColumn5.Caption = "Last Update";
            this.layoutViewColumn5.DisplayFormat.FormatString = "MM/dd/yy hh:mm tt";
            this.layoutViewColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.layoutViewColumn5.FieldName = "LastUpdated";
            this.layoutViewColumn5.Name = "layoutViewColumn5";
            this.layoutViewColumn5.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn5.Visible = true;
            this.layoutViewColumn5.VisibleIndex = 5;
            // 
            // layoutViewColumn4
            // 
            this.layoutViewColumn4.Caption = "Updated By";
            this.layoutViewColumn4.FieldName = "UpdatedBy";
            this.layoutViewColumn4.Name = "layoutViewColumn4";
            this.layoutViewColumn4.OptionsColumn.AllowEdit = false;
            this.layoutViewColumn4.Visible = true;
            this.layoutViewColumn4.VisibleIndex = 6;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.processHistoryGrid;
            this.gridView2.Name = "gridView2";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(700, 495);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(123, 22);
            this.okButton.StyleController = this.layoutControl1;
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(835, 529);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.okButton;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(688, 483);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(127, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 483);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(688, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.processHistoryGrid;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(815, 459);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.snText;
            this.layoutControlItem3.CustomizationFormText = "Serial Number:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(407, 24);
            this.layoutControlItem3.Text = "Serial Number:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.partNumberText;
            this.layoutControlItem4.CustomizationFormText = "Part Number:";
            this.layoutControlItem4.Location = new System.Drawing.Point(407, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(408, 24);
            this.layoutControlItem4.Text = "Part Number:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(70, 13);
            // 
            // RouteProcessViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 529);
            this.Controls.Add(this.layoutControl1);
            this.Name = "RouteProcessViewerForm";
            this.Text = "Process Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.partNumberText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processHistoryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processHistoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl processHistoryGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Views.Grid.GridView processHistoryView;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn layoutViewColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.TextEdit partNumberText;
        private DevExpress.XtraEditors.TextEdit snText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}