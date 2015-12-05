using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// A generic address.
    /// </summary>
    [Obsolete("Use newer Organization object")]
    public class Address : Robot
    {
        [NotUndoable]
        private Organization m_org;

        private int m_id = 0; // Pri Key       

        // Home, ShipTo, Billing, Ect.
        private string m_label = "";

        private string m_street;
        private bool m_streetOnly = false;
        private string m_city = "";
        private string m_state = "";
        private string m_countryCode = "USA";
        private string m_postalCode = "";

        [NotUndoable]
        private Country m_country;
       
        public Address(Organization o)
            : base()
        {
            m_org = o;
            UpdateCountry();
        }

        #region Utility

        private void UpdateCountry()
        {
            m_country = Country.All.Find("A3", m_countryCode);
        }

        #endregion

        #region Properties

        public int id
        {
            get { return m_id; }
        }

        public Organization Organization
        {
            get { return m_org; }
        }

        public string Label
        {
            get { return m_label; }
            set
            {
                m_label = value.Trim();
                MarkDirty("Label");
            }
        }

        public string Street
        {
            get { return m_street; }
            set
            {
                string[] lines = value.Split(new String[]
                {
                    Environment.NewLine, "\r\n", "\n", "\r"
                }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                int cnt = 0;

                // Remove all blank lines
                foreach (string line in lines)
                {
                    string l = line.Trim();

                    if (l != "")
                    {
                        if (cnt > 0)
                            sb.Append(Environment.NewLine);

                        sb.Append(l);
                        ++cnt;
                    }
                }

                m_street = sb.ToString();
                MarkDirty("Street");
            }
        }

        public bool StreetOnly
        {
            get { return m_streetOnly; }
            set
            {
                if (m_streetOnly != value)
                {
                    m_streetOnly = value;
                    MarkDirty("StreetOnly");
                }
            }
        }

        public string City
        {
            get { return m_city; }
            set 
            { 
                m_city = value.Trim();
                MarkDirty("City");
            }
        }

        public string State
        {
            get { return m_state; }
            set
            {
                m_state = value.Trim();
                MarkDirty("State");
            }
        }

        public string PostalCode
        {
            get { return m_postalCode; }
            set
            {
                m_postalCode = value.Trim();
                MarkDirty("PostalCode");
            }
        }

        public string CountryCode
        {
            get { return m_countryCode; }
            set
            {
                string s = value.ToUpper();

                if (m_countryCode.ToUpper() != s)
                {
                    Country c = Country.All.Find("A3", s);

                    if (c != null)
                    {
                        m_country = c;
                        m_countryCode = s;
                        MarkDirty("CountryCode");
                    }
                }
            }
        }

        public Country Country
        {
            get { return m_country; }
        }


        public string AddressText
        {
            get
            {
                return ToString();
            }
        }

        #endregion

        protected override void ValidateRules(BrokenRules Verify)
        {
            base.ValidateRules(Verify);

            Verify.IsNotEmpty(Label,
                "AddrLabelRequired",
                "Addresses require a label.",
                "Label");

            Verify.IsNotEmpty(Street,
                "AddrLineRequired",
                "No street information on address.",
                "Street");

            Verify.IsNotEmpty(City,
                "AddrCityRequired", 
                "Address city is required.",
                "City");

            //Verify.IsNotEmpty(State,
            //    "AddrStateRequired",
            //    "Address state/provence is required.",
            //    "State");

            Verify.IsNotNull(Country, 
                "AddrCountryRequired", 
                "Address country is required.",
                "Country");
        }

        #region Data Access

        public static RobotList<Address> GetOrganizationAddresses(Organization o)
        {
            RobotList<Address> rval = new RobotList<Address>();
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
                cmd.CommandText = "usp_GetOrganizationAddresses";

                cmd.Parameters.AddWithValue("@org_id", o.Id);

                dr = new SafeDataReader(cmd.ExecuteReader());

                while (dr.Read())
                {
                    Address a = new Address(o);
                    a.DoLoad(dr);
                    rval.Add(a);
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
            cmd.CommandText = "usp_SaveAddress";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@org_id", m_org.Id);
            cmd.Parameters.AddWithValue("@label", Label);
            cmd.Parameters.AddWithValue("@street", Street);
            cmd.Parameters.AddWithValue("@street_only", StreetOnly);
            cmd.Parameters.AddWithValue("@city", City);
            cmd.Parameters.AddWithValue("@state", State);
            cmd.Parameters.AddWithValue("@postal_code", PostalCode);
            cmd.Parameters.AddWithValue("@country", Country.A3);
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteAddress";

            cmd.Parameters.AddWithValue("@id", id);
        }

        protected override void Load(SafeDataReader dr)
        {
            // We don't load the org's ID.

            m_id = dr.GetInt32("id");
            m_label = dr.GetString("label");
            m_street = dr.GetString("street");
            m_streetOnly = dr.GetBoolean("street_only");
            m_city = dr.GetString("city");
            m_state = dr.GetString("state");
            m_postalCode = dr.GetString("postal_code");
            m_countryCode = dr.GetString("country").ToUpper();

            UpdateCountry();
        }

        #endregion

        public override string ToString()
        {
            StringBuilder fmt = new StringBuilder();

            fmt.Append("{0}");

            if (!m_streetOnly)
            {
                fmt.Append(Environment.NewLine);

                if (Country.PCSide.ToUpper() == "R")
                    fmt.Append("{1} {2}, {3}");
                else
                    fmt.Append("{3}, {1} {2}");

                fmt.Append(Environment.NewLine);
                fmt.Append("{4}");
            }

            return String.Format(fmt.ToString(),
                Street, City, State, PostalCode, Country);
        }
    }
}
