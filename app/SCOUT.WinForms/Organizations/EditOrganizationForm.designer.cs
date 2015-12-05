using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    partial class EditOrganizationForm
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.activeChk = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.notesTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.regionTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.phoneTxt = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.faxTxt = new System.Windows.Forms.MaskedTextBox();
            this.hLine2 = new SCOUT.WinForms.Controls.HLine();
            this.tabs = new System.Windows.Forms.TabControl();
            this.detTab = new System.Windows.Forms.TabPage();
            this.addrTab = new System.Windows.Forms.TabPage();
            this.addrLayoutArea = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.labelTxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.linesTxt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.countryList = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cityTxt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.stateTxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.zipTxt = new System.Windows.Forms.MaskedTextBox();
            this.streetOnlyChk = new System.Windows.Forms.CheckBox();
            this.hLine1 = new SCOUT.WinForms.Controls.HLine();
            this.delAddrBtn = new System.Windows.Forms.Button();
            this.newAddrBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.addrList = new System.Windows.Forms.ComboBox();
            this.contTab = new System.Windows.Forms.TabPage();
            this.contactLayoutArea = new System.Windows.Forms.TableLayoutPanel();
            this.contactAltPhoneTxt = new System.Windows.Forms.MaskedTextBox();
            this.contactEmailTxt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.contactTxt = new System.Windows.Forms.TextBox();
            this.contactFaxTxt = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contactPriPhoneTxt = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contactOtherTxt = new System.Windows.Forms.TextBox();
            this.hLine3 = new SCOUT.WinForms.Controls.HLine();
            this.label3 = new System.Windows.Forms.Label();
            this.delContBtn = new System.Windows.Forms.Button();
            this.newContBtn = new System.Windows.Forms.Button();
            this.contactsList = new System.Windows.Forms.ComboBox();
            this.custTab = new System.Windows.Forms.TabPage();
            this.defineFldsBtn = new System.Windows.Forms.Button();
            this.custFieldList = new System.Windows.Forms.DataGridView();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationDefaultsTab = new System.Windows.Forms.TabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.defaultReturnTypeLookup = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.detTab.SuspendLayout();
            this.addrTab.SuspendLayout();
            this.addrLayoutArea.SuspendLayout();
            this.contTab.SuspendLayout();
            this.contactLayoutArea.SuspendLayout();
            this.custTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custFieldList)).BeginInit();
            this.organizationDefaultsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultReturnTypeLookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(534, 12);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 100;
            this.okBtn.Text = "&OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(534, 41);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 101;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // activeChk
            // 
            this.activeChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.activeChk.Location = new System.Drawing.Point(534, 252);
            this.activeChk.Name = "activeChk";
            this.activeChk.Size = new System.Drawing.Size(75, 17);
            this.activeChk.TabIndex = 90;
            this.activeChk.Text = "Active";
            this.activeChk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameTxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.notesTxt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.regionTxt, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.phoneTxt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.faxTxt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.hLine2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 218);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTxt
            // 
            this.nameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.nameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTxt.Location = new System.Drawing.Point(93, 3);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(152, 20);
            this.nameTxt.TabIndex = 1;
            this.nameTxt.Text = "The Quick Red Fox";
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(3, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Notes:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // notesTxt
            // 
            this.notesTxt.AcceptsReturn = true;
            this.notesTxt.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.notesTxt, 3);
            this.notesTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesTxt.Location = new System.Drawing.Point(93, 57);
            this.notesTxt.Multiline = true;
            this.notesTxt.Name = "notesTxt";
            this.notesTxt.Size = new System.Drawing.Size(400, 158);
            this.notesTxt.TabIndex = 10;
            this.notesTxt.Text = "WARNING:\r\nNotes would go here!\r\n\r\nHad this actually been pulled from the database" +
                ", this is where the notes would go!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(251, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 23);
            this.label10.TabIndex = 2;
            this.label10.Text = "Region:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // regionTxt
            // 
            this.regionTxt.BackColor = System.Drawing.SystemColors.Window;
            this.regionTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regionTxt.Location = new System.Drawing.Point(341, 3);
            this.regionTxt.Name = "regionTxt";
            this.regionTxt.Size = new System.Drawing.Size(152, 20);
            this.regionTxt.TabIndex = 3;
            this.regionTxt.Text = "SOUTH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phoneTxt
            // 
            this.phoneTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phoneTxt.Location = new System.Drawing.Point(93, 26);
            this.phoneTxt.Mask = "(999) 000-0000";
            this.phoneTxt.Name = "phoneTxt";
            this.phoneTxt.Size = new System.Drawing.Size(152, 20);
            this.phoneTxt.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(251, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fax:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // faxTxt
            // 
            this.faxTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faxTxt.Location = new System.Drawing.Point(341, 26);
            this.faxTxt.Mask = "(999) 000-0000";
            this.faxTxt.Name = "faxTxt";
            this.faxTxt.Size = new System.Drawing.Size(152, 20);
            this.faxTxt.TabIndex = 7;
            // 
            // hLine2
            // 
            this.hLine2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.hLine2, 4);
            this.hLine2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hLine2.LineDrawStyle = SCOUT.WinForms.Controls.LineDrawStyle.System;
            this.hLine2.Location = new System.Drawing.Point(0, 46);
            this.hLine2.Margin = new System.Windows.Forms.Padding(0);
            this.hLine2.Name = "hLine2";
            this.hLine2.Size = new System.Drawing.Size(496, 8);
            this.hLine2.TabIndex = 8;
            this.hLine2.TabStop = false;
            this.hLine2.Text = "hLine2";
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.detTab);
            this.tabs.Controls.Add(this.addrTab);
            this.tabs.Controls.Add(this.contTab);
            this.tabs.Controls.Add(this.custTab);
            this.tabs.Controls.Add(this.organizationDefaultsTab);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(516, 257);
            this.tabs.TabIndex = 0;
            // 
            // detTab
            // 
            this.detTab.Controls.Add(this.tableLayoutPanel1);
            this.detTab.Location = new System.Drawing.Point(4, 22);
            this.detTab.Name = "detTab";
            this.detTab.Padding = new System.Windows.Forms.Padding(3);
            this.detTab.Size = new System.Drawing.Size(508, 231);
            this.detTab.TabIndex = 0;
            this.detTab.Text = "Details";
            this.detTab.UseVisualStyleBackColor = true;
            // 
            // addrTab
            // 
            this.addrTab.Controls.Add(this.addrLayoutArea);
            this.addrTab.Controls.Add(this.hLine1);
            this.addrTab.Controls.Add(this.delAddrBtn);
            this.addrTab.Controls.Add(this.newAddrBtn);
            this.addrTab.Controls.Add(this.label5);
            this.addrTab.Controls.Add(this.addrList);
            this.addrTab.Location = new System.Drawing.Point(4, 22);
            this.addrTab.Name = "addrTab";
            this.addrTab.Padding = new System.Windows.Forms.Padding(3);
            this.addrTab.Size = new System.Drawing.Size(508, 231);
            this.addrTab.TabIndex = 1;
            this.addrTab.Text = "Addresses";
            this.addrTab.UseVisualStyleBackColor = true;
            // 
            // addrLayoutArea
            // 
            this.addrLayoutArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addrLayoutArea.ColumnCount = 6;
            this.addrLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.addrLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.addrLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.addrLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.addrLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.addrLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.addrLayoutArea.Controls.Add(this.label11, 0, 0);
            this.addrLayoutArea.Controls.Add(this.labelTxt, 1, 0);
            this.addrLayoutArea.Controls.Add(this.label13, 0, 1);
            this.addrLayoutArea.Controls.Add(this.linesTxt, 1, 1);
            this.addrLayoutArea.Controls.Add(this.label17, 0, 6);
            this.addrLayoutArea.Controls.Add(this.countryList, 1, 6);
            this.addrLayoutArea.Controls.Add(this.label14, 0, 5);
            this.addrLayoutArea.Controls.Add(this.cityTxt, 1, 5);
            this.addrLayoutArea.Controls.Add(this.label15, 2, 5);
            this.addrLayoutArea.Controls.Add(this.stateTxt, 3, 5);
            this.addrLayoutArea.Controls.Add(this.label16, 4, 5);
            this.addrLayoutArea.Controls.Add(this.zipTxt, 5, 5);
            this.addrLayoutArea.Controls.Add(this.streetOnlyChk, 1, 4);
            this.addrLayoutArea.Location = new System.Drawing.Point(9, 49);
            this.addrLayoutArea.Name = "addrLayoutArea";
            this.addrLayoutArea.RowCount = 7;
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.addrLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.addrLayoutArea.Size = new System.Drawing.Size(493, 176);
            this.addrLayoutArea.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "Label:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTxt
            // 
            this.labelTxt.AcceptsReturn = true;
            this.labelTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "Billing",
            "Main",
            "Shipping"});
            this.labelTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.labelTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.addrLayoutArea.SetColumnSpan(this.labelTxt, 5);
            this.labelTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTxt.Location = new System.Drawing.Point(69, 3);
            this.labelTxt.Name = "labelTxt";
            this.labelTxt.Size = new System.Drawing.Size(421, 20);
            this.labelTxt.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 24);
            this.label13.TabIndex = 2;
            this.label13.Text = "Address:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linesTxt
            // 
            this.linesTxt.AcceptsReturn = true;
            this.addrLayoutArea.SetColumnSpan(this.linesTxt, 5);
            this.linesTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linesTxt.Location = new System.Drawing.Point(69, 27);
            this.linesTxt.Multiline = true;
            this.linesTxt.Name = "linesTxt";
            this.addrLayoutArea.SetRowSpan(this.linesTxt, 3);
            this.linesTxt.Size = new System.Drawing.Size(421, 66);
            this.linesTxt.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 30);
            this.label17.TabIndex = 11;
            this.label17.Text = "Country:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // countryList
            // 
            this.addrLayoutArea.SetColumnSpan(this.countryList, 5);
            this.countryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.countryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryList.FormattingEnabled = true;
            this.countryList.Location = new System.Drawing.Point(69, 149);
            this.countryList.MaxDropDownItems = 10;
            this.countryList.Name = "countryList";
            this.countryList.Size = new System.Drawing.Size(421, 21);
            this.countryList.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 26);
            this.label14.TabIndex = 5;
            this.label14.Text = "City:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cityTxt
            // 
            this.cityTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cityTxt.Location = new System.Drawing.Point(69, 123);
            this.cityTxt.Name = "cityTxt";
            this.cityTxt.Size = new System.Drawing.Size(166, 20);
            this.cityTxt.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(241, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 26);
            this.label15.TabIndex = 7;
            this.label15.Text = "State:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stateTxt
            // 
            this.stateTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stateTxt.Location = new System.Drawing.Point(287, 123);
            this.stateTxt.Name = "stateTxt";
            this.stateTxt.Size = new System.Drawing.Size(97, 20);
            this.stateTxt.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(390, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 26);
            this.label16.TabIndex = 9;
            this.label16.Text = "Zip:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zipTxt
            // 
            this.zipTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zipTxt.Location = new System.Drawing.Point(426, 123);
            this.zipTxt.Mask = "00000-9999";
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.Size = new System.Drawing.Size(64, 20);
            this.zipTxt.TabIndex = 10;
            this.zipTxt.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // streetOnlyChk
            // 
            this.streetOnlyChk.AutoSize = true;
            this.addrLayoutArea.SetColumnSpan(this.streetOnlyChk, 5);
            this.streetOnlyChk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.streetOnlyChk.Location = new System.Drawing.Point(69, 99);
            this.streetOnlyChk.Name = "streetOnlyChk";
            this.streetOnlyChk.Size = new System.Drawing.Size(421, 18);
            this.streetOnlyChk.TabIndex = 4;
            this.streetOnlyChk.Text = "Do not automaticaly append the following:";
            this.streetOnlyChk.UseVisualStyleBackColor = true;
            // 
            // hLine1
            // 
            this.hLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hLine1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hLine1.LineDrawStyle = SCOUT.WinForms.Controls.LineDrawStyle.System;
            this.hLine1.Location = new System.Drawing.Point(3, 33);
            this.hLine1.Name = "hLine1";
            this.hLine1.Size = new System.Drawing.Size(502, 10);
            this.hLine1.TabIndex = 4;
            this.hLine1.TabStop = false;
            this.hLine1.Text = "hLine1";
            // 
            // delAddrBtn
            // 
            this.delAddrBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delAddrBtn.Location = new System.Drawing.Point(446, 6);
            this.delAddrBtn.Name = "delAddrBtn";
            this.delAddrBtn.Size = new System.Drawing.Size(56, 23);
            this.delAddrBtn.TabIndex = 3;
            this.delAddrBtn.Text = "Delete";
            this.delAddrBtn.UseVisualStyleBackColor = true;
            this.delAddrBtn.Click += new System.EventHandler(this.delAddrBtn_Click);
            // 
            // newAddrBtn
            // 
            this.newAddrBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newAddrBtn.Location = new System.Drawing.Point(384, 6);
            this.newAddrBtn.Name = "newAddrBtn";
            this.newAddrBtn.Size = new System.Drawing.Size(56, 23);
            this.newAddrBtn.TabIndex = 2;
            this.newAddrBtn.Text = "New";
            this.newAddrBtn.UseVisualStyleBackColor = true;
            this.newAddrBtn.Click += new System.EventHandler(this.newAddrBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Address:";
            // 
            // addrList
            // 
            this.addrList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.addrList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addrList.FormattingEnabled = true;
            this.addrList.Location = new System.Drawing.Point(60, 6);
            this.addrList.Name = "addrList";
            this.addrList.Size = new System.Drawing.Size(318, 21);
            this.addrList.TabIndex = 1;
            // 
            // contTab
            // 
            this.contTab.Controls.Add(this.contactLayoutArea);
            this.contTab.Controls.Add(this.hLine3);
            this.contTab.Controls.Add(this.label3);
            this.contTab.Controls.Add(this.delContBtn);
            this.contTab.Controls.Add(this.newContBtn);
            this.contTab.Controls.Add(this.contactsList);
            this.contTab.Location = new System.Drawing.Point(4, 22);
            this.contTab.Name = "contTab";
            this.contTab.Padding = new System.Windows.Forms.Padding(3);
            this.contTab.Size = new System.Drawing.Size(508, 231);
            this.contTab.TabIndex = 3;
            this.contTab.Text = "Contacts";
            this.contTab.UseVisualStyleBackColor = true;
            // 
            // contactLayoutArea
            // 
            this.contactLayoutArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contactLayoutArea.ColumnCount = 4;
            this.contactLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.contactLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contactLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.contactLayoutArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contactLayoutArea.Controls.Add(this.contactAltPhoneTxt, 3, 2);
            this.contactLayoutArea.Controls.Add(this.contactEmailTxt, 1, 1);
            this.contactLayoutArea.Controls.Add(this.label18, 2, 2);
            this.contactLayoutArea.Controls.Add(this.label8, 0, 1);
            this.contactLayoutArea.Controls.Add(this.contactTxt, 1, 0);
            this.contactLayoutArea.Controls.Add(this.contactFaxTxt, 1, 3);
            this.contactLayoutArea.Controls.Add(this.label19, 0, 3);
            this.contactLayoutArea.Controls.Add(this.label9, 0, 2);
            this.contactLayoutArea.Controls.Add(this.label2, 0, 0);
            this.contactLayoutArea.Controls.Add(this.contactPriPhoneTxt, 1, 2);
            this.contactLayoutArea.Controls.Add(this.label6, 2, 3);
            this.contactLayoutArea.Controls.Add(this.contactOtherTxt, 3, 3);
            this.contactLayoutArea.Location = new System.Drawing.Point(9, 49);
            this.contactLayoutArea.Name = "contactLayoutArea";
            this.contactLayoutArea.RowCount = 6;
            this.contactLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.contactLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.contactLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.contactLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.contactLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.contactLayoutArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.contactLayoutArea.Size = new System.Drawing.Size(493, 176);
            this.contactLayoutArea.TabIndex = 25;
            // 
            // contactAltPhoneTxt
            // 
            this.contactAltPhoneTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactAltPhoneTxt.Location = new System.Drawing.Point(315, 53);
            this.contactAltPhoneTxt.Mask = "(999) 000-0000";
            this.contactAltPhoneTxt.Name = "contactAltPhoneTxt";
            this.contactAltPhoneTxt.Size = new System.Drawing.Size(175, 20);
            this.contactAltPhoneTxt.TabIndex = 7;
            // 
            // contactEmailTxt
            // 
            this.contactLayoutArea.SetColumnSpan(this.contactEmailTxt, 3);
            this.contactEmailTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactEmailTxt.Location = new System.Drawing.Point(69, 28);
            this.contactEmailTxt.Name = "contactEmailTxt";
            this.contactEmailTxt.Size = new System.Drawing.Size(421, 20);
            this.contactEmailTxt.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(249, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 25);
            this.label18.TabIndex = 6;
            this.label18.Text = "Alt. Phone:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(3, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Email:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contactTxt
            // 
            this.contactLayoutArea.SetColumnSpan(this.contactTxt, 3);
            this.contactTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactTxt.Location = new System.Drawing.Point(69, 3);
            this.contactTxt.Name = "contactTxt";
            this.contactTxt.Size = new System.Drawing.Size(421, 20);
            this.contactTxt.TabIndex = 1;
            // 
            // contactFaxTxt
            // 
            this.contactFaxTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactFaxTxt.Location = new System.Drawing.Point(69, 78);
            this.contactFaxTxt.Mask = "(999) 000-0000";
            this.contactFaxTxt.Name = "contactFaxTxt";
            this.contactFaxTxt.Size = new System.Drawing.Size(174, 20);
            this.contactFaxTxt.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Location = new System.Drawing.Point(3, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 25);
            this.label19.TabIndex = 8;
            this.label19.Text = "Fax:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "Phone:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contactPriPhoneTxt
            // 
            this.contactPriPhoneTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactPriPhoneTxt.Location = new System.Drawing.Point(69, 53);
            this.contactPriPhoneTxt.Mask = "(999) 000-0000";
            this.contactPriPhoneTxt.Name = "contactPriPhoneTxt";
            this.contactPriPhoneTxt.Size = new System.Drawing.Size(174, 20);
            this.contactPriPhoneTxt.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(249, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Other:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contactOtherTxt
            // 
            this.contactOtherTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactOtherTxt.Location = new System.Drawing.Point(315, 78);
            this.contactOtherTxt.Name = "contactOtherTxt";
            this.contactOtherTxt.Size = new System.Drawing.Size(175, 20);
            this.contactOtherTxt.TabIndex = 11;
            // 
            // hLine3
            // 
            this.hLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hLine3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.hLine3.LineDrawStyle = SCOUT.WinForms.Controls.LineDrawStyle.System;
            this.hLine3.Location = new System.Drawing.Point(6, 33);
            this.hLine3.Name = "hLine3";
            this.hLine3.Size = new System.Drawing.Size(496, 10);
            this.hLine3.TabIndex = 4;
            this.hLine3.TabStop = false;
            this.hLine3.Text = "hLine3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contact:";
            // 
            // delContBtn
            // 
            this.delContBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delContBtn.Location = new System.Drawing.Point(446, 6);
            this.delContBtn.Name = "delContBtn";
            this.delContBtn.Size = new System.Drawing.Size(56, 23);
            this.delContBtn.TabIndex = 3;
            this.delContBtn.Text = "Delete";
            this.delContBtn.UseVisualStyleBackColor = true;
            this.delContBtn.Click += new System.EventHandler(this.delContBtn_Click);
            // 
            // newContBtn
            // 
            this.newContBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newContBtn.Location = new System.Drawing.Point(384, 6);
            this.newContBtn.Name = "newContBtn";
            this.newContBtn.Size = new System.Drawing.Size(56, 23);
            this.newContBtn.TabIndex = 2;
            this.newContBtn.Text = "New";
            this.newContBtn.UseVisualStyleBackColor = true;
            this.newContBtn.Click += new System.EventHandler(this.newContBtn_Click);
            // 
            // contactsList
            // 
            this.contactsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contactsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contactsList.FormattingEnabled = true;
            this.contactsList.Location = new System.Drawing.Point(59, 6);
            this.contactsList.Name = "contactsList";
            this.contactsList.Size = new System.Drawing.Size(319, 21);
            this.contactsList.TabIndex = 1;
            // 
            // custTab
            // 
            this.custTab.Controls.Add(this.defineFldsBtn);
            this.custTab.Controls.Add(this.custFieldList);
            this.custTab.Location = new System.Drawing.Point(4, 22);
            this.custTab.Name = "custTab";
            this.custTab.Padding = new System.Windows.Forms.Padding(3);
            this.custTab.Size = new System.Drawing.Size(508, 231);
            this.custTab.TabIndex = 2;
            this.custTab.Text = "Custom Fields";
            this.custTab.UseVisualStyleBackColor = true;
            // 
            // defineFldsBtn
            // 
            this.defineFldsBtn.Location = new System.Drawing.Point(414, 202);
            this.defineFldsBtn.Name = "defineFldsBtn";
            this.defineFldsBtn.Size = new System.Drawing.Size(88, 23);
            this.defineFldsBtn.TabIndex = 1;
            this.defineFldsBtn.Text = "&Define Fields...";
            this.defineFldsBtn.UseVisualStyleBackColor = true;
            this.defineFldsBtn.Click += new System.EventHandler(this.defineFldsBtn_Click);
            // 
            // custFieldList
            // 
            this.custFieldList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.custFieldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.custFieldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.ValueCol});
            this.custFieldList.Location = new System.Drawing.Point(6, 7);
            this.custFieldList.Name = "custFieldList";
            this.custFieldList.Size = new System.Drawing.Size(496, 189);
            this.custFieldList.TabIndex = 0;
            // 
            // NameCol
            // 
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // ValueCol
            // 
            this.ValueCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueCol.DataPropertyName = "Value";
            this.ValueCol.HeaderText = "Value";
            this.ValueCol.Name = "ValueCol";
            // 
            // organizationDefaultsTab
            // 
            this.organizationDefaultsTab.Controls.Add(this.layoutControl1);
            this.organizationDefaultsTab.Location = new System.Drawing.Point(4, 22);
            this.organizationDefaultsTab.Name = "organizationDefaultsTab";
            this.organizationDefaultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.organizationDefaultsTab.Size = new System.Drawing.Size(508, 231);
            this.organizationDefaultsTab.TabIndex = 4;
            this.organizationDefaultsTab.Text = "Defaults";
            this.organizationDefaultsTab.UseVisualStyleBackColor = true;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 3);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(502, 225);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(502, 225);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(494, 217);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Warehouse";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(498, 221);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.defaultReturnTypeLookup);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 22);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(490, 193);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(490, 193);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // defaultReturnTypeLookup
            // 
            this.defaultReturnTypeLookup.Location = new System.Drawing.Point(80, 12);
            this.defaultReturnTypeLookup.Name = "defaultReturnTypeLookup";
            this.defaultReturnTypeLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.defaultReturnTypeLookup.Properties.NullText = "[Select default return type]";
            this.defaultReturnTypeLookup.Size = new System.Drawing.Size(398, 20);
            this.defaultReturnTypeLookup.StyleController = this.layoutControl2;
            this.defaultReturnTypeLookup.TabIndex = 4;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.defaultReturnTypeLookup;
            this.layoutControlItem2.CustomizationFormText = "Return Type:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(470, 173);
            this.layoutControlItem2.Text = "Return Type:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 13);
            // 
            // EditOrganizationForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(621, 284);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.activeChk);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOrganizationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editing Organization: The Quick Red Fox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.detTab.ResumeLayout(false);
            this.addrTab.ResumeLayout(false);
            this.addrTab.PerformLayout();
            this.addrLayoutArea.ResumeLayout(false);
            this.addrLayoutArea.PerformLayout();
            this.contTab.ResumeLayout(false);
            this.contTab.PerformLayout();
            this.contactLayoutArea.ResumeLayout(false);
            this.contactLayoutArea.PerformLayout();
            this.custTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.custFieldList)).EndInit();
            this.organizationDefaultsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultReturnTypeLookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.CheckBox activeChk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HLine hLine2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox regionTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox notesTxt;
        private System.Windows.Forms.MaskedTextBox phoneTxt;
        private System.Windows.Forms.MaskedTextBox faxTxt;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage detTab;
        private System.Windows.Forms.TabPage addrTab;
        private System.Windows.Forms.Button delAddrBtn;
        private System.Windows.Forms.Button newAddrBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox addrList;
        private System.Windows.Forms.TableLayoutPanel addrLayoutArea;
        private HLine hLine1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox labelTxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox linesTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox cityTxt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox stateTxt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox zipTxt;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox countryList;
        private System.Windows.Forms.TabPage custTab;
        private System.Windows.Forms.DataGridView custFieldList;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
        private System.Windows.Forms.Button defineFldsBtn;
        private System.Windows.Forms.TabPage contTab;
        private System.Windows.Forms.Button delContBtn;
        private System.Windows.Forms.Button newContBtn;
        private System.Windows.Forms.ComboBox contactsList;
        private HLine hLine3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox contactEmailTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox contactTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.MaskedTextBox contactPriPhoneTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox contactFaxTxt;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox contactAltPhoneTxt;
        private System.Windows.Forms.TableLayoutPanel contactLayoutArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox contactOtherTxt;
        private System.Windows.Forms.CheckBox streetOnlyChk;
        private System.Windows.Forms.TabPage organizationDefaultsTab;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.LookUpEdit defaultReturnTypeLookup;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}