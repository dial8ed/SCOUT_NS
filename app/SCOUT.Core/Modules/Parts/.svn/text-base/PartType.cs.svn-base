using System.Collections.Generic;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("part_types")]
    public class PartType : VPObject
    {
        private int m_id;
        private string m_name = "";

        public PartType(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        internal static PartType GetType(IUnitOfWork uow, int value)
        {
            return PartRepository.GetType(uow, value);
        }

        public static ICollection<PartType> GetPartTypes(IUnitOfWork uow)
        {
            return PartRepository.GetPartTypes(uow);
        }

        public override string ToString()
        {
            return m_name;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
        }
    }
}