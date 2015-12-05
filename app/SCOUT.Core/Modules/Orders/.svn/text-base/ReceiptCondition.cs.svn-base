using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_receiving_conditions")]
    public class ReceiptCondition : VPLiteObject
    {
        private string m_condition = "";

        public ReceiptCondition(Session session) : base(session)
        {
        }


        [Persistent("condition")]
        [Key(AutoGenerate = false)]
        public string Condition
        {
            get { return m_condition; }
            set { SetPropertyValue("Condition", ref m_condition, value); }
        }


        public override string ToString()
        {
            return m_condition;
        }

    }
}