using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("result_list_values")]
    public class ResultListValue : VPLiteObject
    {
        private int m_id;
        private string m_value;
        private ResultList m_resultList;

        public ResultListValue(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("value")]
        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        [Persistent("result_list_id")]
        [Association("ResultList-Values")]
        public ResultList ResultList
        {
            get { return m_resultList; }
            set { m_resultList = value; }
        }

        public override string ToString()
        {
            return m_value;
        }
    }
}