using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Inventory
{
    public partial class ToteTransferForm : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork m_session;
        private Tote m_tote;

        public ToteTransferForm(Tote tote)
        {
            InitializeComponent();
            m_tote = tote;
            Init();
            Bind();
        }

        private void Init()
        {
            m_session = m_tote.Session;

            if (m_session == null)
                throw new NotImplementedException("Tote.Session must be of type UnitOfWork!");
        }

        private void Bind()
        {
            contentsPivot.DataSource = m_tote.Contents;
            toteNameText.Text = m_tote.Label;
            domainText.Text = m_tote.Domain.ToString();
            domainLookup.Properties.DataSource = Scout.Core.Service<IAreaService>().GetAllDomains(m_session);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            Domain domain = domainLookup.EditValue as Domain;
            if (domain == null)
                return;

            try
            {
                Scout.Core.Service<IToteService>()
                    .TransferToteToDomain(m_tote, domain);

                Scout.Core.Data.Save(m_session);
                                
                Bind();
                
                MessageBox.Show("Transfer complete", Application.ProductName, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}