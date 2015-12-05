using System;
using System.Data;
using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    public class Country : Robot
    {
        private string m_a3;        // ISO 3 digit code and primary key

        private string m_name;      // Name of the country
        private string m_prov;      // US state abbr. if a provence of the US.
        private string m_pcMask;    // Postal code mask
        private string m_pcSide;    // Side the postal code appears on.

        [NotUndoable]
        static private RobotList<Country> s_allCountries = null;

        protected Country()
            : base()
        {
        }

        #region Properties

        static public RobotList<Country> All
        {
            get
            {
                if (s_allCountries == null)
                    s_allCountries = GetCountries();

                return s_allCountries;
            }
        }

        public string A3
        {
            get { return m_a3; }
        }

        public string Name
        {
            get { return m_name; }
            set
            {
                if (value != m_name)
                {
                    m_name = value;
                    MarkDirty("Name");
                }
            }
        }

        public string Prov
        {
            get { return m_prov; }
            set
            {
                if (m_prov != value)
                {
                    m_prov = value;
                    MarkDirty("Prov");
                }
            }
        }

        public string PCMask
        {
            get { return m_pcMask; }
            set
            {
                if (m_pcMask != value)
                {
                    m_pcMask = value;
                    MarkDirty("PCMask");
                }
            }
        }

        public string PCSide
        {
            get { return m_pcSide; }
            set
            {
                if (m_pcSide != value)
                {
                    m_pcSide = value;
                    MarkDirty("PCSide");
                }
            }
        }

        #endregion

        #region Data Access

        private static RobotList<Country> GetCountries()
        {
            RobotList<Country> rval = new RobotList<Country>();
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            SafeDataReader dr = null;
            SqlTransaction tr;
            SqlCommand cmd;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetCountryList";

                dr = new SafeDataReader(cmd.ExecuteReader());

                while (dr.Read())
                {
                    Country c = new Country();
                    c.DoLoad(dr);
                    rval.Add(c);
                }

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

        protected override void FillSaveCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SaveCountry";

            cmd.Parameters.AddWithValue("@a3"     , m_a3    );
            cmd.Parameters.AddWithValue("@name"   , m_name  );
            cmd.Parameters.AddWithValue("@prov"   , m_prov  );
            cmd.Parameters.AddWithValue("@pc_mask", m_pcMask);
            cmd.Parameters.AddWithValue("@pc_side", m_pcSide);
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteCountry";

            cmd.Parameters.AddWithValue("@a3", m_a3);
        }

        protected override void Load(SafeDataReader dr)
        {
            m_a3     = dr.GetString("a3"     );
            m_name   = dr.GetString("name"   );
            m_prov   = dr.GetString("prov"   );
            m_pcMask = dr.GetString("pc_mask");
            m_pcSide = dr.GetString("pc_side");
        }

        #endregion

        #region Base Overrides

        public override string ToString()
        {
            return m_a3;
        }

        public override int GetHashCode()
        {
            return m_a3.ToUpper().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Country a = obj as Country;
            String rhs_a3 = null;

            if (a == null)
                rhs_a3 = obj as String;
            else
                rhs_a3 = a.A3;

            if (rhs_a3 == null)
                return false;

            return m_a3.ToUpper() == rhs_a3.ToUpper();
        }

        #endregion
    }
}
