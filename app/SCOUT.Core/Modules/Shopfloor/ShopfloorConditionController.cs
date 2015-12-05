using System;
using System.Collections;
using System.Text;

namespace SCOUT.Core.Data
{
    public class ShopfloorConditionController
    {
        private string m_conditions;
        private ArrayList m_conditionsArray;

        public ShopfloorConditionController(string conditions)
        {
            m_conditions = conditions;
            BuildArray();
        }

        private void BuildArray()
        {
            m_conditionsArray = new ArrayList();
            string[] array = m_conditions.Split(char.Parse(","));
            for (int i = 0; i < array.Length; i++)
            {
                string condition = array[i];
                if(!string.IsNullOrEmpty(condition))
                    m_conditionsArray.Add(condition);
            }
        }

        public void AddCondition(string condition)
        {
            m_conditionsArray.Add(condition);            
        }

        public void RemoveCondition(string condition)
        {
            m_conditionsArray.Remove(condition);
        }

        public bool ContainsCondition(string condition)
        {
            return m_conditionsArray.IndexOf(condition) >= 0;
        }

        public string FlattenArray()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in m_conditionsArray)
            {
                sb.Append(s + ",");                
            }

            if (sb.Length == 0)
                return "";

            string conditions = sb.ToString(0, sb.Length -1);

            return conditions;
        }

        public ArrayList List
        {
            get { return m_conditionsArray; }
        }

        public override string ToString()
        {
            return FlattenArray();
        }
    }
}