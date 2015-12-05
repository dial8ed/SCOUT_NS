using System;
using System.Windows.Forms;

namespace SCOUT.WinForms
{
    public partial class PasswordForm : Form
    {
        SCOUT.Core.Security.UserSecurity.User m_user;
        bool m_forced;

        public PasswordForm()
        {
            InitializeComponent();
            m_user = SCOUT.Core.Security.UserSecurity.CurrentUser;
            m_forced = m_user.ForcePassChange;
        }

        public PasswordForm(SCOUT.Core.Security.UserSecurity.User user)
        {
            InitializeComponent();
            m_user = user;
            m_forced = m_user.ForcePassChange;
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            if (m_user.ForcePassChange)
            {
                msgPanel.Visible = true;
                cancelBtn.Enabled = false;

                oldTxt.Text = "123456";
                oldTxt.Enabled = false;
            }
            else
            {
                msgPanel.Visible = false;

                Height -= msgPanel.Height;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!m_forced)
            {
                /*
                 * Check if forced because we fill in bogus info
                 * on the forced version.
                 */
                if (m_user.Password != oldTxt.Text)
                {
		    InfoBox ib = new InfoBox();

		    ib.Icon = MessageBoxIcon.Error;
		    ib.Show("Old password incorrect.");

                    return;
                }
            }

            string npass = newTxt.Text.Trim();
            string cpass = confirmTxt.Text.Trim();

            if (npass == String.Empty)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show("A password is required.");

                newTxt.Focus();
                return;
            }

            if (npass != cpass)
            {
		InfoBox ib = new InfoBox();

                ib.Show("New and confirm passwords do not match.");

                return;
            }

            if (npass == m_user.Password)
            {
		InfoBox ib = new InfoBox();

		ib.Show("New and old passwords must be different.");

                return;
            }

            m_user.Password = npass;
            m_user.ForcePassChange = false;

            try
            {
                m_user.Save();
                MessageBox.Show("Password changed.", Application.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
		InfoBox ib = new InfoBox();

		ib.Icon = MessageBoxIcon.Error;
		ib.Show(ex.Message);

                if (!m_forced)
                    return;
            }

            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}