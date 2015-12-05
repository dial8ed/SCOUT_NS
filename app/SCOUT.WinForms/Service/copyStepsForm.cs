using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Service
{
    public partial class CopyStepsForm : XtraForm
    {
        private IUnitOfWork m_session;
        private RouteStationConfiguration m_config;
        private RouteStationConfiguration m_activeConfig;

        public CopyStepsForm(RouteStationConfiguration config)
        {
            InitializeComponent();
            m_config = config;
            m_session = config.Session;
            Init();
        }

        private void Init()
        {
            LoadLists();
            WireEvents();
        }

        private void WireEvents()
        {
            stationConfigLookUp.EditValueChanged += stationConfigLookUp_EditValueChanged;
            okButton.Click += okButton_Click;
        }

        void okButton_Click(object sender, EventArgs e)
        {
            int[] rowHandles = stepsView.GetSelectedRows();
            if (rowHandles.Length == 0)
            {
                MessageBox.Show("There are no rows selected.",
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Are you sure you want to copy " + rowHandles.Length + " selected steps?", Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (m_activeConfig.CopyStepsToConfig(rowHandles, m_config))
                    MessageBox.Show("Steps copied.",
                                    Application.ProductName,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                Close();
            }
        }

        void stationConfigLookUp_EditValueChanged(object sender, EventArgs e)
        {
            m_activeConfig = stationConfigLookUp.EditValue as RouteStationConfiguration;
            if (m_activeConfig != null)
            {
                LoadSteps(m_activeConfig);                
            }
        }

        private void LoadSteps(RouteStationConfiguration config)
        {
            stepsGrid.DataSource = config.Steps;
        }

        private void LoadLists()
        {
            stationConfigLookUp.Properties.DataSource = 
                Scout.Core.Service<IShopfloorService>().GetAllStationConfigurations(m_session);
        } 
    }
}