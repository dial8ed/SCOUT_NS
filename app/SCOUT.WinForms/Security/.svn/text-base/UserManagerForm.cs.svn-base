using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SCOUT.Core.Security;

namespace SCOUT.WinForms
{
    public partial class UserManagerForm : Form
    {
        private UserSecurity.Role m_adminRole = null;

        private class CheckInfo
        {
            public Panel MainPanel;
            public Panel SubPanel;
        }

        public UserManagerForm()
        {
            InitializeComponent();

            m_adminRole = SCOUT.Core.Security.UserSecurity.Roles.Find
                ("Id", SCOUT.Core.Security.UserSecurity.Role.AdminRoleId);

            InitBinidngs();

            InitNavRadioBtn(userBtn, userPnl, userListPanel);
            InitNavRadioBtn(roleBtn, rolePnl, roleListPanel);
        }

        #region Initialization

        private void InitNavRadioBtn(RadioButton btn, 
            Panel mainPanel, Panel subPanel)
        {
            CheckInfo ci = new CheckInfo();

            ci.MainPanel = mainPanel;
            ci.SubPanel = subPanel;

            if (mainPanel != null)
            {
                mainPanel.Visible = false;
                mainPanel.Dock = DockStyle.Fill;
            }

            if (subPanel != null)
                subPanel.Visible = false;

            btn.Tag = ci;
            btn.CheckedChanged += NavBtn_CheckedChanged;
        }

        private void InitBinidngs()
        {
            // Base bindings.
            usersBinding.DataSource = UserSecurity.Users;
            rolesBinding.DataSource = UserSecurity.Roles;

            // Navigation Panel
            userList.DisplayMember = "FullName";
            roleList.DisplayMember = "Name";

            // User Panel
            loginTxt.DataBindings.Add("Text", usersBinding, "Login");
            lastNameTxt.DataBindings.Add("Text", usersBinding, "FamilyName");
            firstNameTxt.DataBindings.Add("Text", usersBinding, "GivenName");

            userRoleList.DataBindings.Add("DataSource", usersBinding, "Roles");
            userRoleList.DisplayMember = "Name";

            // Role Panel
            roleNameTxt.DataBindings.Add("Text", rolesBinding, "Name");

            roleActionList.DataBindings.Add("DataSource", rolesBinding, "Actions");
            roleActionList.DisplayMember = "Name";
        }

        #endregion

        #region Utility

        private bool IsSuperAdmin
        {
            get
            {
                return UserSecurity.CurrentUser
                    .CanPerform(SCOUT.Core.Security.UserSecurity.Action.AdministrateAdmins);
            }
        }

        private void UpdateRadioNavBtn(RadioButton btn)
        {
            CheckInfo ci = (CheckInfo)btn.Tag;

            if (ci.MainPanel != null)
                ci.MainPanel.Visible = btn.Checked;

            if (ci.SubPanel != null)
                ci.SubPanel.Visible = btn.Checked;

            btn.ForeColor = btn.Checked ? 
                SystemColors.HighlightText :
                SystemColors.ControlText;
        }

        private void AdjustNavAreaListSizes()
        {
            int h = navArea.Height;

            // Calculate the available height for our list panels.
            foreach (Control c in navArea.Controls)
            {
                if (c.Visible && (c.GetType() == typeof(RadioButton)))
                    h -= c.Height;
            }

            SuspendLayout();

            // Adjust the heights of our lists.
            foreach (Control c in navArea.Controls)
            {
                if (c.GetType() == typeof(Panel))
                    c.Height = h;
            }

            ResumeLayout();
        }

        private bool CanSuperAdmin(string action)
        {
            if (!IsSuperAdmin)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("You cannot {0}.", action);

                return false;
            }

            return true;
        }

        #endregion

        #region Event Handlers

