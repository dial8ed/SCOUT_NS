namespace SCOUT.WinForms
{
    partial class mainOrderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainOrderForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.otherText = new DevExpress.XtraEditors.TextEdit();
            this.poText = new DevExpress.XtraEditors.TextEdit();
            this.rmaText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.rmaLayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.otherLayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.poLayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.contractsControlGroup = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.saveButton = new DevExpress.XtraBars.BarButtonItem();
            this.saveAndNewButton = new DevExpress.XtraBars.BarButtonItem();
            this.closeButton = new DevExpress.XtraBars.BarButtonItem();
            this.copyDetailsButton = new DevExpress.XtraBars.BarButtonItem();
            this.copyTopLevelRollup = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmaText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmaLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractsControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.otherText);
            this.layoutControl1.Controls.Add(this.poText);
            this.layoutControl1.Controls.Add(this.rmaText);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsFocus.AllowFocusControlOnActivatedTabPage = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(784, 536);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // otherText
            // 
            this.otherText.EnterMoveNextControl = true;
            this.otherText.Location = new System.Drawing.Point(568, 12);
            this.otherText.Name = "otherText";
            this.otherText.Size = new System.Drawing.Size(204, 20);
            this.otherText.StyleController = this.layoutControl1;
            this.otherText.TabIndex = 3;
            // 
            // poText
            // 
            this.poText.EnterMoveNextControl = true;
            this.poText.Location = new System.Drawing.Point(290, 12);
            this.poText.Name = "poText";
            this.poText.Size = new System.Drawing.Size(238, 20);
            this.poText.StyleController = this.layoutControl1;
            this.poText.TabIndex = 2;
            // 
            // rmaText
            // 
            this.rmaText.EnterMoveNextControl = true;
            this.rmaText.Location = new System.Drawing.Point(48, 12);
            this.rmaText.Name = "rmaText";
            this.rmaText.Size = new System.Drawing.Size(202, 20);
            this.rmaText.StyleController = this.layoutControl1;
            this.rmaText.TabIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.rmaLayout,
            this.otherLayout,
            this.poLayout,
            this.contractsControlGroup});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 536);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // rmaLayout
            // 
            this.rmaLayout.Control = this.rmaText;
            this.rmaLayout.CustomizationFormText = "RMA:";
            this.rmaLayout.Location = new System.Drawing.Point(0, 0);
            this.rmaLayout.Name = "rmaLayout";
            this.rmaLayout.Size = new System.Drawing.Size(242, 24);
            this.rmaLayout.Text = "RMA:";
            this.rmaLayout.TextSize = new System.Drawing.Size(32, 13);
            // 
            // otherLayout
            // 
            this.otherLayout.Control = this.otherText;
            this.otherLayout.CustomizationFormText = "Other:";
            this.otherLayout.Location = new System.Drawing.Point(520, 0);
            this.otherLayout.Name = "otherLayout";
            this.otherLayout.Size = new System.Drawing.Size(244, 24);
            this.otherLayout.Text = "Other:";
            this.otherLayout.TextSize = new System.Drawing.Size(32, 13);
            // 
            // poLayout
            // 
            this.poLayout.Control = this.poText;
            this.poLayout.CustomizationFormText = "PO:";
            this.poLayout.Location = new System.Drawing.Point(242, 0);
            this.poLayout.Name = "poLayout";
            this.poLayout.Size = new System.Drawing.Size(278, 24);
            this.poLayout.Text = "PO:";
            this.poLayout.TextSize = new System.Drawing.Size(32, 13);
            // 
            // contractsControlGroup
            // 
            this.contractsControlGroup.CustomizationFormText = "Contracts";
            this.contractsControlGroup.Location = new System.Drawing.Point(0, 24);
            this.contractsControlGroup.Name = "contractsControlGroup";
            this.contractsControlGroup.SelectedTabPage = this.layoutControlGroup2;
            this.contractsControlGroup.SelectedTabPageIndex = 0;
            this.contractsControlGroup.Size = new System.Drawing.Size(764, 492);
            this.contractsControlGroup.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.contractsControlGroup.Text = "Contracts";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Contracts";
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(740, 446);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "Contracts";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.saveButton,
            this.closeButton,
            this.copyDetailsButton,
            this.saveAndNewButton,
            this.barToolbarsListItem1,
            this.copyTopLevelRollup});
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.saveButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.saveAndNewButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.closeButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.copyDetailsButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.copyTopLevelRollup)});
            this.bar1.Text = "Tools";
            // 
            // saveButton
            // 
            this.saveButton.Caption = "Save";
            this.saveButton.Glyph = global::SCOUT.WinForms.Properties.Resources.disk;
            this.saveButton.Id = 0;
            this.saveButton.Name = "saveButton";
            this.saveButton.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.saveButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveButton_ItemClick);
            // 
            // saveAndNewButton
            // 
            this.saveAndNewButton.Caption = "Save and New";
            this.saveAndNewButton.Glyph = global::SCOUT.WinForms.Properties.Resources.disk_multiple;
            this.saveAndNewButton.Id = 4;
            this.saveAndNewButton.Name = "saveAndNewButton";
            this.saveAndNewButton.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.saveAndNewButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveAndNewButton_ItemClick);
            // 
            // closeButton
            // 
            this.closeButton.Caption = "Close";
            this.closeButton.Glyph = global::SCOUT.WinForms.Properties.Resources.cancel;
            this.closeButton.Id = 2;
            this.closeButton.Name = "closeButton";
            this.closeButton.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.closeButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.closeButton_ItemClick);
            // 
            // copyDetailsButton
            // 
            this.copyDetailsButton.Caption = "Copy order details (Line by line)";
            this.copyDetailsButton.Glyph = global::SCOUT.WinForms.Properties.Resources.page_copy;
            this.copyDetailsButton.Id = 3;
            this.copyDetailsButton.Name = "copyDetailsButton";
            this.copyDetailsButton.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.copyDetailsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.copyItemsButton_ItemClick);
            // 
            // copyTopLevelRollup
            // 
            this.copyTopLevelRollup.Caption = "Copy order details (Top-level Rollup)";
            this.copyTopLevelRollup.Glyph = global::SCOUT.WinForms.Properties.Resources.page_copy;
            this.copyTopLevelRollup.Id = 7;
            this.copyTopLevelRollup.Name = "copyTopLevelRollup";
            this.copyTopLevelRollup.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.copyTopLevelRollup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.copyTopLevelRollup_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(784, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 536);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 536);
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.Caption = "Copy order details";
            this.barToolbarsListItem1.Glyph = global::SCOUT.WinForms.Properties.Resources.page_copy;
            this.barToolbarsListItem1.Id = 6;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            this.barToolbarsListItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // mainOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "mainOrderForm";
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.otherText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmaText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rmaLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contractsControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.TextEdit otherText;
        private DevExpress.XtraEditors.TextEdit poText;
        private DevExpress.XtraEditors.TextEdit rmaText;
        private DevExpress.XtraLayout.LayoutControlItem rmaLayout;
        private DevExpress.XtraLayout.LayoutControlItem poLayout;
        private DevExpress.XtraLayout.LayoutControlItem otherLayout;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraLayout.TabbedControlGroup contractsControlGroup;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem saveButton;
        private DevExpress.XtraBars.BarButtonItem closeButton;
        private DevExpress.XtraBars.BarButtonItem copyDetailsButton;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem saveAndNewButton;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarButtonItem copyTopLevelRollup;
    }
}