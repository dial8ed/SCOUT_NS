using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("service_code_categories")]
    public class ServiceCodeCategory : VPLiteObject
    {
        private int m_id;
        private string m_category;

        public ServiceCodeCategory(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("category")]
        public string Category
        {
            get { return m_category; }
            set { SetPropertyValue("Category", ref m_category, value); }
        }

        public override string ToString()
        {
            return m_category;
        }

        public override bool Equals(object obj)
        {
            ServiceCodeCategory category = obj as ServiceCodeCategory;
            if(obj == null)
                return false;

            return category.Category == m_category;

        }
    }
}