using System.Text.RegularExpressions;

namespace SCOUT.Core.Data
{
    public class PPIDValidator
    {
        private string m_pattern = "^[A-Za-z]{2}[0]{1}[A-Za-z0-9]{5}[0-9]{5}[A-Za-z0-9]{3}[A-Za-z0-9]{4}$";
        private string m_ppid = "";

        public PPIDValidator(string ppid)
        {
            m_ppid = ppid;
        }

        public bool Validate()
        {
            if (m_ppid.Trim().Equals("NA"))
                return true;

            return new Regex(m_pattern).IsMatch(m_ppid);
        }
    }
}