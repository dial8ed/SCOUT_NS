using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace SCOUT.Core.Data
{
    [Obsolete("Use newer Organization object")]
    public class OrgCustomField : Robot
    {
        #region Member Variables

        [NotUndoable]
        private CustomFieldDef m_def;

        [NotUndoable]
        private Organization m_org;

        private string m_value = "";

        #endregion

        public OrgCustomField(CustomFieldDef def, Organization org)
        {
            m_def = def;
            m_org = org;
        }

        #region Properties

        [Bindable(false), Browsable(false)]
        public CustomFieldDef Def
        {
            get { return m_def; }
        }

        [Bindable(false), Browsable(false)]
        public Organization Org
        {
            get { return m_org; }
        }

        [Bindable(true), Browsable(true)]
        public string Name
        {
            get { return m_def.Name; }
        }

        [Bindable(true), Browsable(true)]
        public string Value
        {
            get { return m_value; }
            set
            {
                if (m_value != value)
                {
                    m_value = value;
                    MarkDirty("Value");
                }
            }
        }

        #endregion

        #region Data Access

        public static RobotList<OrgCustomField> GetOrgCustomFields(Organization org)
        {
            RobotList<OrgCustomField> rval = new RobotList<OrgCustomField>();
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
                cmd.CommandText = "usp_GetOrgCustomFields";

                cmd.Parameters.AddWithValue("@org_id", org.Id);
                dr = new SafeDataReader(cmd.ExecuteReader());

                while (dr.Read())
                {
                    int defId = dr.GetInt32(dr.GetOrdinal("def_id"));

                    CustomFieldDef def =
                        CustomFieldDef.AllDefs.Find(CustomFieldDef.ById, defId);

                    if (def == null)
                        continue;

                    OrgCustomField cf = new OrgCustomField(def, org);

                    cf.DoLoad(dr);
                    rval.Add(cf);
                }

                dr.Close();
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
                throw;
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();

                cn.Close();
            }

            /* 
             * Make sure all the currently defined custom field definitions
             * are listed.
             */
            foreach (CustomFieldDef def in CustomFieldDef.AllDefs)
            {
                OrgCustomField cf = rval.Find(
                    delegate(OrgCustomField obj, CustomFieldDef p)
                    {
                        return (obj.Def == p);
                    }, def);

                if (cf == null)
                {
                    cf = new OrgCustomField(def, org);
                    rval.Add(cf);
                }
            }

            return rval;
        }

        protected override void FillSaveCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SaveCustomField";

            cmd.Parameters.AddWithValue("@def_id", m_def.Id);
            cmd.Parameters.AddWithValue("@org_id", m_org.Id);
            cmd.Parameters.AddWithValue("@value", m_value);
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteCustomField";

            cmd.Parameters.AddWithValue("@def_id", m_def.Id);
            cmd.Parameters.AddWithValue("@org_id", m_org.Id);
        }

        protected override void Load(SafeDataReader dr)
        {
            m_value = dr.GetString("value");

            // Def & Org are filled in by the constructor.
        }

        #endregion
    }
}
