namespace SCOUT.WinForms
{
    partial class SearchControl2
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
            this.splitArea = new DevExpress.XtraEditors.SplitContainerControl();
            this.paramLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.gridPage = new DevExpress.XtraTab.XtraTabPage();
            this.resultGrid = new DevExpress.XtraGrid.GridControl();
            this.mainView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.searchDataNavigator = new DevExpress.XtraEditors.DataNavigator();
            this.pivotPage = new DevExpress.XtraTab.XtraTabPage();
            this.resultPivotGrid = new DevExpress.XtraPivotGrid.PivotGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitArea)).BeginInit();
            this.splitArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paramLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.gridPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            this.pivotPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultPivotGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitArea
            // 
            this.splitArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitArea.Location = new System.Drawing.Point(0, 0);
            this.splitArea.Name = "splitArea";
            this.splitArea.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.splitArea.Panel1.Controls.Add(this.paramLayout);
            this.splitArea.Panel1.Text = "Panel1";
            this.splitArea.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitArea.Panel2.Text = "Panel2";
            this.splitArea.Size = new System.Drawing.Size(559, 252);
            this.splitArea.SplitterPosition = 201;
            this.splitArea.TabIndex = 0;
            this.splitArea.Text = "splitContainerControl1";
            // 
            // paramLayout
            // 
            this.paramLayout.AllowCustomizationMenu = false;
            this.paramLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paramLayout.Location = new System.Drawing.Point(0, 0);
            this.paramLayout.Name = "paramLayout";
            this.paramLayout.Root = this.layoutControlGroup1;
            this.paramLayout.Size = new System.Drawing.Size(201, 252);
            this.paramLayout.TabIndex = 0;
            this.paramLayout.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(201, 252);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.gridPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(348, 248);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.gridPage,
            this.pivotPage});
            // 
            // gridPage
            // 
            this.gridPage.Controls.Add(this.resultGrid);
            this.gridPage.Controls.Add(this.searchDataNavigator);
            this.gridPage.Name = "gridPage";
            this.gridPage.Size = new System.Drawing.Size(339, 217);
            this.gridPage.Text = "Grid";
            // 
            // resultGrid
            // 
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid.EmbeddedNavigator.Name = "";
            this.resultGrid.Location = new System.Drawing.Point(0, 0);
            this.resultGrid.MainView = this.mainView;
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(339, 198);
            this.resultGrid.TabIndex = 24;
            this.resultGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainView});
            this.resultGrid.DoubleClick += new System.EventHandler(this.resultGrid_DoubleClick);
            // 
            // mainView
            // 
            this.mainView.GridControl = this.resultGrid;
            this.mainView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.mainView.Name = "mainView";
            this.mainView.OptionsBehavior.AutoExpandAllGroups = true;
            this.mainView.OptionsBehavior.Editable = false;
            this.mainView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.mainView.OptionsView.ColumnAutoWidth = false;
            this.mainView.OptionsView.ShowFooter = true;
            // 
            // searchDataNavigator
            // 
            this.searchDataNavigator.Buttons.Append.Visible = false;
            this.searchDataNavigator.Buttons.CancelEdit.Visible = false;
            this.searchDataNavigator.Buttons.EndEdit.Visible = false;
            this.searchDataNavigator.Buttons.Remove.Visible = false;
            this.searchDataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchDataNavigator.Location = new System.Drawing.Point(0, 198);
            this.searchDataNavigator.Name = "searchDataNavigator";
            this.searchDataNavigator.Size = new System.Drawing.Size(339, 19);
            this.searchDataNavigator.TabIndex = 25;
            this.searchDataNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            // 
            // pivotPage
            // 
            this.pivotPage.Controls.Add(this.resultPivotGrid);
            this.pivotPage.Name = "pivotPage";
            this.pivotPage.PageVisible = false;
            this.pivotPage.Size = new System.Drawing.Size(339, 217);
            this.pivotPage.Text = "Pivot";
            // 
            // resultPivotGrid
            // 
            this.resultPivotGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.resultPivotGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPivotGrid.Location = new System.Drawing.Point(0, 0);
            this.resultPivotGrid.Name = "resultPivotGrid";
            this.resultPivotGrid.Size = new System.Drawing.Size(339, 217);
            this.resultPivotGrid.TabIndex = 0;
            // 
            // SearchControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitArea);
            this.Name = "SearchControl2";
            this.Size = new System.Drawing.Size(559, 252);
            ((System.ComponentModel.ISupportInitialize)(this.splitArea)).EndInit();
            this.splitArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paramLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.gridPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            this.pivotPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultPivotGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitArea;
        private DevExpress.XtraLayout.LayoutControl paramLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage gridPage;
        private DevExpress.XtraGrid.GridControl resultGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView mainView;
        private DevExpress.XtraEditors.DataNavigator searchDataNavigator;
        private DevExpress.XtraTab.XtraTabPage pivotPage;
        private DevExpress.XtraPivotGrid.PivotGridControl resultPivotGrid;
    }
}
