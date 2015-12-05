using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("receiving_labels")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class GenericLabel : ZPLLabel
    {
        public GenericLabel(Session session) : base(session)
        {

        }

        public void SetLabelValues(string displayText)
        {
            m_args = new object[] { displayText, displayText };
        }

        public static GenericLabel GetGenericLabel()
        {
            return new GenericLabel(Scout.Core.Data.GetUnitOfWork());
        }
    }
}