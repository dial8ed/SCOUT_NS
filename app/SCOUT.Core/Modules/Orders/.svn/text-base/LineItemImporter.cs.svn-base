using System;
using System.Collections.Generic;
using System.Data;

namespace SCOUT.Core.Data
{
    public class LineItemImporter
    {
        private Dictionary<string, int> m_rollUp;
        private DataTable m_table;
        private List<PartToImport> m_importList;
        private string m_partColumnName;

        public LineItemImporter(DataTable table, string partColumnName)
        {
            m_rollUp = new Dictionary<string, int>();
            m_table = table;
            m_partColumnName = partColumnName;
            RollUpLineItems();
        }

        /// <summary>
        /// Adds the part number to the roll up list if it doesnt already exist. 
        /// If it already exists it increments the qty/value by 1
        /// </summary>
        /// <param name="summaryItem"></param>
        private void AddSummaryItem(string summaryItem, int qty)
        {
            if (m_rollUp.ContainsKey(summaryItem))
                m_rollUp[summaryItem] += qty;
            else
                m_rollUp.Add(summaryItem, qty);
        }

        /// <summary>
        /// Loops through the rows in the datatable and adds the items to the roll up list.
        /// </summary>
        private void RollUpLineItems()
        {
            m_rollUp = new Dictionary<string, int>();

            bool tableHasQtyColumn = m_table.Columns.Contains("Qty");

            foreach (DataRow row in m_table.Rows)
            {
                string partNumber;
                int qty;

                if(tableHasQtyColumn)
                    Int32.TryParse(row["Qty"].ToString(), out qty);
                else                
                    qty = 1;

                partNumber = row[m_partColumnName].ToString();
                
                if(!string.IsNullOrEmpty(partNumber))                                    
                    AddSummaryItem(partNumber,qty);
            }
        }

        /// <summary>
        /// Converts the internal roll up dictionary to a list
        /// </summary>
        /// <returns></returns>
        public List<PartToImport> ImportList
        {            
            get
            {
                if (m_importList != null)
                    return m_importList;
                else
                    return BuildImportList();	
            }
            set { }
        }        

        private List<PartToImport> BuildImportList()
        {
            m_importList = new List<PartToImport>();

            foreach (KeyValuePair<string, int> i in m_rollUp)
            {
                m_importList.Add(new PartToImport(i.Key, i.Value));
            }

            return m_importList;
        }
    }
}