using System;
using System.Collections.Generic;
using System.Data;


namespace SCOUT.Core.Data
{
    public class ReceivingResults
    {
        private int poNbr;
        private DataTable expectedTable;
        private DataTable processedTable;
        private DataTable discrepantTable;
        private List<DataTable> tableList;

        public ReceivingResults(int poNumber)
        {
            poNbr = poNumber;
            tableList = new List<DataTable>();
            LoadData();
        }

        public DataTable Expected
        {
            get { return expectedTable;  }
        }

        public DataTable Processed
        {
            get { return processedTable;  }
        }

        public DataTable Discrepancies
        {
            get { return discrepantTable;  }
        }

        public IList<DataTable> TableList
        {
            get { return tableList;  }
        }

        private void LoadData()
        {
            Query q = new StoredProc("usp_GetReceiptProcessResults");
            q.Parameters.AddWithValue("@pordernbr", poNbr);

            DataSet ds = q.ExecuteDataSet();

            expectedTable = ds.Tables[0];
            expectedTable.TableName = "Expected";

            processedTable = ds.Tables[1];
            processedTable.TableName = "Processed";

            discrepantTable = ds.Tables[2];
            discrepantTable.TableName = "Discrepancies";

            FillTableList();
                                   
        }

        public bool PNisValidForPO(string pn)
        {
            if( expectedTable.Rows.Count ==0 )
            {
                return true;
            }

            foreach (DataRow row in expectedTable.Rows)
            {
                if (row["Part No."].ToString().ToUpper() == pn.ToUpper())
                {
                    return true;
                }                
            }

            return false;   
        }

        public int RecQtyForPN(string pn)
        {
            int i = 0;
            foreach (DataRow row in processedTable.Rows)
            {
                if (row["Part No."].ToString() == pn)
                {
                    i += Int32.Parse(row["QTY"].ToString());
                }
            }

            return i;
        }

        private void FillTableList()
        {
            tableList.Add(expectedTable);
            tableList.Add(processedTable);
            tableList.Add(discrepantTable);
        }
    }
}