using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("inventory_conditions")]
    public class InventoryCondition : VPObject
    {
        private int m_id;
        private InventoryItem m_item;
        private string m_conditionSource;
        private string m_condition;

        public InventoryCondition(Session session) : base(session)
        {
        }

        [Persistent("id")]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id",ref m_id, value);}
        }

        [Persistent("lotid"), Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }

        [Persistent("condition_source")]
        public string ConditionSource
        {
            get { return m_conditionSource; }
            set { SetPropertyValue("ConditionSource", ref m_conditionSource, value); }
        }

        [Persistent("condition")]
        public string Condition
        {
            get { return m_condition; }
            set { SetPropertyValue("Condition", ref m_condition, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}