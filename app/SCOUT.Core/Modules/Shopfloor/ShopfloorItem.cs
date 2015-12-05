using SCOUT.Core.Data;

namespace SCOUT.Core
{
    public class ShopfloorItem
    {
        private InventoryItem m_item;
        private ShopfloorConditionController m_conditionController;

        public ShopfloorItem(InventoryItem item)
        {
            m_item = item;
            m_conditionController = new ShopfloorConditionController(item.ShopfloorConditions);
        }

        public string Program
        {
            get { return m_item.ShopfloorProgram; }
        }

        public bool HasCondition(string condition)
        {
            return m_conditionController.ContainsCondition(condition);
        }

        public void AddCondition(string condition)
        {
            m_conditionController.AddCondition(condition);
            m_item.ShopfloorConditions = m_conditionController.ToString();
        }

        public void RemoveCondition(string condition)
        {
            m_conditionController.RemoveCondition(condition);
            m_item.ShopfloorConditions = m_conditionController.ToString();
        }

    }
}