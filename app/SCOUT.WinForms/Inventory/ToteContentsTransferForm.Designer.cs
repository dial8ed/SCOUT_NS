namespace SCOUT.WinForms.Inventory
{
    partial class ToteContentsTransferForm
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
            this.domainText = new DevExpress.XtraEditors.TextEdit();
            this.toteLookup = new DevExpress.XtraEditors.LookUpEdit();
            this.cancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.transferButton = new DevExpress.XtraEditors.SimpleButton();
            this.contentsPivot = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pnField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.qtyField = new DevExpress.XtraPivotGrid.PivotGridField();
            this.toteNameText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.domainText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toteLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentsPivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toteNameText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.domainText);
            this.layoutControl1.Controls.Add(this.toteLookup);
            this.layoutControl1.Controls.Add(this.cancelButton);
            this.layoutControl1.Controls.Add(this.transferButton);
            this.layoutControl1.Controls.Add(this.contentsPivot);
            this.layoutControl1.Controls.Add(this.toteNameText);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(601, 267);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // domainText
            // 
            this.domainText.Location = new System.Drawing.Point(410, 7);
            this.domainText.Name = "domainText";
            this.domainText.Size = new System.Drawing.Size(185, 20);
            this.domainText.StyleController = this.layoutControl1;
            this.domainText.TabIndex = 10;
            this.domainText.TabStop = false;
            // 
            // toteLookup
            // 
            this.toteLookup.EnterMoveNextControl = true;
            this.toteLookup.Location = new System.Drawing.Point(111, 239);
            this.toteLookup.Name = "toteLookup";
            this.toteLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toteLookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", 10, "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Label", 30, "Tote")});
            this.toteLookup.Properties.ImmediatePopup = true;
            this.toteLookup.Properties.NullText = "[Select destination tote]";
            this.toteLookup.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.toteLookup.Properties.SortColumnIndex = 1;
            this.toteLookup.Size = new System.Drawing.Size(213, 20);
            this.toteLookup.StyleController = this.layoutControl1;
            this.toteLookup.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(459, 239);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(136, 22);
            this.cancelButton.StyleController = this.layoutControl1;
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            // 
            // transferButton
            // 
            this.transferButton.Location = new System.Drawing.Point(335, 239);
            this.transferButton.Name = "transferButton";
            this.transferButton.Size = new System.Drawing.Size(113, 22);
            this.transferButton.StyleController = this.layoutControl1;
            this.transferButton.TabIndex = 1;
            this.transferButton.Text = "Transfer";
            // 
            // contentsPivot
            // 
            this.contentsPivot.Cursor = System.Windows.Forms.Cursors.Default;
            this.contentsPivot.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pnField,
            this.qtyField});
            this.contentsPivot.Location = new System.Drawing.Point(111, 38);
            this.contentsPivot.Name = "contentsPivot";
            this.contentsPivot.Size = new System.Drawing.Size(484, 190);
            this.contentsPivot.TabIndex = 6;
            this.contentsPivot.TabStop = false;
            // 
            // pnField
            // 
            this.pnField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pnField.AreaIndex = 0;
            this.pnField.FieldName = "PartNumber";
            this.pnField.Name = "pnField";
            // 
            // qtyField
            // 
            this.qtyField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.qtyField.AreaIndex = 0;
            this.qtyField.FieldName = "Qty";
            this.qtyField.Name = "qtyField";
            // 
            // toteNameText
            // 
            this.toteNameText.Location = new System.Drawing.Point(111, 7);
            this.toteNameText.Name = "toteNameText";
            this.toteNameText.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.toteNameText.Properties.Appearance.Options.UseBackColor = true;
            this.toteNameText.Properties.ReadOnly = true;
            this.toteNameText.Size = new System.Drawing.Size(184, 20);
            this.toteNameText.StyleController = this.layoutControl1;
            this.toteNameText.TabIndex = 5;
            this.toteNameText.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(601, 267);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.toteNameText;
            this.layoutControlItem2.CustomizationFormText = "Tote";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(299, 31);
            this.layoutControlItem2.Text = "Tote";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.contentsPivot;
            this.layoutControlItem3.CustomizationFormText = "Contents";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(599, 201);
            this.layoutControlItem3.Text = "Contents to transfer";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.transferButton;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(328, 232);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(124, 33);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cancelButton;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(452, 232);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(147, 33);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.toteLookup;
            this.layoutControlItem6.CustomizationFormText = "Transfer to domain:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 232);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(328, 33);
            this.layoutControlItem6.Text = "Transfer to tote:";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.domainText;
            this.layoutControlItem7.CustomizationFormText = "Domain";
            this.layoutControlItem7.Location = new System.Drawing.Point(299, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(300, 31);
            this.layoutControlItem7.Text = "Domain";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(99, 13);
            // 
            // ToteContentsTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 267);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ToteContentsTransferForm";
            this.Text = "ToteTransferForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.domainText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toteLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentsPivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toteNameText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit toteNameText;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton cancelButton;
        private DevExpress.XtraEditors.SimpleButton transferButton;
        private DevExpress.XtraPivotGrid.PivotGridControl contentsPivot;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraPivotGrid.PivotGridField pnField;
        private DevExpress.XtraPivotGrid.PivotGridField qtyField;
        private DevExpress.XtraEditors.LookUpEdit toteLookup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.TextEdit domainText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}