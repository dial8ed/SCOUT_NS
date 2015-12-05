using System;
using DevExpress.XtraReports.Parameters;
using SCOUT.WinForms.Reports;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class TotePrintLabelDomainCommand : Command
    {
        private Tote m_tote;
        public TotePrintLabelDomainCommand(params object[] input) : base(input)
        {
            m_tote = input[0] as Tote;
        }

        public override void Execute()
        {            
            ToteTravelerReport report = new ToteTravelerReport();
            report.Parameters[0].Value = m_tote.Id;
            report.ShowPreview();            
        }
    }
}