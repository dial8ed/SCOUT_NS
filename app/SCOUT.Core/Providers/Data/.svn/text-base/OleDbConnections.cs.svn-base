using System.Data.OleDb;
using System.IO;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// OleDbConnection creators
    /// Violates SRP
    /// </summary>
    public static class OleDbConnections
    {
        /// <summary>
        /// Creates a OleDbConnection to a excel(*.xls) file using the provider Microsoft.Jet.OleDb.4.0
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public static OleDbConnection ExcelJetOleDbConnection(FileInfo fileInfo)
        {
            string provider = "Microsoft.Jet.OleDb.4.0";
            string extendedProperties = "Excel 8.0;HDR=Yes;IMEX=1";
            string dataSource = fileInfo.FullName;

            return OleDbConnectionBuilder.CreateConnection(provider,
                                                           dataSource,
                                                           extendedProperties);
        }

        /// <summary>
        /// Creates a OleDbConnection to an excel (*.xlsx) file using the provider Microsoft.Ace.OleDb.12.0
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public static OleDbConnection ExcelAceOleDbConnection(FileInfo fileInfo)
        {            
            string provider = "Microsoft.Ace.OleDb.12.0";
            string dataSource = fileInfo.FullName;
            string extendedProperties = "Excel 12.0 Xml;HDR=Yes;IMEX=1";

            return OleDbConnectionBuilder.CreateConnection(provider, dataSource,
                                                           extendedProperties);

        }

        /// <summary>
        /// Creates a OleDbConnection to an comma seperated values(*.csv) file using the provider Microsoft.Jet.OleDb.4.0
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public static OleDbConnection CsvOleDbConnection(FileInfo fileInfo)
        {
            string provider = "Microsoft.Jet.OleDb.4.0";
            string dataSource = fileInfo.DirectoryName;
            string extendedProperties = "text;HDR=Yes;Format=CSVDelimited";

            return OleDbConnectionBuilder.CreateConnection(provider, dataSource,
                                                           extendedProperties);
        }
    }
}