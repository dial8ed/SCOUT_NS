using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [NonPersistent]
    public abstract class VPLiteObject : XPLiteObject
    {
        public VPLiteObject(Session session) : base(session)
        {

        }

        new public IUnitOfWork Session
        {
            get { return base.Session as XpoUnitOfWork; }            
        }
    }
}