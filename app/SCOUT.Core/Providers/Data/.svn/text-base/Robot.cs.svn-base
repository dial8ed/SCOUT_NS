using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SCOUT.Core.Data
{
	/// <summary>
	/// RoBOT - RObust Business Object Type
	/// 
	/// Basic business object.
	/// </summary>
	[Obsolete("Use VPObject")]
	public abstract class Robot : RobotBase,
        IEditableObject,  INotifyPropertyChanged, ILoadable
	{
        #region Member Variables

        /// <summary>
        /// The config value with the connection string.
        /// </summary>
	    [NotUndoable]
        private string m_cnnStrConfigVal = null;

        /// <summary>
        /// Dirty flag
        /// </summary>
        private bool m_isDirty = true;

        /// <summary>
        /// New flag
        /// </summary>
        [NotUndoable]
	    private bool m_isNew = true;

        /// <summary>
        /// Undo stack.
        /// </summary>
        [NotUndoable]
        private readonly Stack<Dictionary<string, object>> m_stateStack =
            new Stack<Dictionary<string, object>>();

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Dirty Flag

        /// <summary>
        /// Returns true if the object has been modified and should
        /// be saved back to persistant storage again.
        /// </summary>
        [NotSaved, Bindable(true), Browsable(false)]
        public virtual bool IsDirty
        {
            get { return m_isDirty; }
        }

	    [NotSaved, Bindable(true), Browsable(false)]
	    public virtual bool IsNew
	    {
            get { return m_isNew; }
	    }

        /// <summary>
        /// Marks the object as dirty.
        /// </summary>
        [Obsolete("Please specify the changed property name.")]
        protected void MarkDirty()
        {
            MarkDirty("");
        }

        protected void MarkDirty(string propName)
        {
            m_isDirty = true;
            NotifyPropertyChanged(propName);
        }

        protected void NotifyPropertyChanged(string propName)
        {
            if ((propName == null) || (propName == ""))
                return;

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Marks the object as clean (saved).
        /// </summary>
        protected void MarkClean()
        {
            m_isDirty = false; 
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Gets the connection string for a particular object.
        /// 
        /// If the object defines DBSecurity then the connection string for
        /// the security database is returned.
        /// </summary>
	    private string CnnStr
        {
            get
            {
                if ((m_cnnStrConfigVal == null) || (m_cnnStrConfigVal == ""))
                {
                    m_cnnStrConfigVal = "DB:SCOUT"; // The default
                    Type t = GetType();
                    object[] attribs;
                    
                    attribs = t.GetCustomAttributes(
                        typeof(DBAttribute), true);

                    foreach (DBAttribute a in attribs)
                        m_cnnStrConfigVal = a.ConfigVal;
                }

                return Helpers.Config[m_cnnStrConfigVal];
            }
        }

        /*
         * TODO: Data access should be removed from the business objects.
         */

        #region Protected Virtual Methods

        /// <summary>
        /// Called to save any sub items or collections to
        /// persistant storage.
        /// </summary>
        /// <param name="tr"></param>
        protected virtual void SaveSubItems(SqlTransaction tr)
        {
        }

        /// <summary>
        /// Called to delete any sub items or collections 
        /// from persistant storage.
        /// </summary>
        /// <param name="tr"></param>
        protected virtual void DeleteSubItems(SqlTransaction tr)
        {
        }

        /// <summary>
        /// Fills an SQL command with the needed information
        /// to save the object.
        /// </summary>
        /// <param name="cmd"></param>
        protected abstract void FillSaveCmd  (SqlCommand cmd);

        /// <summary>
        /// Fills an SQL command with the needed information
        /// to delete the object.
        /// </summary>
        /// <param name="cmd"></param>
        protected abstract void FillDeleteCmd(SqlCommand cmd);

        /// <summary>
        /// Fills in the data from a data reader.
        /// </summary>
        /// <param name="dr"></param>
        protected abstract void Load(SafeDataReader dr);

        public void DoLoad(SafeDataReader dr)
        {
            Load(dr);

            m_isDirty = false;
            m_isNew = false;
        }

        protected virtual void PostSave(SafeDataReader dr)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the object to persistant storage, using a given
        /// SQL connection and transaction.
        /// </summary>
        /// <param name="tr"></param>
        public void Save(SqlTransaction tr)
        {
            SafeDataReader dr = null;

            if (!IsDirty)
                return;

            List<BrokenRule> rulesBroken = GetBrokenRules();
            if (rulesBroken.Count > 0)
                throw new BrokenRuleException(this, rulesBroken);

            try
            {
                SqlCommand cmd = tr.Connection.CreateCommand();
                cmd.Transaction = tr;

                FillSaveCmd(cmd);

                dr = new SafeDataReader(cmd.ExecuteReader());
                if (dr.Read())
                    PostSave(dr);
            }
            finally
            {
                if ((dr != null) && !dr.IsClosed)
                    dr.Close();
            }

            SaveSubItems(tr);
            MarkClean();
            m_isNew = false;
        }

        /// <summary>
        /// Saves the object to persistant storage.
        /// </summary>
        public void Save()
        {
            SqlConnection cn = new SqlConnection(CnnStr);
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                Save(tr);
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
        /// Deletes the object from persistant storage, using a given
        /// SQL connection and transaction.
        /// </summary>
        /// <param name="tr"></param>
        public void Delete(SqlTransaction tr)
        {
            DeleteSubItems(tr);

            SqlCommand cmd = tr.Connection.CreateCommand();
            cmd.Transaction = tr;

            FillDeleteCmd(cmd);

            cmd.ExecuteNonQuery();
        }        

        /// <summary>
        /// Deletes the object from persistant storage.
        /// </summary>
        public void Delete()
        {
            SqlConnection cn = new SqlConnection(CnnStr);
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                Delete(tr);
                tr.Commit();
            }
            catch
            {
                tr.Rollback();
            }
            finally
            {
                cn.Close();
            }
        }

        #endregion

        #endregion

        #region IEditableObject Members

        #region Undo Base

        static private bool IsNotUndoableField(MemberInfo field)
        {
            return Attribute.IsDefined(field, typeof(NotUndoableAttribute));
        }

        internal void SaveState()
        {
            Dictionary<string, object> state = new Dictionary<string, object>();
            Type ct;

            for (ct = GetType(); ct != typeof(Robot); ct = ct.BaseType)
            {
                FieldInfo[] fields = ct.GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    if (field.DeclaringType != ct)
                        continue;

                    if (IsNotUndoableField(field))
                        continue;

                    object value = field.GetValue(this);
                    if (field.FieldType.IsSubclassOf(typeof(Robot)))
                    {
                        Robot robo = value as Robot;

                        if (robo != null)
                            robo.SaveState();
                    }
                    else if (field.FieldType.IsSubclassOf(typeof(IRobotList)))
                    {
                        IRobotList rl = value as IRobotList;

                        if (rl != null)
                            rl.SaveState();
                    }
                    else
                    {
                        string name = ct.Name + "!" + field.Name;
                        state[name] = value;
                    }
                }
            }

            m_stateStack.Push(state);
        }

        internal void CancelSavedState()
        {
            if (m_stateStack.Count == 0)
                return;

            Dictionary<string, object> state = m_stateStack.Pop();
            Type ct;

            for (ct = GetType(); ct != typeof(Robot); ct = ct.BaseType)
            {
                FieldInfo[] fields = ct.GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    if (field.DeclaringType != ct)
                        continue;

                    if (IsNotUndoableField(field))
                        continue;

                    string name = ct.Name + "!" + field.Name;

                    if (field.GetType().IsSubclassOf(typeof(Robot)))
                    {
                        Robot robo = (Robot)state[name];
                        robo.CancelSavedState();
                    }
                    else if (field.GetType().IsSubclassOf(typeof(IRobotList)))
                    {
                        IRobotList rl = (IRobotList)state[name];
                        rl.CancelSavedState();
                    }
                }
            }
        }

        internal void RestoreSavedState()
        {
            if (m_stateStack.Count == 0)
                return;

            Dictionary<string, object> state = m_stateStack.Pop();
            Type ct;

            for (ct = GetType(); ct != typeof(Robot); ct = ct.BaseType)
            {
                FieldInfo[] fields = ct.GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Public |
                    BindingFlags.Instance);

                foreach (FieldInfo field in fields)
                {
                    if (field.DeclaringType != ct)
                        continue;

                    if (IsNotUndoableField(field))
                        continue;

                    string name = ct.Name + "!" + field.Name;

                    if (!state.ContainsKey(name))
                        continue;

                    if (field.GetType().IsSubclassOf(typeof(Robot)))
                    {
                        Robot robo = (Robot)state[name];
                        robo.RestoreSavedState();
                    }
                    else if (field.GetType().IsSubclassOf(typeof(IRobotList)))
                    {
                        IRobotList rl = (IRobotList)state[name];
                        rl.RestoreSavedState();
                    }
                    else
                        field.SetValue(this, state[name]);
                }
            }
        }

        #endregion

        [Obsolete("Undo states handled automatically")]
        virtual public void EndEdit()
        {
            CancelSavedState();
        }

        //[Obsolete("Undo states handled automatically")]
        virtual public void CancelEdit()
        {
            RestoreSavedState();
        }

        [Obsolete("Undo states handled automatically")]
        virtual public void BeginEdit()
        {
            SaveState();
        }

        #endregion
    }
}
