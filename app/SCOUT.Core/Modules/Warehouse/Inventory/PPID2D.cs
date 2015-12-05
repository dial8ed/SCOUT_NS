using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents a PPID 2D as a IMultiFieldIdentifier
    /// </summary>
    public class PPID2DIdentifier : IMultiFieldIdentifier, ISerialIdentifier
    {
        private string m_completeIdentifier = "";
        private Dictionary<string, string> m_fieldList = new Dictionary<string, string>();
        private string m_pattern = "^[A-Za-z]{2}[0]{1}[A-Za-z0-9]{5}[0-9]{5}[A-Za-z0-9]{3}[A-Za-z0-9]{7}$";
        private string m_example = "MX03E540313467831079A00";
        private string m_displayName = "PPID2D";

        #region IMultiFieldIdentifier Members

        public bool Validate()
        {
            if (new Regex(m_pattern).IsMatch(m_completeIdentifier))
            {
                BuildFieldList();
                return true;
            }

            string msg = "";
            msg = string.Format("{0} is not a correctly formatted 2D PPID.", m_completeIdentifier);
            MessageBox.Show(
                msg,
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            return false;
        }

        public Dictionary<string, string> MultiFieldList
        {
            get { return m_fieldList; }
        }

        public void BuildFieldList()
        {
            if (m_fieldList.Count > 0)
            {
                m_fieldList.Clear();
            }

            PPID2DParser parser = new PPID2DParser(m_completeIdentifier);

            m_fieldList.Add("pn", parser.PN);
            m_fieldList.Add("sn", parser.SN);
        }

        public string CompleteIdentifier
        {
            get { return m_completeIdentifier; }
            set
            {
                StringBuilder builder = new StringBuilder(value);
                builder.Replace("-", "");
                m_completeIdentifier = builder.ToString().Trim();
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        #endregion

        public string Example
        {
            get { return m_example; }
        }

        public string DisplayName
        {
            get { return m_displayName; }
        }

        public bool SilentValidate()
        {
            if (new Regex(m_pattern).IsMatch(m_completeIdentifier))
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
    }
}