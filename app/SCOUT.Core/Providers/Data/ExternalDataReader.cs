using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Reads csv, xls, and xslx files into a DataSet
    /// </summary>
    public class ExternalDataReader
    {
        public static T FillDataSet<T>(FileInfo fileInfo, ref T dataSet, string tableName) where T : DataSet
        {
            CreateOleDbConnectionDelegate createConnection = null;
            string commandText = "";

            switch(fileInfo.Extension)
            {
                case(".xls"):                
                    createConnection = 
                        new CreateOleDbConnectionDelegate(OleDbConnections.ExcelJetOleDbConnection);
                    commandText = "SELECT * FROM [Sheet1$]";
                
                    break;

                case(".xlsx"):
                    createConnection =
                     new CreateOleDbConnectionDelegate(OleDbConnections.ExcelAceOleDbConnection);
                    commandText = "SELECT * FROM [Sheet1$]";

                    break;

                case(".csv"):
                    createConnection = 
                        new CreateOleDbConnectionDelegate(OleDbConnections.CsvOleDbConnection);
                    commandText = "SELECT * FROM [" + fileInfo.Name + "]";

                    break;                    
            }

            if(createConnection == null)
                throw new NotSupportedException("A OleDbConnection was not found for extension [" + fileInfo.Extension + "]");
           
                OleDbConnection dbConnection = createConnection(fileInfo);
                return OleDbHelper.FillDataSet(ref dataSet, tableName, dbConnection,
                                    commandText);

                                         
        }
    }
}