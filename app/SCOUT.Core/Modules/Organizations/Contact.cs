using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace SCOUT.Core.Data
{
    [Obsolete("Use newer Organization object")]
    public class Contact : Robot
    {
        #region Member Variables

        [NotUndoable]
        private Organization m_org;

        [NotUndoable]
        private string m_detailCache = null;

        private int m_id = 0;   // Pri Key

        private string m_name;
        private string m_email;
        private string m_phone;
        private string m_altPhone;
        private string m_fax;
        private string m_other;

        #endregion

        public Contact(Organization o)
            : base()
        {
            m_org = o;
        }

        #region Properties

        public int Id
        {
            get { return m_id; }
        }

        public Organization Organization
        {
            get { return m_org; }
        }

        public string Name
        {
            get { return m_name; }
            set
            {
                if (value != m_name)
                {
                    m_name = value.Trim();
                    MarkDirty("Name");
                }
            }
        }

        public string Email
        {
            get { return m_email; }
            set
            {
                if (value != m_email)
                {
                    m_email = value.Trim();
                    MarkDirty("Email");
                }
            }
        }

        public string Phone
        {
            get { return m_phone; }
            set
            {
                if (value != m_phone)
                {
                    m_phone = value.Trim();
                    MarkDirty("Phone");
                }
            }
        }

        public string AltPhone
        {
            get { return m_altPhone; }
            set
            {
                if (value != m_altPhone)
                {
                    m_altPhone = value.Trim();
                    MarkDirty("AltPhone");
                }
            }
        }

        public string Fax
        {
            get { return m_fax; }
            set
            {
                if (value != m_fax)
                {
                    m_fax = value.Trim();
                    MarkDirty("Fax");
                }
            }
        }

        public string Other
        {
            get { return m_other; }
            set
            {
                if (value != m_other)
                {
                    m_other = value.Trim();
                    MarkDirty("Other");
                }
            }
        }

        public string Details
        {
            get
            {
                if (IsDirty || (m_detailCache == null))
                    BuildDetailCache();

                return m_detailCache;
            }
        }

        #endregion

        protected override void ValidateRules(BrokenRules Verify)
        {
            base.ValidateRules(Verify);

            Verify.IsFalse(Name == "", "ContactNameRequired", "Name");
        }

        private void BuildDetailCache()
        {
            // Don't put lines in for empty items.
            StringBuilder sb = new StringBuilder();

            if (Email != "")
            {
                sb.Append(Email);
                sb.Append(Environment.NewLine);
            }

            if (Phone != "")
            {
                sb.Append(Phone);
                sb.Append(Environment.NewLine);
            }

            if (AltPhone != "")
            {
                sb.Append(AltPhone);
                sb.Append(Environment.NewLine);
            }

            if (Fax != "")
            {
                sb.Append(Fax);
                sb.Append(Environment.NewLine);
            }

            if (Other != "")
            {
                sb.Append(Other);
                sb.Append(Environment.NewLine);
            }

            m_detailCache = sb.ToString();
        }

        #region Data Access

        public static RobotList<Contact> GetOrganizationContacts(Organization o)
        {
            RobotList<Contact> rval = new RobotList<Contact>();
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
                cmd.CommandText = "usp_GetOrganizationContacts";

                cmd.Parameters.AddWithValue("@org_id", o.Id);

                dr = new SafeDataReader(cmd.ExecuteReader());

                while (dr.Read())
                {
                    Contact c = new Contact(o);
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
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "usp_SaveContact";

            cmd.Parameters.AddWithValue("@id", m_id);
            cmd.Parameters.AddWithValue("@org_id", m_org.Id);

            cmd.Parameters.AddWithValue("@name", m_name);
            cmd.Parameters.AddWithValue("@email", m_email);
            cmd.Parameters.AddWithValue("@phone", m_phone);
            cmd.Parameters.AddWithValue("@altphone", m_altPhone);
            cmd.Parameters.AddWithValue("@fax", m_fax);
            cmd.Parameters.AddWithValue("@other", m_other);

            BuildDetailCache();
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteContact";

            cmd.Parameters.AddWithValue("@id", m_id);
        }

        protected override void Load(SafeDataReader dr)
        {
            m_id = dr.GetInt32("id");
            // We don't load org_id
            m_name = dr.GetString("name");
            m_email = dr.GetString("email");
            m_phone = dr.GetString("phone");
            m_altPhone = dr.GetString("altphone");
            m_fax = dr.GetString("fax");
            m_other = dr.GetString("other");
        }

        #endregion

        public override string ToString()
        {
            return Details;
        }
    }
}
