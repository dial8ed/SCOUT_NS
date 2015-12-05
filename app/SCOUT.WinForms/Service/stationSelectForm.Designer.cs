namespace SCOUT.WinForms.Service
{
    partial class StationSelectForm
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
            this.stationGrid = new DevExpress.XtraGrid.GridControl();
            this.stationsView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.colName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.Item2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.sflLookup = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sflList = new DevExpress.Xpo.XPCollection();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sflLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sflList)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.stationGrid);
            this.layoutControl1.Controls.Add(this.sflLookup);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(622, 417);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // stationGrid
            // 
            this.stationGrid.Location = new System.Drawing.Point(7, 38);
            this.stationGrid.MainView = this.stationsView;
            this.stationGrid.Name = "stationGrid";
            this.stationGrid.Size = new System.Drawing.Size(609, 373);
            this.stationGrid.TabIndex = 5;
            this.stationGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.stationsView});
            // 
            // stationsView
            // 
            this.stationsView.CardCaptionFormat = "Station [{0} of {1}]";
            this.stationsView.CardMinSize = new System.Drawing.Size(236, 117);
            this.stationsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.colName,
            this.layoutViewColumn3});
            this.stationsView.GridControl = this.stationGrid;
            this.stationsView.Name = "stationsView";
            this.stationsView.TemplateCard = this.layoutViewCard1;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.LayoutViewField = this.Item1;
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            // 
            // Item1
            // 
            this.Item1.EditorPreferredWidth = 151;
            this.Item1.Location = new System.Drawing.Point(0, 0);
            this.Item1.Name = "Item1";
            this.Item1.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 9, 9);
            this.Item1.Size = new System.Drawing.Size(216, 37);
            this.Item1.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.Item1.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item1.TextSize = new System.Drawing.Size(39, 20);
            // 
            // layoutViewColumn3
            // 
            this.layoutViewColumn3.Caption = "Domain";
            this.layoutViewColumn3.FieldName = "Domain!";
            this.layoutViewColumn3.LayoutViewField = this.Item2;
            this.layoutViewColumn3.Name = "layoutViewColumn3";
            this.layoutViewColumn3.OptionsColumn.AllowEdit = false;
            // 
            // Item2
            // 
            this.Item2.EditorPreferredWidth = 151;
            this.Item2.Location = new System.Drawing.Point(0, 37);
            this.Item2.Name = "Item2";
            this.Item2.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 9, 9);
            this.Item2.Size = new System.Drawing.Size(216, 56);
            this.Item2.Spacing = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.Item2.TextLocation = DevExpress.Utils.Locations.Left;
            this.Item2.TextSize = new System.Drawing.Size(39, 20);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewCard1";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Item1,
            this.Item2});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(9, 9, 9, 9);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // sflLookup
            // 
            this.sflLookup.Location = new System.Drawing.Point(78, 7);
            this.sflLookup.Name = "sflLookup";
            this.sflLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sflLookup.Properties.NullText = "[Choose shopfloorline]";
            this.sflLookup.Size = new System.Drawing.Size(538, 20);
            this.sflLookup.StyleController = this.layoutControl1;
            this.sflLookup.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(622, 417);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sflLookup;
            this.layoutControlItem1.CustomizationFormText = "Shopfloorline:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(620, 31);
            this.layoutControlItem1.Text = "Shopfloorline:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.stationGrid;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(620, 384);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // sflList
            // 
            this.sflList.DisplayableProperties = "This;Label;FullLocation";
            this.sflList.ObjectType = typeof(SCOUT.Core.Data.Shopfloorline);
            // 
            // stationSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 417);
            this.Controls.Add(this.layoutControl1);
            this.Name = "stationSelectForm";
            this.Text = "Station Selector";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stationsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sflLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sflList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl stationGrid;
        private DevExpress.XtraGrid.Views.Layout.LayoutView stationsView;
        private DevExpress.XtraEditors.LookUpEdit sflLookup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn colName;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn layoutViewColumn3;
        private DevExpress.Xpo.XPCollection sflList;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField Item2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}