using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SCOUT.Core.Data
{
    public class ProcSearch
    {
        private readonly string m_name;
        private readonly Dictionary<string, ProcSearchParam> m_params;
       
        public ProcSearch(string Name)
        {
            m_name = Name;
            m_params = new Dictionary<string, ProcSearchParam>();

            LoadParameters();
        }

        public string Name
        {
            get { return m_name; }
        }

        public IDictionary<string, ProcSearchParam> Params
        {
            get { return m_params; }
        }

        /// <summary>
        /// Gets the parameters for the named stored proc and fills
        /// the m_params list with the details of that parameter.
        /// </summary>
        private void LoadParameters()
        {
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            IDataReader dr = null;

            cn.Open();

            try
            {
                SqlCommand cmd = cn.CreateCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT " +
                    "PARAMETER_NAME AS name, " +
                    "DATA_TYPE AS type, " +
                    "CHARACTER_MAXIMUM_LENGTH AS max_length " +
                    "FROM INFORMATION_SCHEMA.PARAMETERS " +
                    "WHERE SPECIFIC_NAME = @name";

                cmd.Prepare();
                cmd.Parameters.AddWithValue("@name", Name);

                dr = new SafeDataReader(cmd.ExecuteReader());

                while (dr.Read())
                {
                    ProcSearchParam p = new ProcSearchParam(dr);
                    m_params.Add(p.Name, p);
                }

            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }
        }

        /// <summary>
        /// Executes a search using the named stored proc and parameters.
        /// </summary>
        /// <returns></returns>
        public DataTable Execute()
        {
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            DataTable rval = new DataTable();

            cn.Open();

            try
            {
                SqlCommand cmd = cn.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = Name;

                IDictionaryEnumerator e = m_params.GetEnumerator();
                while (e.MoveNext())
                {
                    string k = (string)e.Key;
                    ProcSearchParam p = (ProcSearchParam)e.Value;

                    if (p.Value != null)
                        cmd.Parameters.AddWithValue(k, p.Value);
                    else
                        cmd.Parameters.AddWithValue(k, DBNull.Value);
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(rval);
            }    
            finally
            {
                cn.Close();
            }

            return rval;
        }       
    }

    public class ProcSearchParam
    {
        private readonly string m_name;
        private readonly string m_type;

        private readonly int m_maxLength = 32767;

        private object m_value = null;

        internal ProcSearchParam(IDataReader dr)
        {
            m_name = dr.GetString(dr.GetOrdinal("name"));
            m_type = dr.GetString(dr.GetOrdinal("type"));

            int i = dr.GetOrdinal("max_length");
            if (!dr.IsDBNull(i))
                m_maxLength = dr.GetInt32(i);
        }

        public string Name
        {
            get { return m_name; }
        }

        public string Type
        {
            get { return m_type; }
        }

        public int MaxLength
        {
            get { return m_maxLength; }
        }

        public object Value
        {
            get { return m_value; }
            set { m_value = value; }
        }
    }
}
