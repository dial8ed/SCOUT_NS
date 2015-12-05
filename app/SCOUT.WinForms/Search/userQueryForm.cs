using System;
using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Search
{
    public partial class UserQueryForm : DevExpress.XtraEditors.XtraForm
    {
        private UserQuery m_userQuery;

        public UserQueryForm(UserQuery query)
        {
            m_userQuery = query;
            InitializeComponent();
            Bind();
        }

        private void Bind()
        {
            queryNameText.DataBindings.Add("Text", m_userQuery, "Name");
            sharedCheck.DataBindings.Add("Checked", m_userQuery, "Shared");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                m_userQuery.Save();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
