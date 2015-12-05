using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("parameter_list_items")]
    public class ParameterListItem : VPLiteObject
    {
        private int m_id;
        private string m_item;
        private string m_userName;
        private DateTime m_dateAdded;
        private DateTime m_lastUsed;
        private ParameterList m_parameterList;

        public ParameterListItem(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("item")]
        public string Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }

        [Persistent("user_name")]
        public string UserName
        {
            get { return m_userName; }
            set { SetPropertyValue("UserName", ref m_userName, value); }
        }

        [Persistent("date_added")]
        public DateTime DateAdded
        {
            get { return m_dateAdded; }
            set { SetPropertyValue("DateAdded", ref m_dateAdded, value); }
        }

        [Persistent("last_used")]
        public DateTime LastUsed
        {
            get { return m_lastUsed; }
            set { SetPropertyValue("LastUsed", ref m_lastUsed, value); }
        }

        [Persistent("list_id")]
        [Association("ParameterList-Items")]
        public ParameterList ParameterList
        {
            get { return m_parameterList; }
            set { SetPropertyValue("ParameterList", ref m_parameterList, value); }
        }

        public override string ToString()
        {
            return m_item;
        }
    }
}