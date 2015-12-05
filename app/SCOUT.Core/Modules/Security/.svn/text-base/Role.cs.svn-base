using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using SCOUT.Core.Data;

namespace SCOUT.Core.Security
{
    public partial class UserSecurity
    {
        [SecurityDB]
        public class Role : Robot
        {
            public const int AdminRoleId = 0;

            #region Private Classes

            class ActionList : BindingList<Action>
            {
                internal Role m_parent = null;
                internal bool m_isDirty = false;

                private readonly List<Action> m_delList = new List<Action>();

                protected override void OnListChanged(ListChangedEventArgs e)
                {
                    m_isDirty = true;
                    base.OnListChanged(e);
                }

                protected override void RemoveItem(int index)
                {
                    m_delList.Add(this[index]);
                    m_isDirty = true;

                    base.RemoveItem(index);
                }

                public bool IsDirty { get { return m_isDirty; } }

                public void Save(SqlTransaction tr)
                {
                    SqlCommand cmd;

                    // Remove old role actions.
                    foreach (Action a in m_delList)
                    {
                        cmd = tr.Connection.CreateCommand();
                        cmd.Transaction = tr;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_DeleteRoleAction";
                        
                        cmd.Parameters.AddWithValue("@RoleId", m_parent.Id);
                        cmd.Parameters.AddWithValue("@ActionId", (int)a);

                        cmd.ExecuteNonQuery();
                    }

                    // Add new role actions.
                    foreach (Action a in this)
                    {
                        cmd = tr.Connection.CreateCommand();
                        cmd.Transaction = tr;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_SaveRoleAction";

                        cmd.Parameters.AddWithValue("@RoleId", m_parent.Id);
                        cmd.Parameters.AddWithValue("@ActionId", (int)a);

                        cmd.ExecuteNonQuery();
                    }

                    m_isDirty = false;
                }
            }

            #endregion

            #region Member Variables

            private int m_id = -1;

            private string m_name = "";
            private ActionList m_actions = null;

            #endregion

            #region Constructors

            public Role()
            {
            }

            #endregion

            #region Static Methods

            static public bool ById(Role r, int id)
            {
                return (r.Id == id);
            }

            #endregion

            #region Properties

            public int Id
            {
                get { return m_id; }
                internal set { m_id = value; }
            }

            [Bindable(true), Browsable(true)]
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

            public BindingList<Action> Actions
            {
                get
                {
                    LoadActions();
                    return m_actions;
                }
            }

            public override bool IsDirty
            {
                get
                {
                    bool rval = base.IsDirty;

                    if (!rval && (m_actions != null))
                        rval = m_actions.IsDirty;

                    return rval;
                }
            }

            #endregion

            #region Helpers

            private void LoadActions()
            {
                if (m_actions != null)
                    return;

                m_actions = new ActionList();
                m_actions.m_parent = this;

                // Load action list for non-administrator roles
                if (m_id != 0)
                {
                    Query q = new StoredProc("usp_GetRoleActions");
                    q.CnnStr = Helpers.Config["DB:Security"];
                    q.Parameters.AddWithValue("@RoleId", m_id);
                    IList<int> l = q.ExecuteList<int>();

                    foreach (int i in l)
                    {
                        foreach (Action a in UserSecurity.Actions)
                        {
                            if (a.Value == i)
                            {
                                m_actions.Add(a);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Action a in UserSecurity.Actions)
                        m_actions.Add(a);
                }

                m_actions.m_isDirty = false;
            }

            public bool CanPerform(Action Action)
            {
                return Actions.Contains(Action);
            }

            #endregion

            #region Robot Overrides

            protected override void SaveSubItems(SqlTransaction tr)
            {
                base.SaveSubItems(tr);

                if (m_actions != null)
                    m_actions.Save(tr);
            }

            protected override void FillSaveCmd(SqlCommand cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SaveRole";

                cmd.Parameters.AddWithValue("@ROLEID", m_id);
                cmd.Parameters.AddWithValue("@NAME", m_name);
            }

            protected override void FillDeleteCmd(SqlCommand cmd)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteRole";

                cmd.Parameters.AddWithValue("@ROLEID", m_id);
            }

            protected override void Load(SafeDataReader dr)
            {
                m_id = dr.GetInt32("Id");
                m_name = dr.GetString("Role");
            }

            #endregion
        }

        #region Role List

        static private RobotList<Role> s_roles = null;

        static public RobotList<Role> Roles
        {
            get
            {
                if (s_roles == null)
                {
                    s_roles = new RobotList<Role>();
                    s_roles.Load("usp_GetRoles", CommandType.StoredProcedure);
                    s_roles.ApplySort("Name", ListSortDirection.Ascending);
                }

                return s_roles;
            }
        }

        #endregion
    }
}