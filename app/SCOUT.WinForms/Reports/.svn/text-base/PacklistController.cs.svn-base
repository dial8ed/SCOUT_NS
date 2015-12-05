using System.Collections.Generic;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

namespace SCOUT.WinForms.Reports
{
    public abstract class PacklistController
    {
        private XtraReport m_report;
         
        public virtual void LoadReport(string packlistId)
        {             
            m_report = CreateReport();
            
            Parameter param = m_report.Parameters["packlistId"];
            param.Value = packlistId;

            m_report.ShowPreview();    
        }

        public abstract string DisplayName { get;}
        protected abstract XtraReport CreateReport();

        public static List<PacklistController> GetAllPacklistControllers()
        {
            List<PacklistController> m_controllers = new List<PacklistController>();
            m_controllers.Add(new DellPacklistController());
            m_controllers.Add(new StsPacklistController());

            return m_controllers;
        }
        
        public override string ToString()
        {
            return DisplayName;
        }
    }
}