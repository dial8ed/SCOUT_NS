using System;
using System.Windows.Forms;

namespace SCOUT.WinForms
{
    public partial class UserEditForm : Form
    {
        private SCOUT.Core.Security.UserSecurity.User m_user;

        public UserEditForm(SCOUT.Core.Security.UserSecurity.User user)
        {
            InitializeComponent();

            if (user == null)
            {
                m_user = SCOUT.Core.Security.UserSecurity.Users.AddNew();
                Text = "New User";

                loginTxt.ReadOnly = false;
            }
            else
            {
                m_user = user;
                Text = "Editing: " + m_user.FullName;

                loginTxt.ReadOnly = true;
            }

            InitBindings();

            if (user == null)
                forcePassChangeChk.Checked = true;
        }

        private void InitBindings()
        {
            loginTxt.DataBindings.Add("Text", m_user, "Login");
            familyTxt.DataBindings.Add("Text", m_user, "FamilyName");
            givenTxt.DataBindings.Add("Text", m_user, "GivenName");

            // Password is special

            forcePassChangeChk.DataBindings.Add("Checked", m_user,
                "ForcePassChange");

            userRoleList.DataSource = SCOUT.Core.Security.UserSecurity.Roles;
            userRoleList.DisplayMember = "Name";
            userRoleList.DataBindings.Add("ForeignList", m_user, "Roles");
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            string npass = newPassTxt.Text.Trim();
            string cpass = confPassTxt.Text.Trim();

            if (npass != "")
            {
                if (npass != cpass)
                {
		    InfoBox ib = new InfoBox();

		    ib.Icon = MessageBoxIcon.Error;
		    ib.Show("New and confirmation passwords do not match.");

                    return;
                }

                m_user.Password = npass;
            }

            try
            {
                m_user.Save();
            }
            catch (Exception ex)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("Error Saving:\n{0}", ex.Message);

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (!loginTxt.ReadOnly)
            {
                // Remove the new user.
                SCOUT.Core.Security.UserSecurity.Users.Remove(m_user);
            }
            else
                m_user.CancelEdit();
        }

        private void userRoleList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue != CheckState.Checked)
                return;

            if (SCOUT.Core.Security.UserSecurity.CurrentUser
                .CanPerform(SCOUT.Core.Security.UserSecurity.Action.AdministrateAdmins))
            {
                return;
            }

            /*
             * Don't user's who aren't supposed to be allowed to edit admins
             * be able to add them!
             */
            SCOUT.Core.Security.UserSecurity.Role adminRole = SCOUT.Core.Security.UserSecurity.Roles.Find("Id",
                SCOUT.Core.Security.UserSecurity.Role.AdminRoleId);

            if (e.Index == SCOUT.Core.Security.UserSecurity.Roles.IndexOf(adminRole))
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("You cannot add aministrators.");

                e.NewValue = CheckState.Unchecked;

                return;
            }
        }
    }
}
