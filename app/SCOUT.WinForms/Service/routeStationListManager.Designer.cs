namespace SCOUT.WinForms.Service
{
    partial class RouteStationListManager
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
            this.xpCollection1 = new DevExpress.Xpo.XPCollection();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colId = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colAllowRepairs = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colIncluded = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.colStationType = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewColumn4 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.Item1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Item7 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewField1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item8 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.Item9 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            ((System.ComponentModel.ISupportInitialize)(this.stationsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item9)).BeginInit();
            this.SuspendLayout();
            // 
            // stationsGrid
            // 
            this.stationsGrid.DataSource = this.xpCollection1;
            this.stationsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stationsGrid.Location = new System.Drawing.Point(0, 0);
            this.stationsGrid.MainView = this.layoutView1;
            this.stationsGrid.Name = "stationsGrid";
            this.stationsGrid.Size = new System.Drawing.Size(660, 569);
            this.stationsGrid.TabIndex = 0;
            this.stationsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1,
            this.gridView2});
            // 
            // xpCollection1
            // 
            this.xpCollection1.DisplayableProperties = "This;Id;Station!;Station!Key;Station;AllowRepairs;Included;Name;StationType;Servi" +
                "ceRoute!;ServiceRoute!Key;ServiceRoute;Steps;Documents;Outcomes;FailCategories";
            this.xpCollection1.ObjectType = typeof(SCOUT.Core.Data.RouteStation);
            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Station {0}";
            this.layoutView1.CardMinSize = new System.Drawing.Size(278, 138);
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colId,
            this.layoutViewColumn1,
            this.layoutViewColumn2,
            this.colAllowRepairs,
            this.colIncluded,
            this.colName,
            this.colStationType,
            this.layoutViewColumn3,
            this.layoutViewColumn4});
            this.layoutView1.GridControl = this.stationsGrid;
            this.layoutView1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField1,
            this.Item2,
            this.Item3,
            this.Item8,
            this.Item9});
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsItemText.TextToControlDistance = 0;
            this.layoutView1.OptionsView.CardsAlignment = DevExpress.XtraGrid.Views.Layout.CardsAlignment.Far;
            this.layoutView1.OptionsView.ShowCardFieldBorders = true;
            this.layoutView1.OptionsView.ShowHeaderPanel = false;
            this.layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiColumn;
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.LayoutViewField = this.layoutViewField1;
            this.colId.Name = "colId";
            // 
            // layoutViewColumn1
            // 
            this.layoutViewColumn1.Caption = "Station";
            this.layoutViewColumn1.FieldName = "Station!";
            this.layoutViewColumn1.LayoutViewField = this.Item2;
            this.layoutViewColumn1.Name = "layoutViewColumn1";
            // 
            // layoutViewColumn2
            // 
            this.layoutViewColumn2.Caption = "Station";
            this.layoutViewColumn2.FieldName = "Station!Key";
            this.layoutViewColumn2.LayoutViewField = this.Item3;
            this.layoutViewColumn2.Name = "layoutViewColumn2";
            // 
            // colAllowRepairs
            // 
            this.colAllowRepairs.Caption = "AllowRepairs";
            this.colAllowRepairs.FieldName = "AllowRepairs";
            this.colAllowRepairs.LayoutViewField = this.Item5;
            this.colAllowRepairs.Name = "colAllowRepairs";
            // 
            // colIncluded
            // 
            this.colIncluded.Caption = "Included";
            this.colIncluded.FieldName = "Included";
            this.colIncluded.LayoutViewField = this.Item1;
            this.colIncluded.Name = "colIncluded";
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.LayoutViewField = this.Item4;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.ReadOnly = true;
            // 
            // colStationType
            // 
            this.colStationType.Caption = "Type";
            this.colStationType.CustomizationCaption = "Type";
            this.colStationType.FieldName = "StationType";
            this.colStationType.LayoutViewField = this.Item7;
            this.colStationType.Name = "colStationType";
            this.colStationType.OptionsColumn.AllowEdit = false;
            this.colStationType.OptionsColumn.ReadOnly = true;
            // 
            // layoutViewColumn3
            // 
            this.layoutViewColumn3.Caption = "ServiceRoute";
            this.layoutViewColumn3.FieldName = "ServiceRoute!";
            this.layoutViewColumn3.LayoutViewField = this.Item8;
            this.layoutViewColumn3.Name = "layoutViewColumn3";
            // 
            // layoutViewColumn4
            // 
            this.layoutViewColumn4.Caption = "ServiceRoute";
            this.layoutViewColumn4.FieldName = "ServiceRoute!Key";
            this.layoutViewColumn4.LayoutViewField = this.Item9;
            this.layoutViewColumn4.Name = "layoutViewColumn4";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.stationsGrid;
            this.gridView2.Name = "gridView2";
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewCard1";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Item1,
            this.Item4,
            this.Item5,
            this.Item6,
            this.Item7});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // Item1
            // 
            this.Item1.EditorPreferredWidth = 190;
            this.Item1.Location = new System.Drawing.Point(0, 0);
            this.Item1.Name = "Item1";
            this.Item1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item1.Size = new System.Drawing.Size(268, 29);
            this.Item1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item1.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item1.TextSize = new System.Drawing.Size(65, 20);
            this.Item1.TextToControlDistance = 0;
            // 
            // Item4
            // 
            this.Item4.EditorPreferredWidth = 190;
            this.Item4.Location = new System.Drawing.Point(0, 58);
            this.Item4.Name = "Item4";
            this.Item4.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item4.Size = new System.Drawing.Size(268, 29);
            this.Item4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item4.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item4.TextSize = new System.Drawing.Size(65, 20);
            this.Item4.TextToControlDistance = 0;
            // 
            // Item5
            // 
            this.Item5.EditorPreferredWidth = 190;
            this.Item5.Location = new System.Drawing.Point(0, 87);
            this.Item5.Name = "Item5";
            this.Item5.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item5.Size = new System.Drawing.Size(268, 29);
            this.Item5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item5.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item5.TextSize = new System.Drawing.Size(65, 20);
            this.Item5.TextToControlDistance = 0;
            // 
            // Item6
            // 
            this.Item6.CustomizationFormText = "item1";
            this.Item6.Location = new System.Drawing.Point(0, 116);
            this.Item6.Name = "Item6";
            this.Item6.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item6.Size = new System.Drawing.Size(268, 10);
            this.Item6.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item6.Text = "item1";
            this.Item6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Item7
            // 
            this.Item7.EditorPreferredWidth = 227;
            this.Item7.Location = new System.Drawing.Point(0, 29);
            this.Item7.Name = "Item7";
            this.Item7.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item7.Size = new System.Drawing.Size(268, 29);
            this.Item7.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.Item7.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item7.TextSize = new System.Drawing.Size(28, 20);
            this.Item7.TextToControlDistance = 0;
            // 
            // layoutViewField1
            // 
            this.layoutViewField1.EditorPreferredWidth = 20;
            this.layoutViewField1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField1.Name = "layoutViewField1";
            this.layoutViewField1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutViewField1.Size = new System.Drawing.Size(268, 126);
            this.layoutViewField1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutViewField1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutViewField1.TextSize = new System.Drawing.Size(68, 20);
            // 
            // Item2
            // 
            this.Item2.EditorPreferredWidth = 20;
            this.Item2.Location = new System.Drawing.Point(0, 0);
            this.Item2.Name = "Item2";
            this.Item2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item2.Size = new System.Drawing.Size(268, 126);
            this.Item2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item2.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item2.TextSize = new System.Drawing.Size(68, 20);
            // 
            // Item3
            // 
            this.Item3.EditorPreferredWidth = 20;
            this.Item3.Location = new System.Drawing.Point(0, 0);
            this.Item3.Name = "Item3";
            this.Item3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item3.Size = new System.Drawing.Size(268, 126);
            this.Item3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item3.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item3.TextSize = new System.Drawing.Size(68, 20);
            // 
            // Item8
            // 
            this.Item8.EditorPreferredWidth = 20;
            this.Item8.Location = new System.Drawing.Point(0, 0);
            this.Item8.Name = "Item8";
            this.Item8.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item8.Size = new System.Drawing.Size(268, 126);
            this.Item8.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item8.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item8.TextSize = new System.Drawing.Size(68, 20);
            // 
            // Item9
            // 
            this.Item9.EditorPreferredWidth = 20;
            this.Item9.Location = new System.Drawing.Point(0, 0);
            this.Item9.Name = "Item9";
            this.Item9.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.Item9.Size = new System.Drawing.Size(268, 126);
            this.Item9.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.Item9.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item9.TextSize = new System.Drawing.Size(68, 20);
            // 
            // routeStationListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stationsGrid);
            this.Name = "routeStationListManager";
            this.Size = new System.Drawing.Size(660, 569);
            ((System.ComponentModel.ISupportInitialize)(this.stationsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl stationsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.Xpo.XPCollection xpCollection1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colId;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colAllowRepairs;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colIncluded;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colStationType;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item7;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item8;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item9;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.EmptySpaceItem Item6;
    }
}
