namespace SCOUT.Core.Data
{
    public class UnitRepair
    {
        private int m_id;
        private string m_repairCode;
        private string m_repairDescription;
        private string m_notes;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string RepairCode
        {
            get { return m_repairCode; }
            set { m_repairCode = value; }
        }

        public string RepairDescription
        {
            get { return m_repairDescription; }
            set { m_repairDescription = value; }
        }

        public string Notes
        {
            get { return m_notes; }
            set { m_notes = value; }
        }
    }
}