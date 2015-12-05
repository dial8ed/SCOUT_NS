using System;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("user_queries")]
    public class UserQuery : VPLiteObject
    {
        private int m_id;
        private string m_name;
        private string m_userName;
        private string m_params;
        private string m_filter;
        private string m_pivotGridLayout;
        private string m_dataGridLayout;
        private bool m_shared;
        private string m_searchObjectType;
        private string m_sprocName;

        public UserQuery(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        [Persistent("user_name")]
        public string UserName
        {
            get { return m_userName; }
            set { SetPropertyValue("UserName", ref m_userName, value); }
        }

        [Persistent("params")]
        [Size(SizeAttribute.Unlimited)]
        public string Params
        {
            get { return m_params; }
            set { SetPropertyValue("Params", ref m_params, value); }
        }

        [Persistent("filter")]
        [Size(SizeAttribute.Unlimited)]
        public string Filter
        {
            get { return m_filter; }
            set { SetPropertyValue("Filter", ref m_filter, value); }
        }

        [Persistent("pivot_grid_layout")]
        [Size(SizeAttribute.Unlimited)]
        public string PivotGridLayout
        {
            get { return m_pivotGridLayout; }
            set { SetPropertyValue("PivotGridLayout", ref m_pivotGridLayout, value); }
        }

        [Persistent("data_grid_layout")]
        [Size(SizeAttribute.Unlimited)]
        public string DataGridLayout
        {
            get { return m_dataGridLayout; }
            set { SetPropertyValue("DataGridLayout", ref m_dataGridLayout, value); }
        }

        [Persistent("shared")]
        public bool Shared
        {
            get { return m_shared; }
            set { SetPropertyValue("Shared", ref m_shared, value); }
        }

        [Persistent("search_object_type")]
        [Size(SizeAttribute.Unlimited)]
        public string SearchObjectType
        {
            get { return m_searchObjectType; }
            set { SetPropertyValue("SearchObjectType", ref m_searchObjectType, value); }
        }

        [Persistent("sproc_name")]
        [Size(500)]
        public string SprocName
        {
            get { return m_sprocName; }
            set { SetPropertyValue("SprocName", ref m_sprocName, value); }
        }

        public override string ToString()
        {
            return m_name;
        }

        public static XPCollection<UserQuery> MyQueries()
        {
            BinaryOperator criteria = new BinaryOperator("UserName", Security.UserSecurity.CurrentUser.Login);
            XPCollection<UserQuery> queries = new XPCollection<UserQuery>(Scout.Core.Data.GetUnitOfWork(), criteria);
            queries.DisplayableProperties = "this;Name;UserName";
            return queries;
        }

        public static XPCollection<UserQuery> SharedQueries()
        {
            BinaryOperator criteria = new BinaryOperator("Shared", true);
            XPCollection<UserQuery> queries = new XPCollection<UserQuery>(Scout.Core.Data.GetUnitOfWork(), criteria);
            queries.DisplayableProperties = "this;Name;UserName";
            return queries;
        }
    }
}