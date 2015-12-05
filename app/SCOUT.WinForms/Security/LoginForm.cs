using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public partial class LoginForm : XtraForm
    {
        private XPCollection<Site> m_sites =
            new XPCollection<Site>(Scout.Core.Data.GetUnitOfWork());

        private string m_verStr;

        public LoginForm()
        {
            InitializeComponent();

            Text = Application.ProductName + " Login";

            GetVersionInfo();
            SetStatus(Color.Black, "Welcome to " + Application.ProductName);

            Closing += LoginForm_Closing;
            initLists();
        }


        private void LoginForm_Closing(object sender,
                                       System.ComponentModel.CancelEventArgs e)
        {
            if (ApplicationEntry.updateController1 != null)
                ApplicationEntry.updateController1.Dispose();
        }


        private void initLists()
        {
            // Make sure we have at least one site to chose from.
            if (m_sites.Count == 0)
            {
                InfoBox ib = new InfoBox();

                ib.Icon = MessageBoxIcon.Exclamation;
                ib.Show("There are no sites to log into!");

                return;
            }

            // Load sites into site drop down.
            siteSelList.Properties.Items.AddRange(m_sites);
            int lastSel = 0;

            if (m_sites.Count > 1)
                Int32.TryParse(SCOUT.Core.Data.Helpers.Config["LastSiteIdx"], out lastSel);

            siteSelList.SelectedIndex = lastSel;
        }


        private void GetVersionInfo()
        {
            m_verStr = String.Format("{0}.{1}.{2}.{3}", VersionInfo.Major,
                                          VersionInfo.Minor,
                                          VersionInfo.Revision,
                                          VersionInfo.Build);

            versionLabel.Caption = String.Format(versionLabel.Caption, m_verStr,
                                                 VersionInfo.Build);
        }


        private void SetStatus(Color c, string txt)
        {
            statusLabel.Appearance.ForeColor = c;
            statusLabel.NullText = txt;
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Ensure that a site has been selected.
            Site selectedSite = siteSelList.SelectedItem as Site;

            if (selectedSite == null)
            {
                InfoBox ib = new InfoBox();

                ib.Icon = MessageBoxIcon.Exclamation;
                ib.Show("You must select a site to log into.");

                siteSelList.Focus();
                return;
            }

            SCOUT.Core.Security.UserSecurity.User u;

            SetStatus(Color.Black, "Authenticating...");

            if (userEdit.EditValue == null)
                u = null;
            else
                u =
                    SCOUT.Core.Security.UserSecurity.User.GetUser(
                        userEdit.EditValue.ToString());

            if (u != null)
            {
                if (u.Password == passEdit.EditValue.ToString())
                {
                    SCOUT.Core.Data.Site.Current = selectedSite;

                    SCOUT.Core.Security.UserSecurity.CurrentUser = u;

                    CheckForForcedPassChange(u);

                    Scout.Core.Modules.Client.RecordClientLogOn(u.Login, u.MachineName, m_verStr);

                    SCOUT.Core.Data.Helpers.Config["LastSiteIdx"] =
                        siteSelList.SelectedIndex.ToString();

                    DialogResult = DialogResult.OK;
                    return;
                }
            }

            passEdit.EditValue = null;
            userEdit.Focus();

            SetStatus(Color.Red, "Invalid username or password!");
        }


        private void CheckForForcedPassChange(SCOUT.Core.Security.UserSecurity.User user)
        {
            if (user.ForcePassChange)
            {
                PasswordForm dlg = new PasswordForm(user);

                dlg.ShowDialog(this);
            }
        }
    }
}