using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SCOUT.Core.Data
{
    public abstract class Query
    {
        private readonly SqlCommand m_cmd = new SqlCommand();
        private string m_cnnStr = "";

        public Query()
        {
            m_cnnStr = Helpers.CnnStr();
        }

        #region Properties

        protected abstract CommandType CommandType { get; }
        protected abstract IsolationLevel IsolationLevel { get; }

        public string CnnStr
        {
            get { return m_cnnStr; }
            set { m_cnnStr = value; }
        }

        public SqlParameterCollection Parameters
        {
            get { return m_cmd.Parameters; }
        }

        #endregion       

        #region Utility

        private void FillCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType;
            cmd.CommandText = ToString();

            cmd.Prepare();

            foreach (SqlParameter param in Parameters)
                cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
        }

        private static ItemTy CreateObj<ItemTy>(SafeDataReader dr)
        {
            Type type = typeof(ItemTy);

            if (type.IsAbstract)
            {
                string msg = String.Format("Class {0} is an abstract class." +
                    "  Cannot create objects of an abstract class.",
                    type.Name);

                throw new Exception(msg);
            }

            Type iface = type.GetInterface("ILoadable");
            if (iface == null)
            {
                string msg = String.Format("Class {0} does not implement " +
                    "the ILoadable interface.", type.Name);

                throw new Exception(msg);
            }

            ILoadable obj = Activator.CreateInstance(type) as ILoadable;

            if (obj != null)
                obj.DoLoad(dr);
            else
                throw new Exception("Unable to create object.");

            return (ItemTy)obj;
        }

        #region Readers

        private static ItemTy ReadSingleObject<ItemTy>(SafeDataReader dr)
        {
            ItemTy rval = default(ItemTy);

            if (dr.Read())
                rval = CreateObj<ItemTy>(dr);

            return rval;
        }

        private static IList<ItemTy> ReadObjectList<ItemTy>(SafeDataReader dr)
        {

            List<ItemTy> rval = new List<ItemTy>();

            while (dr.Read())
            {
                ItemTy item = CreateObj<ItemTy>(dr);
                rval.Add(item);
            }

            return rval;
        }

        private static ItemTy ReadSingleScalar<ItemTy>(SafeDataReader dr)
        {
            ItemTy rval = default(ItemTy);

            if (dr.Read())
                rval = (ItemTy)dr.GetValue(0);

            return rval;
        }

        private static List<ItemTy> ReadScalarList<ItemTy>(SafeDataReader dr)
        {
            List<ItemTy> rval = new List<ItemTy>();

            while (dr.Read())
            {
                ItemTy i = (ItemTy)dr.GetValue(0);
                rval.Add(i);
            }

            return rval;
        }

        private static ItemTy ReadSingle<ItemTy>(SafeDataReader dr)
        {
            ItemTy rval = default(ItemTy);
            Type t = typeof(ItemTy);

            if (t.IsPrimitive || (t.Name.ToLower() == "string"))
                rval = ReadSingleScalar<ItemTy>(dr);
            else
                rval = ReadSingleObject<ItemTy>(dr);

            return rval;
        }

        private static IList<ItemTy> ReadList<ItemTy>(SafeDataReader dr)
        {
            IList<ItemTy> rval = new List<ItemTy>();
            Type t = typeof(ItemTy);

            if (t.IsPrimitive || (t.Name.ToLower() == "string"))
                rval = ReadScalarList<ItemTy>(dr);
            else
                rval = ReadObjectList<ItemTy>(dr);

            return rval;
        }

        #endregion

        #endregion

        #region Execution

        /// <summary>
        /// Executes a non-result query.
        /// </summary>
        public void Execute()
        {
            SqlConnection cn = new SqlConnection(m_cnnStr);
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillCmd(cmd);

                cmd.ExecuteNonQuery();

                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Returns an IList of ItemTy who's results matches the
        /// returned rows of the query object.
        /// </summary>
        /// <typeparam name="ItemTy">The type of item to return.
        /// If this is a scalar type, then the first column is
        /// used for the value.</typeparam>
        /// <returns>A list of objects who represent each
        /// row in the result set.</returns>
        public IList<ItemTy> ExecuteList<ItemTy>()
        {
            SqlConnection cn = new SqlConnection(m_cnnStr);
            IList<ItemTy> rval = new List<ItemTy>();
            SafeDataReader dr = null;
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillCmd(cmd);

                dr = new SafeDataReader(cmd.ExecuteReader());
                

                rval = ReadList<ItemTy>(dr);

                dr.Close();
                tr.Commit();
            }
            catch
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                tr.Rollback();
                throw;
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            return rval;
        }

        /// <summary>
        /// Returns a single object that represents the first row
        /// return by the data set result.
        /// </summary>
        /// <remarks>If the ItemTy is a scalar value, then the
        /// first column of the first row is returned.</remarks>
        /// <typeparam name="ItemTy">The type of item to return.</typeparam>
        /// <returns>Returns an object that represents the first row
        /// of the query result.</returns>
        public ItemTy ExecuteSingle<ItemTy>()
        {
            SqlConnection cn = new SqlConnection(m_cnnStr);
            ItemTy rval = default(ItemTy);
            SafeDataReader dr = null;
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillCmd(cmd);

                dr = new SafeDataReader(cmd.ExecuteReader());

                rval = ReadSingle<ItemTy>(dr);

                dr.Close();
                tr.Commit();
            }
            catch
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                tr.Rollback();
                throw;
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            return rval;
        }

	/// <summary>
	/// Executes a query that returns a Name/Value pair where the
	/// first column is used as the Name (or Key) and the second column
	/// is used as the value.
	/// </summary>
	/// <typeparam name="NameTy">Type of name</typeparam>
	/// <typeparam name="ValueTy">Type of value</typeparam>
	/// <returns></returns>
	public Dictionary<NameTy, ValueTy> 
	    ExecuteNameValueDictionary<NameTy, ValueTy>()
	{
	    Dictionary<NameTy, ValueTy> rval = new Dictionary<NameTy, ValueTy>();
	    DataTable tab = ExecuteDataTable();

	    foreach (DataRow row in tab.Rows)
	    {
		NameTy key = (NameTy)row[0];
		ValueTy val = (ValueTy)row[1];

		rval[key] = val;
	    }

	    return rval;
	}

        /// <summary>
        /// Executes the query and returns a DataSet object with the
        /// results.
        /// </summary>
        /// <returns>A DataSet object with the results of the query.
        /// If the result set is empty, than an empty DataSet is
        /// returned.</returns>
        public DataSet ExecuteDataSet()
        {
            SqlConnection cn = new SqlConnection(m_cnnStr);
            DataSet rval = new DataSet();
            SafeDataReader dr = null;
            SqlTransaction tr;
            
            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillCmd(cmd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(rval);

                tr.Commit();
            }
            catch
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                tr.Rollback();
                throw;
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            return rval;
        }

        /// <summary>
        /// Executes the query and returns the results in a DataTable
        /// object.
        /// </summary>
        /// <returns>A DataTable object with the query results. An
        /// empty table is returned if there are no results.</returns>
        public DataTable ExecuteDataTable()
        {
            SqlConnection cn = new SqlConnection(m_cnnStr);
            DataTable rval = new DataTable();
            SafeDataReader dr = null;
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                FillCmd(cmd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(rval);

                tr.Commit();
            }
            catch
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                tr.Rollback();
                throw;
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            return rval;
        }

        #endregion
    }
}
