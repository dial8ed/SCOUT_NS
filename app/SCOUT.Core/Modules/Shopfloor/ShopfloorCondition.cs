using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core
{
    [Persistent("shopfloor_conditions")]
    public class ShopfloorCondition : VPObject
    {        
        private string m_condition;

        public ShopfloorCondition(Session session) : base(session)
        {

        }

        [Persistent("condition"), Key(AutoGenerate = false)]
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