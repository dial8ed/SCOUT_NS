using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SCOUT.Core.Data
{
    public class SerialIdentifier : IMultiFieldIdentifier
    {
        private string m_completeIdentifier = "";
        private string m_pattern = "[A-Za-z0-9]{50}";
        private Dictionary<string,string> m_fieldList = new Dictionary<string, string>();

        public bool Validate()
        {
            if(new Regex(m_pattern).IsMatch(m_completeIdentifier))
            {
                BuildFieldList();
                return true;
            }

            string msg = "";
            msg = "Invalid serial number";

            MessageBox.Show(msg,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

            return false;

        }

        public void BuildFieldList()
        {
            if(m_fieldList.Count > 0)
                m_fieldList.Clear();
            
            m_fieldList.Add("sn", m_completeIdentifier);
        }

        public string CompleteIdentifier
        {
            get { return m_completeIdentifier; }
            set { m_completeIdentifier = value; }
        }

        public Dictionary<string, string> MultiFieldList
        {
            get { return m_fieldList; }
        }

        public string SerialNumber
        {
            get { return m_fieldList["sn"]; }
        }

        public override string ToString()
        {
            return GetType().Name;
        }

    }

}