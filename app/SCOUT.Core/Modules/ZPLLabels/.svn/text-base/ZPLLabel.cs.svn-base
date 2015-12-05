using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("receiving_labels")]
    public class ZPLLabel : VPLiteObject
    {
        private int m_id;
        private string m_labelName;
        private string m_labelData;
        protected object[] m_args;

        protected ZPLLabel(Session session)
            : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("label_name")]
        public string LabelName
        {
            get { return m_labelName; }
            set { SetPropertyValue("LabelName", ref m_labelName, value); }
        }

        [Persistent("label_data")]
        public string LabelData
        {
            get { return m_labelData; }
            set { SetPropertyValue("LabelData", ref m_labelData, value); }
        }

        public static ZPLLabel GetLabelByName(string name)
        {
            BinaryOperator criteria = new BinaryOperator("LabelName", name);
            return Scout.Core.Data.GetUnitOfWork().FindObject<ZPLLabel>(criteria);            
        }

        public void SetLabelValues(object[] values)
        {
            m_args = values;
        }

        public object[] LabelValues
        {
            get { return m_args;  }
            set { m_args = value; }
        }

        public virtual bool Print()
        {
            return Scout.Core.UserInteraction.Printing.PrintZplLabel(this);
        }
    }
}