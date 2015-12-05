namespace SCOUT.Core.Data
{
    public class PartToImport
    {
        private string m_error;
        private Part m_part;
        private string m_pn;
        private int m_qty;

        public PartToImport(string pn, int qty)
        {
            PartNumber = pn;
            m_qty = qty;
        }

        public string PartNumber
        {
            get { return m_pn; }
            set { m_pn = value; }
        }

        public string PartDescription
        {
            get { return m_part == null ? "" : m_part.Description; }
        }

        public int Qty
        {
            get { return m_qty; }
            set { m_qty = value; }
        }

        public bool IsValid
        {
            get { return string.IsNullOrEmpty(m_error); }
        }

        public string Error
        {
            get { return m_error; }
            set
            {
                m_error = value;                
            }
        }

        public Part Part
        {
            get { return m_part; }
            set { m_part = value; }
        }
    }
}