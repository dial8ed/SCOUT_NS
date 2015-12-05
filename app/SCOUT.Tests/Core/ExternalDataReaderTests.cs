using System.Data;
using System.IO;
using SCOUT.Core.Data;
using NUnit.Framework;


namespace SCOUT.Tests.Core
{
    //[TestFixture]
    public class ExternalDataReaderTests
    {

        //[Test]
        public void excel_jet_provider_populates_dataset()
        {
            DataSet dataSet = new DataSet("excel_jet");
            FileInfo fileInfo = new FileInfo(@"C:\test_xls.xls");
            ExternalDataReader.FillDataSet(fileInfo, ref dataSet, "excel_jet");

            Assert.IsTrue(dataSet.Tables[0].Rows.Count > 0);            
        }
        

        //[Test]
        public void excel_ace_provider_populates_dataset()
        {
            DataSet dataSet = new DataSet("excel_ace");
            FileInfo fileInfo = new FileInfo(@"C:\test_xlsx.xlsx");
            ExternalDataReader.FillDataSet(fileInfo, ref dataSet, "excel_ace");

            Assert.IsTrue(dataSet.Tables[0].Rows.Count > 0);
        }

        //[Test]
        public void csv_jet_provider_populates_dataset()
        {
            DataSet dataSet = new DataSet("csv_jet");
            FileInfo fileInfo = new FileInfo(@"C:\test2_csv.csv");
            ExternalDataReader.FillDataSet(fileInfo, ref dataSet, "csv_jet");

            Assert.IsTrue(dataSet.Tables[0].Rows.Count > 0);
        }
    }
}