using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SCOUT.Core.Data
{
    //[Obsolete("Use newer Organization object")]
    public class Organization : Robot
    {
        #region Member Variables

        private int m_id = -1;

        private string m_name;
        private string m_region = "";       
        private string m_phone;
        private string m_fax = "";
        private string m_notes = "";
        private bool m_active = true;
        private ReturnType m_defaultReturnType;

        
        private DateTime m_lastModified = DateTime.Now;
        private DateTime m_creationDate = DateTime.Now;

        private string m_updatedBy;
        private string m_createdBy;

        private RobotList<Contact> m_contacts = null;
        private RobotList<Address> m_addresses = null;
        private RobotList<OrgCustomField> m_customFields = null;

        #endregion

        public Organization()
            : base()
        {
            m_updatedBy = Security.UserSecurity.CurrentUser.Login;
            m_createdBy = Security.UserSecurity.CurrentUser.Login;
        }

        #region Properties

        public override bool IsDirty
        {
            get
            {
                bool rval = base.IsDirty;

                if (m_addresses != null)
                    rval |= m_addresses.IsDirty;

                if (m_contacts != null)
                    rval |= m_contacts.IsDirty;

                if (m_customFields != null)
                    rval |= m_customFields.IsDirty;

                return rval;
            }
        }

        public int Id
        {
            get { return m_id; }
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

        public string Region
        {
            get { return m_region; }
            set
            {
                if (value != m_region)
                {
                    m_region = value;
                    MarkDirty("Region");
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
                    m_phone = value;
                    MarkDirty("Phone");
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
                    m_fax = value;
                    MarkDirty("Fax");
                }
            }
        }

        public string Notes
        {
            get { return m_notes; }
            set
            {
                if (value != m_notes)
                {
                    m_notes = value;
                    MarkDirty("Notes");
                }
            }
        }

        public bool Active
        {
            get { return m_active; }
            set 
            {
                if (value != m_active)
                {
                    m_active = value;
                    MarkDirty("Active");
                }
            }
        }


        public ReturnType DefaultReturnType
        {
            get { return m_defaultReturnType; }
            set
            {
                if(value != m_defaultReturnType)
                {
                    m_defaultReturnType = value;
                    MarkDirty("DefaultReturnType");
                }
            }
        }

        public RobotList<Contact> Contacts
        {
            get
            {
                if (m_contacts == null)
                    LoadContacts();

                return m_contacts;
            }
        }

        public RobotList<Address> Addresses
        {
            get
            {
                if (m_addresses == null)
                    LoadAddresses();

                return m_addresses;
            }
        }

        public Address BillingAddress
        {
            get
            {
                foreach (Address a in Addresses)
                {
                    string l = a.Label.ToLower();

                    if (l.Contains("bill"))
                        return a;
                }

                return null;
            }
        }

        public Address ShippingAddress
        {
            get
            {
                foreach (Address a in Addresses)
                {
                    string l = a.Label.ToLower();

                    if (l.Contains("ship"))
                        return a;
                }

                return null;
            }
        }

        public RobotList<OrgCustomField> CustomFields
        {
            get
            {
                if (m_customFields == null)
                    LoadCustomFields();

                return m_customFields;
            }
        }

        #endregion

        #region Data Access

        public static Organization GetOrganization(int id)
        {
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            SafeDataReader dr = null;
            Organization rval = null;
            SqlTransaction tr;
            SqlCommand cmd;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetOrganization";

                cmd.Parameters.AddWithValue("@id", id);

                dr = new SafeDataReader(cmd.ExecuteReader());
                if (dr.Read())
                {
                    rval = new Organization();
                    rval.DoLoad(dr);
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

        protected static RobotList<Organization> LoadList(SafeDataReader dr)
        {
            RobotList<Organization> rval = new RobotList<Organization>();

            while (dr.Read())
            {
                Organization o = new Organization();
                o.Load(dr);
                rval.Add(o);
            }

            return rval;
        }

        public static RobotList<Organization> GetOrganizations()
        {
            RobotList<Organization> rval = new RobotList<Organization>();
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
                cmd.CommandText = "usp_GetOrganizations";

                dr = new SafeDataReader(cmd.ExecuteReader());
                rval = LoadList(dr);
                dr.Close();

                tr.Commit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
                tr.Rollback();                
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            return rval;
        }

        public static RobotList<Organization> GetActiveOrganizations()
        {
            RobotList<Organization> rval = new RobotList<Organization>();
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
                cmd.CommandText = "usp_GetActiveOrganizations";

                dr = new SafeDataReader(cmd.ExecuteReader());
                rval = LoadList(dr);

                dr.Close();
                tr.Commit();
            }
            catch(Exception ex)
            {

                tr.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            return rval;
        }

        private void LoadAddresses()
        {            
            m_addresses = Address.GetOrganizationAddresses(this);
        }

        private void LoadContacts()
        {            
            m_contacts = Contact.GetOrganizationContacts(this);
        }

        private void LoadCustomFields()
        {
            m_customFields = new RobotList<OrgCustomField>();

            //m_customFields = OrgCustomField.GetOrgCustomFields(this);
            //CustomFieldDef.AllDefs.ListChanged += AllCustomFieldDefs_ListChanged;
        }

        private void AllCustomFieldDefs_ListChanged(object sender, 
            ListChangedEventArgs e)
        {
            // If we have dirty custom fields we'll need to preserve those values.
            RobotList<OrgCustomField> mydefs = OrgCustomField.GetOrgCustomFields(this);

            foreach (OrgCustomField new_cf in mydefs)
            {
                OrgCustomField old_cf = m_customFields.Find(
                    delegate(OrgCustomField checkObj, int id)
                    {
                        return (checkObj.Def.Id == id);
                    }, new_cf.Def.Id);

                if (old_cf == null)
                    continue;

                new_cf.Value = old_cf.Value;
            }

            m_customFields = mydefs;
            NotifyPropertyChanged("CustomFields");
        }

        protected override void PostSave(SafeDataReader dr)
        {
            m_id = Int32.Parse(dr["id"].ToString());
        }

        protected override void SaveSubItems(SqlTransaction tr)
        {
            if (m_addresses != null)
                m_addresses.Save(tr.Connection, tr);

            if (m_contacts != null)
                m_contacts.Save(tr.Connection, tr);

            if (m_customFields != null)
                m_customFields.Save(tr.Connection, tr);

            base.SaveSubItems(tr);
        }

        protected override void FillSaveCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SaveOrganization";

            cmd.Parameters.AddWithValue("@id", m_id);
            cmd.Parameters.AddWithValue("@user", Security.UserSecurity.CurrentUser.Login);
            cmd.Parameters.AddWithValue("@active", m_active);
            cmd.Parameters.AddWithValue("@name", m_name);
            cmd.Parameters.AddWithValue("@region", m_region);
            cmd.Parameters.AddWithValue("@phone", m_phone);
            cmd.Parameters.AddWithValue("@fax", m_fax);
            cmd.Parameters.AddWithValue("@notes", m_notes);
            cmd.Parameters.AddWithValue("@default_return_type", m_defaultReturnType);
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteOrganization";
            cmd.Parameters.AddWithValue("@id", m_id);
            cmd.Parameters.AddWithValue("@user", Security.UserSecurity.CurrentUser.Login);
        }

        protected override void Load(SafeDataReader dr)
        {
            m_id = dr.GetInt32("id");
            m_name = dr.GetString("name");
            m_region = dr.GetString("region");
            m_phone = dr.GetString("phone");
            m_fax = dr.GetString("fax");
            m_notes = dr.GetString("notes");
            m_active = dr.GetBoolean("active");
            m_lastModified = dr.GetDateTime("lastmodified");
            m_creationDate = dr.GetDateTime("creationdate");
            m_updatedBy = dr.GetString("updatedby");
            m_createdBy = dr.GetString("createdby");
            m_defaultReturnType = (ReturnType)dr.GetInt32("default_return_type");
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return m_name;
        }

        #endregion
    }
}
