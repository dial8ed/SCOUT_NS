namespace SCOUT.WinForms.Inventory
{
    partial class ToteAddContentsForm
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
            this.contentsGrid = new DevExpress.XtraGrid.GridControl();
            this.contentsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.serialNumberText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contentsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialNumberText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.contentsGrid);
            this.layoutControl1.Controls.Add(this.addButton);
            this.layoutControl1.Controls.Add(this.serialNumberText);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(584, 313);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // contentsGrid
            // 
            this.contentsGrid.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.First.Enabled = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.First.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Last.Enabled = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.contentsGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.contentsGrid.Location = new System.Drawing.Point(89, 38);
            this.contentsGrid.MainView = this.contentsView;
            this.contentsGrid.Name = "contentsGrid";
            this.contentsGrid.ShowOnlyPredefinedDetails = true;
            this.contentsGrid.Size = new System.Drawing.Size(483, 263);
            this.contentsGrid.TabIndex = 6;
            this.contentsGrid.UseEmbeddedNavigator = true;
            this.contentsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.contentsView,
            this.gridView2});
            // 
            // contentsView
            // 
            this.contentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.contentsView.GridControl = this.contentsGrid;
            this.contentsView.Name = "contentsView";
            this.contentsView.OptionsBehavior.Editable = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Serial Number";
            this.gridColumn1.FieldName = "SerialNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Part Number";
            this.gridColumn2.FieldName = "Part.PartNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.contentsGrid;
            this.gridView2.Name = "gridView2";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(464, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(108, 22);
            this.addButton.StyleController = this.layoutControl1;
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            // 
            // serialNumberText
            // 
            this.serialNumberText.EnterMoveNextControl = true;
            this.serialNumberText.Location = new System.Drawing.Point(89, 12);
            this.serialNumberText.Name = "serialNumberText";
            this.serialNumberText.Size = new System.Drawing.Size(371, 20);
            this.serialNumberText.StyleController = this.layoutControl1;
            this.serialNumberText.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 313);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.serialNumberText;
            this.layoutControlItem1.CustomizationFormText = "Serial Number:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(452, 26);
            this.layoutControlItem1.Text = "Serial Number:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.addButton;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(452, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(112, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.contentsGrid;
            this.layoutControlItem3.CustomizationFormText = "Tote Contents:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(564, 267);
            this.layoutControlItem3.Text = "Tote Contents:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 13);
            // 
            // toteAddContentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 313);
            this.Controls.Add(this.layoutControl1);
            this.Name = "toteAddContentsForm";
            this.Text = "Add inventory items to a tote";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contentsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialNumberText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit serialNumberText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl contentsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView contentsView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}