using System.Collections.Generic;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("result_lists")]
    public class ResultList : VPLiteObject
    {
        private int m_id;
        private string m_name;       

        public ResultList(Session session)
            : base(session){
        

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

        public override string ToString()
        {
            return m_name;
        }

        [Association("ResultList-Values")]
        public XPCollection<ResultListValue> ResultListValues
        {
            get { return GetCollection<ResultListValue>("ResultListValues"); }
        }
    }
}