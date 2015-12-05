using DevExpress.Xpo;

namespace SCOUT.Tests.Domain.Fakes
{
    public class FakeDomain : SCOUT.Core.Data.Domain
    {
        public FakeDomain(Session session) : base(session)
        {
            Label = "TEST DOMAIN";
        }

        protected override void OnSaving()
        {         
            // Bypass OnSaving Rules
        }
    }
}