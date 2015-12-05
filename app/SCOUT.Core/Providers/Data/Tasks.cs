using System.Data;
using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    public static class Tasks
    {
        // Parameters are up the client for now.
        // TODO: Create sproc objects that will allow to populate the params correctly.
        // This applies to all the methods here that take SqlParam args.
        /// <summary>
        /// Creates a DataTable object from a stored procedure.
        /// </summary>
        /// <param name="sprocName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataTable CreateTableFromSproc(string sprocName, SqlParameter[] sqlParams)
        {
            SqlConnection cn = ConnectionFactory.CreateConnection();
            SqlCommand cm = cn.CreateCommand();

            cm.Parameters.AddRange(sqlParams);
            cm.CommandText = sprocName;
            cm.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable(sprocName);

            da.Fill(dt);

            return dt;
        }

        public static DataSet CreateDataSetFromSproc(string sprocName, SqlParameter[] sqlParams)
        {
            SqlConnection cn = ConnectionFactory.CreateConnection();
            SqlCommand cm = cn.CreateCommand();

            cm.Parameters.AddRange(sqlParams);

            cm.CommandText = sprocName;
            cm.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet(sprocName);

            da.Fill(ds);

            return ds;
        }
    }
}