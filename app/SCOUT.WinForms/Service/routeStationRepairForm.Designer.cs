namespace SCOUT.WinForms.Service
{
    partial class RouteStationRepairForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.componentsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repairsGrid = new DevExpress.XtraGrid.GridControl();
            this.repairsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repairLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.replaceComponentsEditor = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resultCombo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.componentLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.createNoPartRecordLink = new DevExpress.XtraEditors.HyperLinkEdit();
            this.createNoRepairRecord = new DevExpress.XtraEditors.HyperLinkEdit();
            this.removeRepairLink = new DevExpress.XtraEditors.HyperLinkEdit();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.failureText = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replaceComponentsEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createNoPartRecordLink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createNoRepairRecord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeRepairLink.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.failureText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // componentsView
            // 
            this.componentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.componentsView.GridControl = this.repairsGrid;
            this.componentsView.Name = "componentsView";
            this.componentsView.OptionsBehavior.AutoExpandAllGroups = true;
            this.componentsView.OptionsBehavior.Editable = false;
            this.componentsView.OptionsView.ShowGroupedColumns = true;
            this.componentsView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Component";
            this.gridColumn9.FieldName = "Component!";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Part In";
            this.gridColumn10.FieldName = "PartIn.PartNumber";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Part Out";
            this.gridColumn11.FieldName = "PartOut.PartNumber";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Serial Number In";
            this.gridColumn12.FieldName = "SerialNumberIn";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Serial Number Out";
            this.gridColumn13.FieldName = "SerialNumberOut";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            // 
            // repairsGrid
            // 
            this.repairsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.componentsView;
            gridLevelNode1.RelationName = "Components";
            this.repairsGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.repairsGrid.Location = new System.Drawing.Point(2, 22);
            this.repairsGrid.MainView = this.repairsView;
            this.repairsGrid.Name = "repairsGrid";
            this.repairsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repairLookup,
            this.componentLookup,
            this.replaceComponentsEditor,
            this.resultCombo,
            this.repositoryItemMemoEdit1});
            this.repairsGrid.ShowOnlyPredefinedDetails = true;
            this.repairsGrid.Size = new System.Drawing.Size(800, 230);
            this.repairsGrid.TabIndex = 0;
            this.repairsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.repairsView,
            this.componentsView});
            // 
            // repairsView
            // 
            this.repairsView.Appearance.Preview.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.repairsView.Appearance.Preview.BorderColor = System.Drawing.Color.Gray;
            this.repairsView.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.repairsView.Appearance.Preview.Options.UseBorderColor = true;
            this.repairsView.Appearance.Preview.Options.UseForeColor = true;
            this.repairsView.ChildGridLevelName = "Components";
            this.repairsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn8});
            this.repairsView.DetailTabHeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.repairsView.GridControl = this.repairsGrid;
            this.repairsView.Name = "repairsView";
            this.repairsView.OptionsBehavior.AutoExpandAllGroups = true;
            this.repairsView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.repairsView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.repairsView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.repairsView.OptionsView.ShowDetailButtons = false;
            this.repairsView.OptionsView.ShowGroupPanel = false;
            this.repairsView.OptionsView.ShowPreview = true;
            this.repairsView.PreviewFieldName = "ComponentDetails";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Repair";
            this.gridColumn1.ColumnEdit = this.repairLookup;
            this.gridColumn1.FieldName = "Repair";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 137;
            // 
            // repairLookup
            // 
            this.repairLookup.AutoHeight = false;
            this.repairLookup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repairLookup.Name = "repairLookup";
            this.repairLookup.NullText = "[Select repair action]";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Component Tracking";
            this.gridColumn7.ColumnEdit = this.replaceComponentsEditor;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 111;
            // 
            // replaceComponentsEditor
            // 
            this.replaceComponentsEditor.AutoHeight = false;
            toolTipTitleItem1.Text = "Component Tracking";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Add replacement components\r\n";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.replaceComponentsEditor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, false)});
            this.replaceComponentsEditor.Name = "replaceComponentsEditor";
            this.replaceComponentsEditor.ReadOnly = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Comments";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn3.FieldName = "Comments";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 172;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Created By";
            this.gridColumn4.FieldName = "CreatedBy";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 74;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Create Date";
            this.gridColumn5.FieldName = "CreatedDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 76;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Computer";
            this.gridColumn6.FieldName = "MachineName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Result";
            this.gridColumn2.ColumnEdit = this.resultCombo;
            this.gridColumn2.FieldName = "Result";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 139;
            // 
            // resultCombo
            // 
            this.resultCombo.AutoHeight = false;
            this.resultCombo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resultCombo.Items.AddRange(new object[] {
            "",
            "PROBLEM SOLVED",
            "NOT SOLVED",
            "SCRAP"});
            this.resultCombo.Name = "resultCombo";
            this.resultCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "No Parts Required";
            this.gridColumn8.FieldName = "ArePartsRequired";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // componentLookup
            // 
            this.componentLookup.AutoHeight = false;
            this.componentLookup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.componentLookup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Component", "Component")});
            this.componentLookup.Name = "componentLookup";
            this.componentLookup.NullText = "[Select component]";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.createNoPartRecordLink);
            this.layoutControl1.Controls.Add(this.createNoRepairRecord);
            this.layoutControl1.Controls.Add(this.removeRepairLink);
            this.layoutControl1.Controls.Add(this.okButton);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.failureText);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(828, 356);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // createNoPartRecordLink
            // 
            this.createNoPartRecordLink.EditValue = "Create \"No Part\" Record";
            this.createNoPartRecordLink.Location = new System.Drawing.Point(493, 36);
            this.createNoPartRecordLink.Name = "createNoPartRecordLink";
            this.createNoPartRecordLink.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.createNoPartRecordLink.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.createNoPartRecordLink.Properties.Appearance.Options.UseBackColor = true;
            this.createNoPartRecordLink.Properties.Appearance.Options.UseForeColor = true;
            this.createNoPartRecordLink.Properties.Image = global::SCOUT.WinForms.Properties.Resources.script_gear;
            this.createNoPartRecordLink.Properties.StartKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3));
            this.createNoPartRecordLink.Size = new System.Drawing.Size(323, 24);
            this.createNoPartRecordLink.StyleController = this.layoutControl1;
            this.createNoPartRecordLink.TabIndex = 9;
            this.createNoPartRecordLink.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.createNoPartRecordLink_OpenLink);
            // 
            // createNoRepairRecord
            // 
            this.createNoRepairRecord.EditValue = "Create \"No Repair\" Record";
            this.createNoRepairRecord.Location = new System.Drawing.Point(165, 36);
            this.createNoRepairRecord.Name = "createNoRepairRecord";
            this.createNoRepairRecord.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.createNoRepairRecord.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.createNoRepairRecord.Properties.Appearance.Options.UseBackColor = true;
            this.createNoRepairRecord.Properties.Appearance.Options.UseForeColor = true;
            this.createNoRepairRecord.Properties.Image = global::SCOUT.WinForms.Properties.Resources.wrench_orange;
            this.createNoRepairRecord.Properties.StartKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F2));
            this.createNoRepairRecord.Size = new System.Drawing.Size(324, 24);
            this.createNoRepairRecord.StyleController = this.layoutControl1;
            this.createNoRepairRecord.TabIndex = 8;
            this.createNoRepairRecord.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.createNoRepairRecord_OpenLink);
            // 
            // removeRepairLink
            // 
            this.removeRepairLink.EditValue = "Remove";
            this.removeRepairLink.Location = new System.Drawing.Point(12, 36);
            this.removeRepairLink.Name = "removeRepairLink";
            this.removeRepairLink.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.removeRepairLink.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.removeRepairLink.Properties.Appearance.Options.UseBackColor = true;
            this.removeRepairLink.Properties.Appearance.Options.UseForeColor = true;
            this.removeRepairLink.Properties.Image = global::SCOUT.WinForms.Properties.Resources.delete;
            this.removeRepairLink.Properties.StartKey = new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1));
            this.removeRepairLink.Size = new System.Drawing.Size(149, 24);
            this.removeRepairLink.StyleController = this.layoutControl1;
            this.removeRepairLink.TabIndex = 7;
            this.removeRepairLink.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.removeRepairLink_OpenLink);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(668, 322);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(148, 22);
            this.okButton.StyleController = this.layoutControl1;
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.repairsGrid);
            this.groupControl1.Location = new System.Drawing.Point(12, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(804, 254);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Repairs";
            // 
            // failureText
            // 
            this.failureText.Location = new System.Drawing.Point(48, 12);
            this.failureText.Name = "failureText";
            this.failureText.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.failureText.Properties.Appearance.Options.UseBackColor = true;
            this.failureText.Properties.ReadOnly = true;
            this.failureText.Size = new System.Drawing.Size(768, 20);
            this.failureText.StyleController = this.layoutControl1;
            this.failureText.TabIndex = 4;
            this.failureText.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(828, 356);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.failureText;
            this.layoutControlItem1.CustomizationFormText = "Failure";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(808, 24);
            this.layoutControlItem1.Text = "Failure";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(32, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupControl1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(808, 258);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.okButton;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(656, 310);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(152, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 310);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(656, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.removeRepairLink;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(153, 28);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.createNoRepairRecord;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(153, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(328, 28);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.createNoPartRecordLink;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(481, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(327, 28);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // RouteStationRepairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 356);
            this.Controls.Add(this.layoutControl1);
            this.Name = "RouteStationRepairForm";
            this.Text = "Station repairs";
            ((System.ComponentModel.ISupportInitialize)(this.componentsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replaceComponentsEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.componentLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.createNoPartRecordLink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createNoRepairRecord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeRepairLink.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.failureText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl repairsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView repairsView;
        private DevExpress.XtraEditors.TextEdit failureText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repairLookup;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit componentLookup;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit replaceComponentsEditor;
        private DevExpress.XtraEditors.HyperLinkEdit removeRepairLink;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox resultCombo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.HyperLinkEdit createNoRepairRecord;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.HyperLinkEdit createNoPartRecordLink;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.Views.Grid.GridView componentsView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}