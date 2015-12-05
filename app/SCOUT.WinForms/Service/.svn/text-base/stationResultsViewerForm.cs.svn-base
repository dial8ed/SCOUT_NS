using System;
using System.Drawing;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class StationResultsViewerForm : XtraForm
    {
        private readonly RouteStationProcess m_process;

        public StationResultsViewerForm(RouteStationProcess process)
        {            
            InitializeComponent();
            m_process = process;
            Bind();            
            LoadResults();
            LoadFailures();           
        }

        private void Bind()
        {
            try
            {
            stationText.Text = m_process.Station.Name;
            createdByText.Text = m_process.CreatedBy;
            createDateText.Text = m_process.CreatedDate.ToString();
            outcomeText.Text = m_process.StationOutcome.ToString();
            nextStationText.Text = m_process.NextStationName;
        }
        catch (Exception ex )
            {
                // Silent throw;
                Console.WriteLine(ex.Message);            
            }
        }

        private void LoadFailures()
        {
            failRepairsGrid.DataSource = m_process.AllProcessFailures;
        }

        private void LoadResults()
        {
            foreach (RouteStationResult result in m_process.Results)
            {                
                TextEdit editor = new TextEdit();
                editor.Text = result.Result;
                editor.Properties.ReadOnly = true;
                editor.BackColor = Color.White;

                stepResultsLayout.AddItem(
                    result.Step.DisplayPrompt, editor);                        
            }
        }
    }
}