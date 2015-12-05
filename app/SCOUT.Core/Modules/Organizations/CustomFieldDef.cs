using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;


namespace SCOUT.Core.Data
{
    [Obsolete("Use newer Organization object")]
    public class CustomFieldDef : Robot
    {
        #region Member Variables

        private static RobotList<CustomFieldDef> s_allDefs = null;

        private int m_id = 0;
        private string m_name;

        #endregion

        #region Properties

        [Browsable(false), Bindable(false)]
        public int Id
        {
            get { return m_id; }
        }

        [Browsable(true), Bindable(true)]
        public string Name
        {
            get { return m_name; }
            set
            {
                if (m_name != value)
                {
                    m_name = value;
                    MarkDirty("Name");
                }
            }
        }

        public static RobotList<CustomFieldDef> AllDefs
        {
            get
            {
                if (s_allDefs == null)
                {
                    s_allDefs = new RobotList<CustomFieldDef>();
                    s_allDefs.Load("usp_GetCustomFieldDefs", 
                        CommandType.StoredProcedure);
                }

                return s_allDefs;
            }
        }

        #endregion

        #region Misc

        public static bool ById(CustomFieldDef def, int id)
        {
            return (def.Id == id);
        }

        #endregion

        #region Data Access

        protected override void FillSaveCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SaveCustomFieldDef";

            cmd.Parameters.AddWithValue("@id", m_id);
            cmd.Parameters.AddWithValue("@name", m_name);
        }

        protected override void PostSave(SafeDataReader dr)
        {
            m_id = dr.GetInt32(dr.GetOrdinal("id"));
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_DeleteCustomFieldDef";

            cmd.Parameters.AddWithValue("@id", m_id);
        }

        protected override void Load(SafeDataReader dr)
        {
            m_id = dr.GetInt32("id");
            m_name = dr.GetString("name");
        }

        #endregion
    }
}
