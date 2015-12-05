using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SCOUT.Core.Data
{
    internal interface IRobotList
    {
        void SaveState();
        void RestoreSavedState();
        void CancelSavedState();
    }

    public interface IOwnedItem<ParentTy>
        where ParentTy : Robot
    {
        ParentTy Parent { get; }
    }

    internal class PropertyComparer<ItemTy> : IComparer<ItemTy>
        where ItemTy : Robot
    {
        private PropertyInfo m_propInfo;
        private ListSortDirection m_dir;

        public PropertyComparer(PropertyDescriptor prop, ListSortDirection dir)
        {
            Type ty = typeof(ItemTy);

            m_propInfo = ty.GetProperty(prop.Name);

            if (m_propInfo == null)
            {
                string msg = String.Format("Property {0} not found on type {1}",
                    prop.Name, ty.FullName);

                throw new ArgumentException(msg, "prop");
            }

            m_dir = dir;
        }

        #region IComparer<ItemTy> Members

        public int Compare(ItemTy x, ItemTy y)
        {
            object lhs = m_propInfo.GetValue(x, null);
            object rhs = m_propInfo.GetValue(y, null);

            if (m_dir == ListSortDirection.Ascending)
                return Comparer.Default.Compare(lhs, rhs);
            else
                return Comparer.Default.Compare(rhs, lhs);
        }

        #endregion
    }

    [Obsolete("Use XPCollection")]
    public class RobotList<ItemTy> : BindingList<ItemTy>, IRobotList
        where ItemTy : Robot
    {
        protected List<Robot> m_delList = new List<Robot>();
        private string m_cnnStrConfigVal = null;
        private bool m_isSorted = false;

        #region Constructors

        public RobotList()
        {
        }

        public RobotList(IList<ItemTy> list)
            : base(list)
        {
        }

        #endregion

        #region Sorting

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return m_isSorted; }
        }

        protected override void ApplySortCore(
            PropertyDescriptor prop, 
            ListSortDirection dir)
        {
            //List<ItemTy> items = Items as List<ItemTy>;

            //if (items != null)
            //{
            //    PropertyComparer<ItemTy> pc =
            //        new PropertyComparer<ItemTy>(prop, dir);

            //    items.Sort(pc);
            //    m_isSorted = true;
            //}
            //else
            //    m_isSorted = false;

            //OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        public void ApplySort(string propName, ListSortDirection dir)
        {
            //PropertyDescriptor pd = 
            //    TypeDescriptor.GetProperties(typeof(ItemTy))[propName];
            //ApplySort(pd, dir);
        }

        public void ApplySort(PropertyDescriptor prop, ListSortDirection dir)
        {
            //ApplySortCore(prop, dir);
        }

        protected override void RemoveSortCore()
        {
            m_isSorted = false;
        }

        #endregion

        #region Searching

        public delegate bool FindDelegate<ParamTy> (ItemTy obj, ParamTy p);

        /// <summary>
        /// Returns the first matching item identified by the find delegate.
        /// </summary>
        /// <typeparam name="ParamTy">Parameter type</typeparam>
        /// <param name="func">Delegate that should be called to chec
        /// for a matching object.</param>
        /// <param name="p">Parameter to the find delegate.</param>
        /// <returns>Returns the first matching item, or null
        /// if no item found.</returns>
        public ItemTy Find<ParamTy>(FindDelegate<ParamTy> func, ParamTy p)
        {
            foreach (ItemTy i in this)
            {
                if (func(i, p))
                    return i;
            }

            return null;
        }

        public ItemTy Find<ParamTy>(string PropName, ParamTy p)
        {
            Type t = typeof(ItemTy);
            PropertyInfo pi = t.GetProperty(PropName);

            if (pi == null)
                throw new Exception("Invalid property name: " + PropName);

            if (pi.PropertyType.IsArray)
            {
                string msg = String.Format("Property {0} is an array type.",
                    PropName);
                throw new Exception(msg);
            }

            if (pi.PropertyType != typeof(ParamTy))
            {
                throw new Exception("Property not of type: " +
                    typeof(ParamTy).Name);
            }

            foreach (ItemTy i in this)
            {
                ParamTy objVal = (ParamTy)pi.GetValue(i, null);

                if (objVal.Equals(p))
                    return i;
            }

            return null;
        }

        public RobotList<ItemTy> FindAll<ParamTy>(FindDelegate<ParamTy> func, ParamTy p)
        {
            RobotList<ItemTy> rval = new RobotList<ItemTy>();

            foreach (ItemTy i in this)
            {
                if (func(i, p))
                    rval.Add(i);
            }

            return rval;
        }

        public RobotList<ItemTy> FindAll<ParamTy>(string PropName, ParamTy p)
        {
            RobotList<ItemTy> rval = new RobotList<ItemTy>();
            Type t = typeof(ItemTy);
            PropertyInfo pi = t.GetProperty(PropName);

            if (pi == null)
                throw new Exception("Invalid property name: " + PropName);

            if (pi.PropertyType.IsArray)
            {
                string msg = String.Format("Property {0} is an array type.",
                    PropName);
                throw new Exception(msg);
            }

            if (pi.PropertyType != typeof(ParamTy))
            {
                throw new Exception("Property not of type: " +
                    typeof(ParamTy).Name);
            }

            foreach (ItemTy i in this)
            {
                ParamTy objVal = (ParamTy)pi.GetValue(i, null);

                if (objVal.Equals(p))
                    rval.Add(i);
            }

            return rval;
        }

        #endregion

        #region State Saving

        void IRobotList.SaveState()
        {
            foreach (ItemTy obj in this)
                obj.SaveState();
        }

        void IRobotList.RestoreSavedState()
        {
            foreach (ItemTy obj in this)
                obj.RestoreSavedState();
        }

        void IRobotList.CancelSavedState()
        {
            foreach (ItemTy obj in this)
                obj.CancelSavedState();
        }

        #endregion

        #region Dirty Flag

        //private bool m_isDirty = false;

        public bool IsDirty
        {
            get
            {
                bool rval = false;

                foreach (ItemTy obj in this)
                {
                    rval |= obj.IsDirty;
                    if (rval)
                        break;
                }
                
                return rval;
            }
        }

        internal void MarkDirty()
        {
            //m_isDirty = true;
        }

        // Had to make this public..... -- BSimonds (3/3/2008)
        public void MarkClean()
        {
            //m_isDirty = false;
            m_delList.Clear();
        }

        #endregion

        #region Overrides

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            MarkDirty();
            base.OnListChanged(e);
        }

        protected override void RemoveItem(int index)
        {
            ItemTy obj = this[index];
            m_delList.Add(obj);

            base.RemoveItem(index);
        }

        #endregion

        #region List Editting Notification

        public void BeginEdit()
        {
            IRobotList irl = this; // C# is retarted.
            irl.SaveState();
        }

        public void EndEdit()
        {
            IRobotList irl = this; // C# is retarted.
            irl.CancelSavedState();
        }

        public void CancelEdit()
        {
            IRobotList irl = this; // C# is retarted.
            irl.RestoreSavedState();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// C# generics are crazy in that for some reason you have to define a new()
        /// keyword if you want to be able to create an object of the defined type.
        /// 
        /// In all reality there shouldn't be a need for this pointless use of the
        /// keyword, esp if we clue it into the type we're expecting with the 
        /// "where" keyword.....
        /// 
        /// This also prevents us from creating objects that need to have parameters 
        /// in their constructors.  For some reason Microsoft seems to think that we 
        /// should always define a parameterless constructor, and this just isn't 
        /// always a good idea.
        /// 
        /// What's even more annoying is that we may not WANT the BindingList to
        /// automagically create items for us!
        /// </summary>
        /// <returns></returns>
        private static ItemTy CreateNewItem(params object[] args)
        {
            //Type mainType = typeof(ItemTy);
            //Type ownedType = mainType.GetInterface("IOwnedItem");
            ItemTy rval = null;

            //if (ownedType != null)
            //    rval = Activator.CreateInstance(ownedType, m_parent, args) as ItemType;
            //else
                rval = Activator.CreateInstance(typeof(ItemTy), args) as ItemTy;

            return rval;
        }

        #endregion

        #region Database Interface

        /// <summary>
        /// Gets the base object's connection string.
        /// </summary>
        private string CnnStr
        {
            get
            {
                if ((m_cnnStrConfigVal == null) || (m_cnnStrConfigVal == ""))
                {
                    m_cnnStrConfigVal = "DB:SCOUT"; // The default.

                    Type t = typeof(ItemTy);
                    object[] attribs;

                    attribs = t.GetCustomAttributes(
                        typeof(DBAttribute), true);

                    foreach (DBAttribute a in attribs)
                        m_cnnStrConfigVal = a.ConfigVal;
                }

                return Helpers.Config[m_cnnStrConfigVal];
            }
        }

        /// <summary>
        /// Loads a list from the given SQL command text and type.
        /// </summary>
        /// <param name="CommandText">String with the SQL command to execute.</param>
        /// <param name="CommandType">The type of SQL command to execute.</param>
        public void Load(string CommandText, CommandType CommandType)
        {
            SqlConnection cn = new SqlConnection(CnnStr);
            SqlTransaction tr;
            SqlCommand cmd;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                cmd.CommandText = CommandText;
                cmd.CommandType = CommandType;

                SafeDataReader dr = new SafeDataReader(cmd.ExecuteReader());

                Load(dr);

                dr.Close();
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

        /// <summary>
        /// Loads a list from a data reader.
        /// </summary>
        /// <param name="dr"></param>
        public void Load(SafeDataReader dr)
        {
            Clear();

            while (dr.Read())
            {
                ItemTy item = CreateNewItem();
                item.DoLoad(dr);
                Add(item);
            }

            //m_isDirty = false;
        }

        /// <summary>
        /// Loads the list from a query object.
        /// </summary>
        /// <param name="q"></param>
        public void LoadFromQuery(Query q)
        {
            Clear();

            IList<ItemTy> res = q.ExecuteList<ItemTy>();

            foreach (ItemTy item in res)
                Add(item);

            MarkClean();
        }

        /// <summary>
        /// Saves the list to persistant storage, using a given
        /// SQL connection and transaction.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        public void Save(SqlConnection cn, SqlTransaction tr)
        {
            //if (!IsDirty)
            //    return;

            foreach (ItemTy item in m_delList)
                item.Delete(tr);

            foreach (ItemTy item in Items)
                item.Save(tr);

            MarkClean();
        }

        /// <summary>
        /// Saves the list to persistant storage.
        /// </summary>
        public void Save()
        {
            SqlConnection cn = new SqlConnection(CnnStr);
            SqlTransaction tr;

            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                Save(cn, tr);
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
        /// Deletes the list from persistant storage, using a given
        /// SQL connection and transaction.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="tr"></param>
        public void Delete(SqlConnection cn, SqlTransaction tr)
        {
            foreach (ItemTy item in m_delList)
                item.Delete(tr);

            m_delList.Clear();

            foreach (ItemTy item in this)
                item.Delete(tr);

            Clear();
            m_delList.Clear();
            MarkClean();
        }

        /// <summary>
        /// Deletes the object from persistant storage.
        /// </summary>
        public void Delete()
        {
            SqlConnection cn = new SqlConnection(CnnStr);
            SqlTransaction tr =
                cn.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                Delete(cn, tr);
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

        #endregion

        
    }
}
