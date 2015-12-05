using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Domain.Fakes
{
    public class FakePart : Part
    {
        public FakePart() : base(XpoDefault.Session)
        {
            
        }

        public FakePart(Session session) : base(session)
        {
            PartNumber = "FAKE";
            Type = new PartType(session);
            IdentType = new PartIdentType(session);    
        }

        protected override void OnSaving()
        {
            // Bypass OnSaving Rules
        }

    }
}