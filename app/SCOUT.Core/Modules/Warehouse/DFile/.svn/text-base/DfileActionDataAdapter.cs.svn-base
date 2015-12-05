using System;
using System.Collections.Generic;

namespace SCOUT.Core
{
    public class DfileActionDataAdapter
    {
        private string m_actionData;
        private Dictionary<string, string> m_elements;

        public DfileActionDataAdapter(string actionData)
        {
            m_actionData = actionData;
            m_elements = new Dictionary<string, string>();

            BuildElements();
        }

        public string GetElement(string elementName)
        {
            return m_elements[elementName];
        }

        private void BuildElements()
        {
            string[] pairs;

            pairs = m_actionData.Split(char.Parse(","));

            for(int i = 0; i < pairs.Length - 1; i++)
            {
                string[] keyValue;
                keyValue = pairs[i].Split(char.Parse("="));
                m_elements.Add(keyValue[0], keyValue[1]);
            }            
        }
    }
}