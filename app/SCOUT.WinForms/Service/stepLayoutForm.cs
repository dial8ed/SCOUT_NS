using System;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class StepLayoutForm : DevExpress.XtraEditors.XtraForm
    {
        private RouteStation m_station;
        private RouteStationConfiguration m_config;

        public StepLayoutForm(RouteStationConfiguration config)
        {
            InitializeComponent();
            //m_station = config.RouteStation;
            m_config = config;
            LoadEditors();
        }

        private void LoadEditors()
        {
            stepsLayout.Items.Clear();

            m_config.SortStepsBySeqNo();

            foreach (RouteStationStep step in m_config.ActiveSteps)
            {
                if(step.ResultList != null)
                {
                    stepsLayout.AddItem(
                        step.DisplayPrompt,
                        new StepLayoutLookupMapper().MapFrom(step));
                }
                else
                {
                    stepsLayout.AddItem(
                        step.DisplayPrompt,
                        new StepLayoutTextMapper().MapFrom(step));
                }                
            }      
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //SaveLayoutToFile();
            //MessageBox.Show("Layout saved to file", Application.ProductName, MessageBoxButtons.OK,
            //                MessageBoxIcon.Information);
            Close();
        }

        private void SaveLayoutToFile()
        {
            string filePath = m_station.LayoutXmlPath;

            if (filePath == null)
            {
                filePath = LayoutXmlDirectory.NewFilePath();                
                m_station.LayoutXmlPath = filePath;
            }

            stepsLayout.SaveLayoutToXml(filePath);            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}