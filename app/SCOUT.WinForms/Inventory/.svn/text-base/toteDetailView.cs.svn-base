using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;
using ToteCommands=SCOUT.WinForms.Core.ToteCommands;

namespace SCOUT.WinForms.Inventory
{
    public partial class ToteDetailView : DevExpress.XtraEditors.XtraForm
    {
        private readonly Tote m_tote;
        private IUnitOfWork m_session;
        private FrontController m_frontColler = FrontController.GetInstance();

        public ToteDetailView(Tote tote)
        {
            m_tote = tote;
            InitializeComponent();
            Init();
            Bind();            
        }
        private void Init()
        {
            m_session = m_tote.Session;
        }

        private void Bind()
        {
            idText.DataBindings.Add("Text", m_tote, "Label");           
            toteTypeSelList.Properties.DataSource = Enum.GetValues(typeof (ToteType));
            domainSelList.DataBindings.Add("EditValue", m_tote, "Domain!");
            toteTypeSelList.DataBindings.Add("EditValue", m_tote, "ToteType");

            domainSelList.Properties.DataSource = Scout.Core.Service<IAreaService>().GetAllDomains(m_session);
            domainSelList.Properties.DisplayMember = "Label";
            domainSelList.Properties.ValueMember = "This";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                Scout.Core.Data.Save(m_session);                
                PrintLabel();
                Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintLabel()
        {
            m_frontColler.RunCommand(ToteCommands.TotePrintLabel, m_tote);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}