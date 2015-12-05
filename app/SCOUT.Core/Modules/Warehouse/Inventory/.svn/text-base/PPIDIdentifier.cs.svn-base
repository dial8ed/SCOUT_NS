using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a Dell PPID as a IMultiPartIdentifier and ISerialIdentifier
    /// </summary>
    public class PPIDIdentifier : IMultiFieldIdentifier, ISerialIdentifier
    {
        protected string m_completeIdentifier = "";       
        protected Dictionary<string, string> m_fieldList = new Dictionary<string, string>();
        private string m_displayName = "PPID";
        private string m_example = "MY0YY809313466661327";

        public bool SilentValidate()
        {
            if (new PPIDValidator(m_completeIdentifier).Validate())
            {
                BuildFieldList();
                return true;
            }       
            return false;             
        }

        public void SetSerial(string sn)
        {
            CompleteIdentifier = sn;
        }

        public virtual string DisplayName
        {
            get { return m_displayName; }
        }

        public string Example
        {
            get { return m_example; }
        }

        public bool Validate()
        {
            if (new PPIDValidator(m_completeIdentifier).Validate())
            {
                BuildFieldList();
                return true;
            }
            else
            {
                string msg = "";
                msg = string.Format("{0} is not a correctly formatted PPID value.", m_completeIdentifier);

                MessageBox.Show(
                    msg, 
                    Application.ProductName, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return false;
            }
        }

        public Dictionary<string,string> MultiFieldList
        {
            get { return m_fieldList; }
        }

        public virtual void BuildFieldList()
        {
            if(m_fieldList.Count > 0 )
            {
                m_fieldList.Clear();
            }
               
            m_fieldList.Add("pn", m_completeIdentifier.Substring(3, 5));
            //m_fieldList.Add("sn", m_completeIdentifier.Substring(8,m_completeIdentifier.Length - 8));
            m_fieldList.Add("sn", m_completeIdentifier);
        }

        public string CompleteIdentifier
        {
            get { return m_completeIdentifier; }
            set { m_completeIdentifier = value; }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}