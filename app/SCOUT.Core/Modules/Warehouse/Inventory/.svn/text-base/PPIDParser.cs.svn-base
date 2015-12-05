namespace SCOUT.Core.Data
{
    public class PPIDParser
    {
        private string m_ppid = "";
        private string m_sn = "";
        private string m_pn = "";

        public PPIDParser(string ppid)
        {
            m_ppid = ppid;
            Parse();
        }

        private void Parse()
        {
            if (!new PPIDValidator(m_ppid).Validate())
                return;

            m_sn = m_ppid.Substring(8, 12);
            m_pn = m_ppid.Substring(3, 5);           
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
    }
}