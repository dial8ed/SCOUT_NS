using System.Text.RegularExpressions;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Validates the pattern of a supposed PPID 2D.
    /// </summary>
    public class PPID2DValidator
    {
        private string m_ppid2d;
        private string m_pattern = "^[A-Za-z]{2}[0]{1}[A-Za-z0-9]{5}[0-9]{5}[A-Za-z0-9]{3}[A-Za-z0-9]{7}$";

        public PPID2DValidator(string ppid2d)
        {
            m_ppid2d = ppid2d;
        }

        public bool Validate()
        {
            return new Regex(m_pattern).IsMatch(m_ppid2d);
        }
    }
}