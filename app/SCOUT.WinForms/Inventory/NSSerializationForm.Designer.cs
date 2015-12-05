namespace SCOUT.WinForms.Inventory
{
    partial class NSSerializationForm
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
            this.exportExcelLink = new DevExpress.XtraEditors.HyperLinkEdit();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.revText = new DevExpress.XtraEditors.TextEdit();
            this.snGrid = new DevExpress.XtraGrid.GridControl();
            this.snView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clearButton = new DevExpress.XtraEditors.SimpleButton();
            this.snText = new DevExpress.XtraEditors.TextEdit();
            this.lotIdText = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.expectedText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.totalText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exportExcelLink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.revText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotIdText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expectedText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.exportExcelLink);
            this.layoutControl1.Controls.Add(this.okButton);
            this.layoutControl1.Controls.Add(this.revText);
            this.layoutControl1.Controls.Add(this.snGrid);
            this.layoutControl1.Controls.Add(this.clearButton);
            this.layoutControl1.Controls.Add(this.snText);
            this.layoutControl1.Controls.Add(this.lotIdText);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(706, 455);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // exportExcelLink
            // 
            this.exportExcelLink.EditValue = "Excel";
            this.exportExcelLink.Location = new System.Drawing.Point(532, 279);
            this.exportExcelLink.Name = "exportExcelLink";
            this.exportExcelLink.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.exportExcelLink.Properties.Appearance.Options.UseBackColor = true;
            this.exportExcelLink.Properties.Image = global::SCOUT.WinForms.Properties.Resources.page_excel;
            this.exportExcelLink.Size = new System.Drawing.Size(157, 24);
            this.exportExcelLink.StyleController = this.layoutControl1;
            this.exportExcelLink.TabIndex = 12;
            this.exportExcelLink.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.exportExcelLink_OpenLink);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(527, 36);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(97, 22);
            this.okButton.StyleController = this.layoutControl1;
            this.okButton.TabIndex = 11;
            this.okButton.Text = "Ok";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // revText
            // 
            this.revText.Location = new System.Drawing.Point(428, 36);
            this.revText.Name = "revText";
            this.revText.Size = new System.Drawing.Size(95, 20);
            this.revText.StyleController = this.layoutControl1;
            this.revText.TabIndex = 9;
            // 
            // snGrid
            // 
            this.snGrid.Location = new System.Drawing.Point(12, 62);
            this.snGrid.MainView = this.snView;
            this.snGrid.Name = "snGrid";
            this.snGrid.ShowOnlyPredefinedDetails = true;
            this.snGrid.Size = new System.Drawing.Size(511, 381);
            this.snGrid.TabIndex = 7;
            this.snGrid.UseEmbeddedNavigator = true;
            this.snGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.snView});
            // 
            // snView
            // 
            this.snView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4});
            this.snView.GridControl = this.snGrid;
            this.snView.Name = "snView";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "LotId";
            this.gridColumn1.FieldName = "LotId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "SerialNumber";
            this.gridColumn2.FieldName = "SerialNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Revision";
            this.gridColumn5.FieldName = "Revision";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "UserName";
            this.gridColumn3.FieldName = "UserName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "TimeStamp";
            this.gridColumn4.FieldName = "TimeStamp";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(628, 36);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(66, 22);
            this.clearButton.StyleController = this.layoutControl1;
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // snText
            // 
            this.snText.Location = new System.Drawing.Point(86, 36);
            this.snText.Name = "snText";
            this.snText.Size = new System.Drawing.Size(264, 20);
            this.snText.StyleController = this.layoutControl1;
            this.snText.TabIndex = 5;
            // 
            // lotIdText
            // 
            this.lotIdText.Enabled = false;
            this.lotIdText.Location = new System.Drawing.Point(86, 12);
            this.lotIdText.Name = "lotIdText";
            this.lotIdText.Size = new System.Drawing.Size(608, 20);
            this.lotIdText.StyleController = this.layoutControl1;
            this.lotIdText.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.expectedText);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.totalText);
            this.groupControl1.Location = new System.Drawing.Point(527, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(167, 188);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Summary";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Expected:";
            // 
            // expectedText
            // 
            this.expectedText.Location = new System.Drawing.Point(60, 63);
            this.expectedText.Name = "expectedText";
            this.expectedText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.expectedText.Properties.Appearance.Options.UseBackColor = true;
            this.expectedText.Properties.ReadOnly = true;
            this.expectedText.Size = new System.Drawing.Size(99, 20);
            this.expectedText.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Total:";
            // 
            // totalText
            // 
            this.totalText.Location = new System.Drawing.Point(60, 33);
            this.totalText.Name = "totalText";
            this.totalText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.totalText.Properties.Appearance.Options.UseBackColor = true;
            this.totalText.Properties.ReadOnly = true;
            this.totalText.Size = new System.Drawing.Size(99, 20);
            this.totalText.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(706, 455);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lotIdText;
            this.layoutControlItem1.CustomizationFormText = "Lot Id:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsToolTip.ToolTip = "Scan the lot id that will be recording serial numbers for.";
            this.layoutControlItem1.Size = new System.Drawing.Size(686, 24);
            this.layoutControlItem1.Text = "Lot Id:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.snText;
            this.layoutControlItem2.CustomizationFormText = "Serial Number:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(342, 26);
            this.layoutControlItem2.Text = "Serial Number:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.clearButton;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(616, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(70, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.snGrid;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(515, 385);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.groupControl1;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(515, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(171, 192);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.revText;
            this.layoutControlItem6.CustomizationFormText = "Revision:";
            this.layoutControlItem6.Location = new System.Drawing.Point(342, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(173, 26);
            this.layoutControlItem6.Text = "Revision:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.okButton;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(515, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(101, 26);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Export";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem7});
            this.layoutControlGroup2.Location = new System.Drawing.Point(515, 242);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(171, 193);
            this.layoutControlGroup2.Text = "Export";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "Output";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(161, 135);
            this.emptySpaceItem1.Text = "Output";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.exportExcelLink;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(161, 28);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // NSSerializationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 455);
            this.Controls.Add(this.layoutControl1);
            this.Name = "NSSerializationForm";
            this.Text = "NS Serialization";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exportExcelLink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.revText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotIdText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expectedText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton clearButton;
        private DevExpress.XtraEditors.TextEdit snText;
        private DevExpress.XtraEditors.TextEdit lotIdText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl snGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView snView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit expectedText;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit totalText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.TextEdit revText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.HyperLinkEdit exportExcelLink;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}