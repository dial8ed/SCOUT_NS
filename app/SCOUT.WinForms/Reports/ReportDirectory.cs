using System.Collections.Generic;
using System.IO;
using DevExpress.XtraReports.UI;

namespace SCOUT.WinForms.Reports
{
    public class ReportDirectory
    {
        public const string ReportPath = @"\\sqlsrv08\User Reports\";

        public static XtraReport CreateReportFromFile(string reportName)
        {
            XtraReport report = new XtraReport();
            report = XtraReport.FromFile(reportName,true);
            return report;           
        }

        public static List<ReportInfo> ReportList
        {
            get
            {
                return null;
                DirectoryInfo directoryInfo = new DirectoryInfo(ReportPath);
                FileInfo[] resxFiles = directoryInfo.GetFiles("*.repx");

                List<ReportInfo> reports = new List<ReportInfo>();

                foreach (FileInfo file in resxFiles)
                {
                   reports.Add(new ReportInfo(file.FullName,file.Name));
                }

                return reports;
            }
        }       
    }

    public class ReportInfo
    {       
        public ReportInfo(string path, string name)
        {
            Path = path;
            Name = name;
        }

        public string Name { get; private set; }

        public string Path { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}