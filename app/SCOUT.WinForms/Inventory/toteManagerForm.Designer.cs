namespace SCOUT.WinForms.Inventory
{
    partial class ToteManagerForm
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
            this.labelText = new DevExpress.XtraEditors.TextEdit();
            this.locationText = new DevExpress.XtraEditors.TextEdit();
            this.toteTypeText = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.toteContentsGrid = new DevExpress.XtraGrid.GridControl();
            this.contentsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.transferToteLink = new DevExpress.XtraNavBar.NavBarItem();
            this.exportLink = new DevExpress.XtraNavBar.NavBarItem();
            this.printLabelItem = new DevExpress.XtraNavBar.NavBarItem();
            this.refreshToteLink = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.removeItemsLink = new DevExpress.XtraNavBar.NavBarItem();
            this.transferItemsLink = new DevExpress.XtraNavBar.NavBarItem();
            this.addItemsLink = new DevExpress.XtraNavBar.NavBarItem();
            this.putAwayItemsLink = new DevExpress.XtraNavBar.NavBarItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.locationLabel = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toteTypeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toteContentsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelText);
            this.layoutControl1.Controls.Add(this.locationText);
            this.layoutControl1.Controls.Add(this.toteTypeText);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.navBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(951, 554);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelText
            // 
            this.labelText.Location = new System.Drawing.Point(249, 12);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(253, 20);
            this.labelText.StyleController = this.layoutControl1;
            this.labelText.TabIndex = 8;
            // 
            // locationText
            // 
            this.locationText.Enabled = false;
            this.locationText.Location = new System.Drawing.Point(799, 12);
            this.locationText.Name = "locationText";
            this.locationText.Size = new System.Drawing.Size(140, 20);
            this.locationText.StyleController = this.layoutControl1;
            this.locationText.TabIndex = 7;
            // 
            // toteTypeText
            // 
            this.toteTypeText.Enabled = false;
            this.toteTypeText.Location = new System.Drawing.Point(573, 12);
            this.toteTypeText.Name = "toteTypeText";
            this.toteTypeText.Size = new System.Drawing.Size(155, 20);
            this.toteTypeText.StyleController = this.layoutControl1;
            this.toteTypeText.TabIndex = 6;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.toteContentsGrid);
            this.groupControl1.Location = new System.Drawing.Point(182, 36);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(757, 506);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Tote Contents";
            // 
            // toteContentsGrid
            // 
            this.toteContentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toteContentsGrid.Location = new System.Drawing.Point(2, 22);
            this.toteContentsGrid.MainView = this.contentsView;
            this.toteContentsGrid.Name = "toteContentsGrid";
            this.toteContentsGrid.ShowOnlyPredefinedDetails = true;
            this.toteContentsGrid.Size = new System.Drawing.Size(753, 482);
            this.toteContentsGrid.TabIndex = 0;
            this.toteContentsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.contentsView});
            // 
            // contentsView
            // 
            this.contentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.contentsView.GridControl = this.toteContentsGrid;
            this.contentsView.Name = "contentsView";
            this.contentsView.OptionsBehavior.AllowIncrementalSearch = true;
            this.contentsView.OptionsBehavior.Editable = false;
            this.contentsView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.contentsView.OptionsSelection.MultiSelect = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "LotId";
            this.gridColumn1.FieldName = "LotId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Serial Number";
            this.gridColumn9.FieldName = "SerialNumber";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "PartNumber";
            this.gridColumn3.FieldName = "PartNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Qty";
            this.gridColumn2.FieldName = "Qty";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Shopfloorline";
            this.gridColumn4.FieldName = "Shopfloorline!";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Domain";
            this.gridColumn5.FieldName = "Domain!";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "RMA";
            this.gridColumn6.FieldName = "RMA";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "PO";
            this.gridColumn7.FieldName = "PO";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Other";
            this.gridColumn8.FieldName = "Other";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.transferToteLink,
            this.removeItemsLink,
            this.exportLink,
            this.transferItemsLink,
            this.printLabelItem,
            this.refreshToteLink,
            this.addItemsLink,
            this.putAwayItemsLink});
            this.navBarControl1.Location = new System.Drawing.Point(12, 12);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 159;
            this.navBarControl1.Size = new System.Drawing.Size(166, 530);
            this.navBarControl1.TabIndex = 4;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Tote";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.transferToteLink),
            new DevExpress.XtraNavBar.NavBarItemLink(this.exportLink),
            new DevExpress.XtraNavBar.NavBarItemLink(this.printLabelItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.refreshToteLink)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // transferToteLink
            // 
            this.transferToteLink.Caption = "Transfer Tote";
            this.transferToteLink.Name = "transferToteLink";
            this.transferToteLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.box;
            // 
            // exportLink
            // 
            this.exportLink.Caption = "Export To Excel";
            this.exportLink.Name = "exportLink";
            this.exportLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.page_excel;
            // 
            // printLabelItem
            // 
            this.printLabelItem.Caption = "Print Label";
            this.printLabelItem.Name = "printLabelItem";
            this.printLabelItem.SmallImage = global::SCOUT.WinForms.Properties.Resources.printer;
            this.printLabelItem.Tag = "totes.print-label";
            // 
            // refreshToteLink
            // 
            this.refreshToteLink.Caption = "Refresh";
            this.refreshToteLink.Name = "refreshToteLink";
            this.refreshToteLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.database_refresh;
            this.refreshToteLink.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.refreshToteLink_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Contents";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.removeItemsLink),
            new DevExpress.XtraNavBar.NavBarItemLink(this.transferItemsLink),
            new DevExpress.XtraNavBar.NavBarItemLink(this.addItemsLink),
            new DevExpress.XtraNavBar.NavBarItemLink(this.putAwayItemsLink)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // removeItemsLink
            // 
            this.removeItemsLink.Caption = "Remove Item(s)";
            this.removeItemsLink.Name = "removeItemsLink";
            this.removeItemsLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.delete;
            // 
            // transferItemsLink
            // 
            this.transferItemsLink.Caption = "Transfer Item(s)";
            this.transferItemsLink.Name = "transferItemsLink";
            this.transferItemsLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.application_go;
            // 
            // addItemsLink
            // 
            this.addItemsLink.Caption = "Add Item(s)";
            this.addItemsLink.Name = "addItemsLink";
            this.addItemsLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.add;
            // 
            // putAwayItemsLink
            // 
            this.putAwayItemsLink.Caption = "Put Away Item(s)";
            this.putAwayItemsLink.Name = "putAwayItemsLink";
            this.putAwayItemsLink.SmallImage = global::SCOUT.WinForms.Properties.Resources.basket_put;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.locationLabel,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(951, 554);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.navBarControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(170, 534);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupControl1;
            this.layoutControlItem2.CustomizationFormText = "Tote Contents";
            this.layoutControlItem2.Location = new System.Drawing.Point(170, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(761, 510);
            this.layoutControlItem2.Text = "Tote Contents";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.toteTypeText;
            this.layoutControlItem3.CustomizationFormText = "Tote Type:";
            this.layoutControlItem3.Location = new System.Drawing.Point(494, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(226, 24);
            this.layoutControlItem3.Text = "Tote Type:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(63, 13);
            // 
            // locationLabel
            // 
            this.locationLabel.Control = this.locationText;
            this.locationLabel.CustomizationFormText = "{0} Location:";
            this.locationLabel.Location = new System.Drawing.Point(720, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(211, 24);
            this.locationLabel.Text = "{0} Location:";
            this.locationLabel.TextSize = new System.Drawing.Size(63, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.labelText;
            this.layoutControlItem4.CustomizationFormText = "Tote Label:";
            this.layoutControlItem4.Location = new System.Drawing.Point(170, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(324, 24);
            this.layoutControlItem4.Text = "Tote Label:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(63, 13);
            // 
            // ToteManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 554);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ToteManagerForm";
            this.Text = "Tote Manager";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.labelText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toteTypeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toteContentsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl toteContentsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView contentsView;
        private DevExpress.XtraNavBar.NavBarItem transferToteLink;
        private DevExpress.XtraEditors.TextEdit toteTypeText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit locationText;
        private DevExpress.XtraLayout.LayoutControlItem locationLabel;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem removeItemsLink;
        private DevExpress.XtraNavBar.NavBarItem exportLink;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraNavBar.NavBarItem transferItemsLink;
        private DevExpress.XtraNavBar.NavBarItem printLabelItem;
        private DevExpress.XtraEditors.TextEdit labelText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraNavBar.NavBarItem refreshToteLink;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraNavBar.NavBarItem addItemsLink;
        private DevExpress.XtraNavBar.NavBarItem putAwayItemsLink;
    }
}