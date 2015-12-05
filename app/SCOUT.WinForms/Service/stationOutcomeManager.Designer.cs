namespace SCOUT.WinForms.Service
{
    partial class StationOutcomeManager
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
            this.outcomeListGrid = new DevExpress.XtraGrid.GridControl();
            this.outcomeList = new DevExpress.Xpo.XPCollection();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.outcomeListGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outcomeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // outcomeListGrid
            // 
            this.outcomeListGrid.DataSource = this.outcomeList;
            this.outcomeListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outcomeListGrid.Location = new System.Drawing.Point(0, 0);
            this.outcomeListGrid.MainView = this.gridView1;
            this.outcomeListGrid.Name = "outcomeListGrid";
            this.outcomeListGrid.ShowOnlyPredefinedDetails = true;
            this.outcomeListGrid.Size = new System.Drawing.Size(447, 293);
            this.outcomeListGrid.TabIndex = 0;
            this.outcomeListGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // outcomeList
            // 
            this.outcomeList.DeleteObjectOnRemove = true;
            this.outcomeList.DisplayableProperties = "This;Label";
            this.outcomeList.ObjectType = typeof(SCOUT.Core.Data.StationOutcome);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLabel});
            this.gridView1.GridControl = this.outcomeListGrid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // colLabel
            // 
            this.colLabel.Caption = "Outcome";
            this.colLabel.FieldName = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.outcomeListGrid;
            this.gridView2.Name = "gridView2";
            // 
            // stationOutcomeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.outcomeListGrid);
            this.Name = "stationOutcomeManager";
            this.Size = new System.Drawing.Size(447, 293);
            ((System.ComponentModel.ISupportInitialize)(this.outcomeListGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outcomeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl outcomeListGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.Xpo.XPCollection outcomeList;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
    }
}
