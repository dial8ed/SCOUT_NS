using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Areas
{
    public partial class RacklocationGeneratorForm : XtraForm
    {
        private Domain m_domain;

        public RacklocationGeneratorForm(Domain domain)
        {
            InitializeComponent();
            m_domain = domain;
            Bind();
        }

        private void Bind()
        {
            domainText.DataBindings.Add("Text", m_domain, "FullLocation");
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if(!validationProvider.Validate())
                return;

            GenerateLocations();           
        }

        private void GenerateLocations()
        {
            string section = sectionText.Text;
            int numberOfBays = Int32.Parse(baysText.Text);
            int numberOfShelves = Int32.Parse(shelvesText.Text);
            int startingBay = Int32.Parse(startingBayText.Text);

            if (Scout.Core.Service<IAreaService>().GenerateRackLocations(
                m_domain,
                section,
                startingBay,
                numberOfBays, 
                numberOfShelves))
            {
                this.DialogResult = DialogResult.OK;
            }              
        }
    }
}