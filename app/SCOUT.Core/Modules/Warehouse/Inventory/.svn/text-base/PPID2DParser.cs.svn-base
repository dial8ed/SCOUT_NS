namespace SCOUT.Core.Data
{
    /// <summary>
    /// Parses a PPID2D into its sub parts.
    /// </summary>
    public class PPID2DParser
    {
        private string m_ppid2d;
        private string m_ppid = "";
        private string m_sn = "";
        private string m_pn = "";
        private string m_rev = "";

        private bool m_isParsed;

        public PPID2DParser(string ppid2d)
        {
            m_ppid2d = ppid2d;
            Parse();
        }

        private void Parse()
        {
            if (!new PPID2DValidator(m_ppid2d).Validate())
            {
                IsParsed = false;
                return;
            }
                
            m_ppid = m_ppid2d.Substring(0, 20);
            m_sn = m_ppid2d.Substring(0, 20);
            m_pn = m_ppid2d.Substring(3,5);
            m_rev = m_ppid2d.Substring(20, 3);

            IsParsed = true;
        }

        public bool IsParsed
        {
            get { return m_isParsed; }
            set { m_isParsed = value; }
        }

        public string PPID
        {
            get { return m_ppid; }
        }

        public string SN
        {
            get { return m_sn; }
        }

        public string PN
        {
            get { return m_pn; }
        }

        public string Revision
        {
            get { return m_rev; }
        }
    }
}