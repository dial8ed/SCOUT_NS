using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    partial class UserManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagerForm));
            this.usersBinding = new System.Windows.Forms.BindingSource(this.components);
            this.rolesBinding = new System.Windows.Forms.BindingSource(this.components);
            this.navArea = new System.Windows.Forms.Panel();
            this.roleListPanel = new System.Windows.Forms.Panel();
            this.roleList = new System.Windows.Forms.ListBox();
            this.roleBtn = new System.Windows.Forms.RadioButton();
            this.userListPanel = new System.Windows.Forms.Panel();
            this.userList = new System.Windows.Forms.ListBox();
            this.userBtn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okBtn = new System.Windows.Forms.Button();
            this.userPnl = new System.Windows.Forms.Panel();
            this.userRoleList = new System.Windows.Forms.ListBox();
            this.userTools = new System.Windows.Forms.ToolStrip();
            this.userAddBtn = new System.Windows.Forms.ToolStripButton();
            this.userEditBtn = new System.Windows.Forms.ToolStripButton();
            this.userDelBtn = new System.Windows.Forms.ToolStripButton();
            this.HLine2 = new HLine();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.loginTxt = new System.Windows.Forms.TextBox();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.HLine1 = new HLine();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.rolePnl = new System.Windows.Forms.Panel();
            this.roleActionList = new System.Windows.Forms.ListBox();
            this.roleTools = new System.Windows.Forms.ToolStrip();
            this.roleAddBtn = new System.Windows.Forms.ToolStripButton();
            this.roleEditBtn = new System.Windows.Forms.ToolStripButton();
            this.roleDelBtn = new System.Windows.Forms.ToolStripButton();
            this.Label6 = new System.Windows.Forms.Label();
            this.HLine3 = new HLine();
            this.roleNameTxt = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usersBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBinding)).BeginInit();
            this.navArea.SuspendLayout();
            this.roleListPanel.SuspendLayout();
            this.userListPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.userPnl.SuspendLayout();
            this.userTools.SuspendLayout();
            this.rolePnl.SuspendLayout();
            this.roleTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // usersBinding
            // 
            this.usersBinding.Sort = "FullName";
            // 
            // rolesBinding
            // 
            this.rolesBinding.Sort = "Name";
            // 
            // navArea
            // 
            this.navArea.BackColor = System.Drawing.SystemColors.Window;
            this.navArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.navArea.Controls.Add(this.roleListPanel);
            this.navArea.Controls.Add(this.roleBtn);
            this.navArea.Controls.Add(this.userListPanel);
            this.navArea.Controls.Add(this.userBtn);
            this.navArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.navArea.Location = new System.Drawing.Point(0, 0);
            this.navArea.Name = "navArea";
            this.navArea.Size = new System.Drawing.Size(123, 506);
            this.navArea.TabIndex = 0;
            // 
            // roleListPanel
            // 
            this.roleListPanel.Controls.Add(this.roleList);
            this.roleListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.roleListPanel.Location = new System.Drawing.Point(0, 169);
            this.roleListPanel.Name = "roleListPanel";
            this.roleListPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.roleListPanel.Size = new System.Drawing.Size(119, 179);
            this.roleListPanel.TabIndex = 11;
            // 
            // roleList
            // 
            this.roleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roleList.DataSource = this.rolesBinding;
            this.roleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roleList.FormattingEnabled = true;
            this.roleList.IntegralHeight = false;
            this.roleList.Location = new System.Drawing.Point(0, 2);
            this.roleList.Name = "roleList";
            this.roleList.Size = new System.Drawing.Size(119, 175);
            this.roleList.TabIndex = 3;
            // 
            // roleBtn
            // 
            this.roleBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.roleBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.roleBtn.FlatAppearance.BorderSize = 0;
            this.roleBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Highlight;
            this.roleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roleBtn.Image = ((System.Drawing.Image)(resources.GetObject("roleBtn.Image")));
            this.roleBtn.Location = new System.Drawing.Point(0, 145);
            this.roleBtn.Name = "roleBtn";
            this.roleBtn.Size = new System.Drawing.Size(119, 24);
            this.roleBtn.TabIndex = 10;
            this.roleBtn.TabStop = true;
            this.roleBtn.Text = "Roles";
            this.roleBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roleBtn.UseVisualStyleBackColor = true;
            // 
            // userListPanel
            // 
            this.userListPanel.Controls.Add(this.userList);
            this.userListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userListPanel.Location = new System.Drawing.Point(0, 24);
            this.userListPanel.Name = "userListPanel";
            this.userListPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.userListPanel.Size = new System.Drawing.Size(119, 121);
            this.userListPanel.TabIndex = 9;
            // 
            // userList
            // 
            this.userList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userList.DataSource = this.usersBinding;
            this.userList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userList.FormattingEnabled = true;
            this.userList.IntegralHeight = false;
            this.userList.Location = new System.Drawing.Point(0, 2);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(119, 117);
            this.userList.TabIndex = 2;
            // 
            // userBtn
            // 
            this.userBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.userBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.userBtn.FlatAppearance.BorderSize = 0;
            this.userBtn.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Highlight;
            this.userBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userBtn.Image = ((System.Drawing.Image)(resources.GetObject("userBtn.Image")));
            this.userBtn.Location = new System.Drawing.Point(0, 0);
            this.userBtn.Name = "userBtn";
            this.userBtn.Size = new System.Drawing.Size(119, 24);
            this.userBtn.TabIndex = 1;
            this.userBtn.TabStop = true;
            this.userBtn.Text = "Users";
            this.userBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.userBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.okBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 506);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 45);
            this.panel2.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(504, 10);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "Save";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // userPnl
            // 
            this.userPnl.Controls.Add(this.userRoleList);
            this.userPnl.Controls.Add(this.userTools);
            this.userPnl.Controls.Add(this.HLine2);
            this.userPnl.Controls.Add(this.Label4);
            this.userPnl.Controls.Add(this.Label3);
            this.userPnl.Controls.Add(this.loginTxt);
            this.userPnl.Controls.Add(this.firstNameTxt);
            this.userPnl.Controls.Add(this.Label2);
            this.userPnl.Controls.Add(this.HLine1);
            this.userPnl.Controls.Add(this.lastNameTxt);
            this.userPnl.Controls.Add(this.Label1);
            this.userPnl.Location = new System.Drawing.Point(129, 2);
            this.userPnl.Name = "userPnl";
            this.userPnl.Size = new System.Drawing.Size(437, 423);
            this.userPnl.TabIndex = 2;
            // 
            // userRoleList
            // 
            this.userRoleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userRoleList.FormattingEnabled = true;
            this.userRoleList.IntegralHeight = false;
            this.userRoleList.Location = new System.Drawing.Point(6, 161);
            this.userRoleList.Name = "userRoleList";
            this.userRoleList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.userRoleList.Size = new System.Drawing.Size(428, 259);
            this.userRoleList.TabIndex = 41;
            // 
            // userTools
            // 
            this.userTools.CanOverflow = false;
            this.userTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.userTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userAddBtn,
            this.userEditBtn,
            this.userDelBtn});
            this.userTools.Location = new System.Drawing.Point(0, 0);
            this.userTools.Name = "userTools";
            this.userTools.Size = new System.Drawing.Size(437, 25);
            this.userTools.TabIndex = 40;
            this.userTools.Text = "ToolStrip1";
            // 
            // userAddBtn
            // 
            this.userAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("userAddBtn.Image")));
            this.userAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userAddBtn.Name = "userAddBtn";
            this.userAddBtn.Size = new System.Drawing.Size(46, 22);
            this.userAddBtn.Text = "Add";
            this.userAddBtn.Click += new System.EventHandler(this.userAddBtn_Click);
            // 
            // userEditBtn
            // 
            this.userEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("userEditBtn.Image")));
            this.userEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userEditBtn.Name = "userEditBtn";
            this.userEditBtn.Size = new System.Drawing.Size(45, 22);
            this.userEditBtn.Text = "Edit";
            this.userEditBtn.Click += new System.EventHandler(this.userEditBtn_Click);
            // 
            // userDelBtn
            // 
            this.userDelBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("userDelBtn.Image")));
            this.userDelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.userDelBtn.Name = "userDelBtn";
            this.userDelBtn.Size = new System.Drawing.Size(58, 22);
            this.userDelBtn.Text = "Delete";
            this.userDelBtn.Click += new System.EventHandler(this.userDelBtn_Click);
            // 
            // HLine2
            // 
            this.HLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HLine2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.HLine2.LineDrawStyle = LineDrawStyle.System;
            this.HLine2.Location = new System.Drawing.Point(6, 132);
            this.HLine2.Name = "HLine2";
            this.HLine2.Size = new System.Drawing.Size(428, 10);
            this.HLine2.TabIndex = 36;
            this.HLine2.TabStop = false;
            this.HLine2.Text = "HLine2";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(4, 145);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(60, 13);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Member of:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(4, 41);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(36, 13);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "Login:";
            // 
            // loginTxt
            // 
            this.loginTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loginTxt.Location = new System.Drawing.Point(79, 38);
            this.loginTxt.Name = "loginTxt";
            this.loginTxt.ReadOnly = true;
            this.loginTxt.Size = new System.Drawing.Size(355, 20);
            this.loginTxt.TabIndex = 21;
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameTxt.Location = new System.Drawing.Point(79, 106);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.ReadOnly = true;
            this.firstNameTxt.Size = new System.Drawing.Size(355, 20);
            this.firstNameTxt.TabIndex = 33;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(4, 109);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 32;
            this.Label2.Text = "Given Name:";
            // 
            // HLine1
            // 
            this.HLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HLine1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.HLine1.LineDrawStyle = LineDrawStyle.System;
            this.HLine1.Location = new System.Drawing.Point(6, 64);
            this.HLine1.Name = "HLine1";
            this.HLine1.Size = new System.Drawing.Size(428, 10);
            this.HLine1.TabIndex = 1;
            this.HLine1.TabStop = false;
            this.HLine1.Text = "HLine1";
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameTxt.Location = new System.Drawing.Point(79, 80);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.ReadOnly = true;
            this.lastNameTxt.Size = new System.Drawing.Size(355, 20);
            this.lastNameTxt.TabIndex = 31;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 83);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 30;
            this.Label1.Text = "Family Name:";
            // 
            // rolePnl
            // 
            this.rolePnl.Controls.Add(this.roleActionList);
            this.rolePnl.Controls.Add(this.roleTools);
            this.rolePnl.Controls.Add(this.Label6);
            this.rolePnl.Controls.Add(this.HLine3);
            this.rolePnl.Controls.Add(this.roleNameTxt);
            this.rolePnl.Controls.Add(this.Label5);
            this.rolePnl.Location = new System.Drawing.Point(141, 453);
            this.rolePnl.Name = "rolePnl";
            this.rolePnl.Size = new System.Drawing.Size(357, 423);
            this.rolePnl.TabIndex = 3;
            // 
            // roleActionList
            // 
            this.roleActionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.roleActionList.FormattingEnabled = true;
            this.roleActionList.IntegralHeight = false;
            this.roleActionList.Location = new System.Drawing.Point(6, 93);
            this.roleActionList.Name = "roleActionList";
            this.roleActionList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.roleActionList.Size = new System.Drawing.Size(348, 327);
            this.roleActionList.TabIndex = 42;
            // 
            // roleTools
            // 
            this.roleTools.CanOverflow = false;
            this.roleTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.roleTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roleAddBtn,
            this.roleEditBtn,
            this.roleDelBtn});
            this.roleTools.Location = new System.Drawing.Point(0, 0);
            this.roleTools.Name = "roleTools";
            this.roleTools.Size = new System.Drawing.Size(357, 25);
            this.roleTools.TabIndex = 41;
            this.roleTools.Text = "ToolStrip2";
            // 
            // roleAddBtn
            // 
            this.roleAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("roleAddBtn.Image")));
            this.roleAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.roleAddBtn.Name = "roleAddBtn";
            this.roleAddBtn.Size = new System.Drawing.Size(46, 22);
            this.roleAddBtn.Text = "Add";
            this.roleAddBtn.Click += new System.EventHandler(this.roleAddBtn_Click);
            // 
            // roleEditBtn
            // 
            this.roleEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("roleEditBtn.Image")));
            this.roleEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.roleEditBtn.Name = "roleEditBtn";
            this.roleEditBtn.Size = new System.Drawing.Size(45, 22);
            this.roleEditBtn.Text = "Edit";
            this.roleEditBtn.Click += new System.EventHandler(this.roleEditBtn_Click);
            // 
            // roleDelBtn
            // 
            this.roleDelBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.roleDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("roleDelBtn.Image")));
            this.roleDelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.roleDelBtn.Name = "roleDelBtn";
            this.roleDelBtn.Size = new System.Drawing.Size(58, 22);
            this.roleDelBtn.Text = "Delete";
            this.roleDelBtn.Click += new System.EventHandler(this.roleDelBtn_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(3, 77);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(67, 13);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Can perform:";
            // 
            // HLine3
            // 
            this.HLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HLine3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.HLine3.LineDrawStyle = LineDrawStyle.System;
            this.HLine3.Location = new System.Drawing.Point(6, 64);
            this.HLine3.Name = "HLine3";
            this.HLine3.Size = new System.Drawing.Size(348, 10);
            this.HLine3.TabIndex = 7;
            this.HLine3.TabStop = false;
            this.HLine3.Text = "HLine3";
            // 
            // roleNameTxt
            // 
            this.roleNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.roleNameTxt.Location = new System.Drawing.Point(47, 38);
            this.roleNameTxt.Name = "roleNameTxt";
            this.roleNameTxt.ReadOnly = true;
            this.roleNameTxt.Size = new System.Drawing.Size(307, 20);
            this.roleNameTxt.TabIndex = 6;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(3, 41);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(38, 13);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "Name:";
            // 
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 551);
            this.Controls.Add(this.rolePnl);
            this.Controls.Add(this.userPnl);
            this.Controls.Add(this.navArea);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.UserManagerForm_Load);
            this.Resize += new System.EventHandler(this.UserManagerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.usersBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolesBinding)).EndInit();
            this.navArea.ResumeLayout(false);
            this.roleListPanel.ResumeLayout(false);
            this.userListPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.userPnl.ResumeLayout(false);
            this.userPnl.PerformLayout();
            this.userTools.ResumeLayout(false);
            this.userTools.PerformLayout();
            this.rolePnl.ResumeLayout(false);
            this.rolePnl.PerformLayout();
            this.roleTools.ResumeLayout(false);
            this.roleTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource usersBinding;
        private System.Windows.Forms.BindingSource rolesBinding;
        private System.Windows.Forms.Panel navArea;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okBtn;
        internal System.Windows.Forms.RadioButton userBtn;
        internal System.Windows.Forms.RadioButton roleBtn;
        internal System.Windows.Forms.Panel userListPanel;
        internal System.Windows.Forms.ListBox userList;
        internal System.Windows.Forms.Panel roleListPanel;
        internal System.Windows.Forms.ListBox roleList;
        internal System.Windows.Forms.Panel userPnl;
        internal System.Windows.Forms.ListBox userRoleList;
        internal System.Windows.Forms.ToolStrip userTools;
        internal System.Windows.Forms.ToolStripButton userAddBtn;
        internal System.Windows.Forms.ToolStripButton userEditBtn;
        internal System.Windows.Forms.ToolStripButton userDelBtn;
        internal HLine HLine2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox loginTxt;
        internal System.Windows.Forms.TextBox firstNameTxt;
        internal System.Windows.Forms.Label Label2;
        internal HLine HLine1;
        internal System.Windows.Forms.TextBox lastNameTxt;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel rolePnl;
        internal System.Windows.Forms.ListBox roleActionList;
        internal System.Windows.Forms.ToolStrip roleTools;
        internal System.Windows.Forms.ToolStripButton roleAddBtn;
        internal System.Windows.Forms.ToolStripButton roleEditBtn;
        internal System.Windows.Forms.ToolStripButton roleDelBtn;
        internal System.Windows.Forms.Label Label6;
        internal HLine HLine3;
        internal System.Windows.Forms.TextBox roleNameTxt;
        internal System.Windows.Forms.Label Label5;
    }
}