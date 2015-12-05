using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using SCOUT.Core.Data;


namespace SCOUT.WinForms
{
    static public class Helpers
    {
        static public DataTable GetSalesReps()
        {
            Query q = new StoredProc("usp_GetSalesReps");
            q.CnnStr = SCOUT.Core.Data.Helpers.Config["DB:Security"];

            return q.ExecuteDataTable();
        }

        static public List<string> GetSalesRepList()
        {
            DataTable table = GetSalesReps();

            List<string> salesReps = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                salesReps.Add(row["FullName"].ToString());
            }

            return salesReps;
        }

        /// <summary>
        /// Forces all databound controls to update their underlyign data 
        /// source.  This is needed because for some reason clicking a
        /// button to save the form doesn't always remove focus from a 
        /// currently editing control as the user might expect.....
        /// </summary>
        /// <param name="f"></param>
        static public void ForeceDataBindUpdate(Form f)
        {
            f.Validate();
            f.SelectNextControl(f.ActiveControl, true , false, true, true);
            f.SelectNextControl(f.ActiveControl, false, false, true, true);
        }
    }
}
