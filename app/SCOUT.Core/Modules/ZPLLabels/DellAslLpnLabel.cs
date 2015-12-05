using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("receiving_labels")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class DellAslLpnLabel : ZPLLabel
    {
        protected DellAslLpnLabel(Session session) : base(session)
        {

        }

        public void SetLabelValues(string aslLpn, string partNumber)
        {            
            m_args = new object[]{aslLpn, aslLpn, partNumber, partNumber };
        }

        public static DellAslLpnLabel GetDellAslLpnLabel()
        {
            return new DellAslLpnLabel(Scout.Core.Data.GetUnitOfWork());
        }

    }
}