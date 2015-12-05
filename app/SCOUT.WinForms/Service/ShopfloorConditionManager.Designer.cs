namespace SCOUT.WinForms.Service
{
    partial class ShopfloorConditionManager
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
            this.conditionsGrid = new DevExpress.XtraGrid.GridControl();
            this.conditionsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.rootLayout)).BeginInit();
            this.rootLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // rootLayout
            // 
            this.rootLayout.Controls.Add(this.conditionsGrid);
            this.rootLayout.Size = new System.Drawing.Size(437, 353);
            // 
            // Root
            // 
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Size = new System.Drawing.Size(437, 353);
            // 
            // conditionsGrid
            // 
            this.conditionsGrid.Location = new System.Drawing.Point(4, 4);
            this.conditionsGrid.MainView = this.conditionsView;
            this.conditionsGrid.Name = "conditionsGrid";
            this.conditionsGrid.ShowOnlyPredefinedDetails = true;
            this.conditionsGrid.Size = new System.Drawing.Size(429, 345);
            this.conditionsGrid.TabIndex = 4;
            this.conditionsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.conditionsView});
            // 
            // conditionsView
            // 
            this.conditionsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.conditionsView.GridControl = this.conditionsGrid;
            this.conditionsView.Name = "conditionsView";
            this.conditionsView.OptionsCustomization.AllowGroup = false;
            this.conditionsView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.conditionsView.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.conditionsGrid;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(433, 349);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Condition";
            this.gridColumn1.FieldName = "Condition";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // ShopfloorConditionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ShopfloorConditionManager";
            this.Size = new System.Drawing.Size(461, 409);
            ((System.ComponentModel.ISupportInitialize)(this.rootLayout)).EndInit();
            this.rootLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl conditionsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView conditionsView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
