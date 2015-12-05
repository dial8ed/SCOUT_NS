using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("shopfloor_program_conversions")]
    public class ShopfloorProgramConversionRecord : VPObject
    {
        private int m_id;
        private InventoryItem m_item;
        private string m_oldProgram;
        private string m_newProgram;
        private string m_reason;

        public ShopfloorProgramConversionRecord(InventoryItem item, 
            string oldProgram, string newProgram, string reason) : base(item.Session as XpoUnitOfWork)
        {
            Item = item;
            OldProgram = oldProgram;
            NewProgram = newProgram;
            Reason = reason;

            UserTracking.SetUserInfoGetter(new SecurityUserGetter());            
        }

        [Persistent("id")] 
        [Key(AutoGenerate = true)]         
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("lotid"), Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }

        [Persistent("old_program")]
        public string OldProgram
        {
            get { return m_oldProgram; }
            set { SetPropertyValue("OldProgram", ref m_oldProgram, value); }
        }

        [Persistent("new_program")]
        public string NewProgram
        {
            get { return m_newProgram; }
            set { SetPropertyValue("NewProgram", ref m_newProgram, value); }
        }

        [Persistent("reason")]
        public string Reason
        {
            get { return m_reason; }
            set { SetPropertyValue("Reason", ref m_reason, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}