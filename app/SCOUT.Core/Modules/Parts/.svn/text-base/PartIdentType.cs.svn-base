using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_ident_types")]
    public class PartIdentType : VPObject
    {        
        private int m_id;
        private string m_name;

        public PartIdentType(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
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

        public static PartIdentType GetIdentType(IUnitOfWork uow,int value)
        {
            return PartRepository.GetIdentType(uow,value);
        }

        public static ICollection<PartIdentType> GetPartIdentTypes(IUnitOfWork uow)
        {
            return PartRepository.GetPartIdentTypes(uow);
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