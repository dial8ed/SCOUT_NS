using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class ResultListManager : PersistentBaseControl
    {
        public ResultListManager() : base(Scout.Core.Data.GetUnitOfWork())
        {            
            Init();
        }

        private void Init()
        {
            gridControl1.DataSource = new XPCollection<ResultList>(Scout.Core.Data.GetUnitOfWork());
        }

    }
}
