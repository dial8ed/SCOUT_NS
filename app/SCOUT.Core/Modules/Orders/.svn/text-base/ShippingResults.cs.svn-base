using System;
using System.Collections.Generic;
using System.Data;

namespace SCOUT.Core.Data
{
    public class ShippingResults
    {
        private readonly int soNbr;
        private DataTable expectedTable;
        private DataTable processedTable;
        private readonly List<DataTable> tableList;

        public DataTable ExpectedTable
        {
            get { return expectedTable; }
        }

        public DataTable ProcessedTable
        {
            get { return processedTable; }
        }

        public List<DataTable> TableList
        {
            get { return tableList; }
        }

        public ShippingResults(int soNbr)
        {
            this.soNbr = soNbr;
            tableList = new List<DataTable>();
            LoadData();
        }

        public int ShipmentCountForPN(string pn)
        {
            int shippedQty = 0;
            foreach (DataRow row in processedTable.Rows)
            {
                if (row["Part No."].ToString() == pn)
                {
                    shippedQty += Int32.Parse(row["QTY"].ToString());
                }
            }

            return shippedQty;
        }

        private void LoadData()
        {
            Query q = new StoredProc("usp_GetSalesShipmentProcessResults");
            q.Parameters.AddWithValue("@sordernbr", soNbr);

            DataSet ds = q.ExecuteDataSet();
          
            expectedTable = ds.Tables[0];
            expectedTable.TableName = "Expected";

            processedTable = ds.Tables[1];
            processedTable.TableName = "Processed";

            FillTableList();

        }

        private void FillTableList()
        {
            tableList.Add(expectedTable);
            tableList.Add(processedTable);
        }
    }
}