        void NavBtn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateRadioNavBtn((RadioButton)sender);
        }

        private void UserManagerForm_Resize(object sender, EventArgs e)
        {
            AdjustNavAreaListSizes();
        }

        private void UserManagerForm_Load(object sender, EventArgs e)
        {
            AdjustNavAreaListSizes();
        }

        private void userAddBtn_Click(object sender, EventArgs e)
        {
            UserEditForm dlg = new UserEditForm(null);

            dlg.ShowDialog(this);
        }

        private void userEditBtn_Click(object sender, EventArgs e)
        {
            UserSecurity.User user = (UserSecurity.User)usersBinding.Current;

            if (user.Login == UserSecurity.CurrentUser.Login)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("You cannot edit yourself!");

                return;
            }

            if (user.Roles.Contains(m_adminRole))
            {
                if (!CanSuperAdmin("edit administrators"))
                    return;
            }

            UserEditForm dlg = new UserEditForm(user);
            
            dlg.ShowDialog(this);
        }

        private void userDelBtn_Click(object sender, EventArgs e)
        {
            UserSecurity.User user = (UserSecurity.User)usersBinding.Current;
	    InfoBox ib = new InfoBox();

        if (user.Login == UserSecurity.CurrentUser.Login)
            {
		ib.Icon = MessageBoxIcon.Error;
		ib.Show("You cannot delete yourself!");

                return;
            }

            DialogResult ans;

	    ib.Type = InfoBoxType.SuperConfirmBox;
	    ib.Icon = MessageBoxIcon.Warning;
	    ib.Buttons = MessageBoxButtons.YesNo;

	    ans = ib.Show("You are about to delete the user \"{0}\".\r" +
                "This operation cannot be undone.\r\r" +
                "Continue anyway?", 
		user.Login);

            if (ans == DialogResult.Yes)
            {
                try
                {
                    UserSecurity.Users.Remove(user);
                    UserSecurity.Users.Save();
                }
                catch (Exception ex)
                {
		    ib = new InfoBox();

		    ib.Icon = MessageBoxIcon.Error;
                    ib.Show("Save Error:\r{0}", ex.Message);
                }
            }
        }

        private void roleAddBtn_Click(object sender, EventArgs e)
        {
            if (!CanSuperAdmin("add roles"))
                return;

            RoleEditForm dlg = new RoleEditForm(null);

            dlg.ShowDialog(this);
        }

        private void roleEditBtn_Click(object sender, EventArgs e)
        {
            if (!CanSuperAdmin("edit roles"))
                return;

            UserSecurity.Role role = (UserSecurity.Role)rolesBinding.Current;

            RoleEditForm dlg = new RoleEditForm(role);

            dlg.ShowDialog(this);
        }

        private void roleDelBtn_Click(object sender, EventArgs e)
        {
            if (!CanSuperAdmin("delete roles"))
                return;

            UserSecurity.Role role = (UserSecurity.Role)rolesBinding.Current;
	    InfoBox ib = new InfoBox();

        if (role.Id == UserSecurity.Role.AdminRoleId)
            {
		ib.Icon = MessageBoxIcon.Error;
		ib.Show("You cannot delete the administrator role!");

                return;
            }

            DialogResult ans;

	    ib.Type = InfoBoxType.SuperConfirmBox;
	    ib.Buttons = MessageBoxButtons.YesNo;
	    ib.Icon = MessageBoxIcon.Warning;
            
	    ans = ib.Show("You are about to delete the \"{0}\" role.\r" +
                "This operation cannot be undone.\r\r" +
                "Continue anyway?", role.Name);

            if (ans == DialogResult.Yes)
            {
                try
                {
                    UserSecurity.Roles.Remove(role);
                    UserSecurity.Roles.Save();
                }
                catch (Exception ex)
                {
		    ib = new InfoBox();

		    ib.Icon = MessageBoxIcon.Error;
                    ib.Show("Save Error:\n{0}", ex.Message);
                }
            }
        }

        #endregion

        private void okBtn_Click(object sender, EventArgs e)
        {
            UserSecurity.Roles.Save();
            UserSecurity.Users.Save();
            Close();
        }
    }
}
