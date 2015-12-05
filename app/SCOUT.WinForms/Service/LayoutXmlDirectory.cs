using System;
using SCOUT.WinForms.Reports;

namespace SCOUT.WinForms.Service
{
    public class LayoutXmlDirectory
    {
        public const string XmlPath = ReportDirectory.ReportPath;

        public static string NewFilePath()
        {
            return string.Format(@"{0}\{1}.xml", XmlPath, Guid.NewGuid());
        }        
    }
}