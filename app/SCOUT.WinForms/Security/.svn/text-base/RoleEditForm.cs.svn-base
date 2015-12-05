using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SCOUT.WinForms
{
    public partial class RoleEditForm : Form
    {
        private SCOUT.Core.Security.UserSecurity.Role m_role;

        public RoleEditForm(SCOUT.Core.Security.UserSecurity.Role role)
        {
            InitializeComponent();

            if (role == null)
            {
                m_role = SCOUT.Core.Security.UserSecurity.Roles.AddNew();
                Text = "New Role";
            }
            else
            {
                m_role = role;
                Text = "Editing: " + m_role.Name;
            }

            InitBindings();
        }

        private void InitBindings()
        {
            nameTxt.DataBindings.Add("Text", m_role, "Name");

            actionList.DataSource = SCOUT.Core.Security.UserSecurity.Actions;
            actionList.DisplayMember = "Name";
            actionList.DataBindings.Add("ForeignList", m_role, "Actions");
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                m_role.Save();
            }
            catch (Exception ex)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("Save Error:\r{0}", ex.Message);

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (m_role.Id == -1)
            {
                // Remove the new role.
                SCOUT.Core.Security.UserSecurity.Roles.Remove(m_role);
            }
        }
    }
}
