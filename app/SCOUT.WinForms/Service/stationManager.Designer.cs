using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    partial class StationManager
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
            this.stationsGrid = new DevExpress.XtraGrid.GridControl();
            this.stationList = new DevExpress.Xpo.XPCollection();
            this.stationsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stationTypeSelList = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.stationDomainSelList = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.domainList = new DevExpress.Xpo.XPCollection();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stationsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationTypeSelList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationDomainSelList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // stationsGrid
            // 
            this.stationsGrid.DataSource = this.stationList;
            this.stationsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationsGrid.Location = new System.Drawing.Point(0, 0);
            this.stationsGrid.MainView = this.stationsView;
            this.stationsGrid.Name = "stationsGrid";
            this.stationsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.stationTypeSelList,
            this.stationDomainSelList});
            this.stationsGrid.ShowOnlyPredefinedDetails = true;
            this.stationsGrid.Size = new System.Drawing.Size(595, 504);
            this.stationsGrid.TabIndex = 0;
            this.stationsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.stationsView});
            // 
            // stationList
            // 
            this.stationList.DisplayableProperties = "This;Id;Name;Type;Shopfloorline!;Shopfloorline!Key;Shopfloorline;Domain!;Domain!K" +
                "ey;Domain";
            this.stationList.ObjectType = typeof(SCOUT.Core.Data.ServiceStation);
            // 
            // stationsView
            // 
            this.stationsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.stationsView.GridControl = this.stationsGrid;
            this.stationsView.Name = "stationsView";
            this.stationsView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Type";
            this.gridColumn2.ColumnEdit = this.stationTypeSelList;
            this.gridColumn2.FieldName = "Type";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // stationTypeSelList
            // 
            this.stationTypeSelList.AutoHeight = false;
            this.stationTypeSelList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.stationTypeSelList.Name = "stationTypeSelList";
            this.stationTypeSelList.NullText = "[Select station type]";
            this.stationTypeSelList.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Domain";
            this.gridColumn3.ColumnEdit = this.stationDomainSelList;
            this.gridColumn3.FieldName = "Domain!";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // stationDomainSelList
            // 
            this.stationDomainSelList.AutoHeight = false;
            this.stationDomainSelList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.stationDomainSelList.DataSource = this.domainList;
            this.stationDomainSelList.DisplayMember = "FullLocation";
            this.stationDomainSelList.Name = "stationDomainSelList";
            this.stationDomainSelList.NullText = "[Select domain]";
            this.stationDomainSelList.ValueMember = "This!";
            this.stationDomainSelList.View = this.gridView1;
            // 
            // domainList
            // 
            this.domainList.DisplayableProperties = "This;FullLocation";
            this.domainList.ObjectType = typeof(SCOUT.Core.Data.Domain);
            this.domainList.SelectDeleted = true;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Shopfloorline";
            this.gridColumn4.FieldName = "Shopfloorline!";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // stationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stationsGrid);
            this.Name = "stationManager";
            this.Size = new System.Drawing.Size(595, 504);
            ((System.ComponentModel.ISupportInitialize)(this.stationsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationTypeSelList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationDomainSelList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.domainList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl stationsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView stationsView;
        private DevExpress.Xpo.XPCollection stationList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit stationTypeSelList;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit stationDomainSelList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Xpo.XPCollection domainList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
