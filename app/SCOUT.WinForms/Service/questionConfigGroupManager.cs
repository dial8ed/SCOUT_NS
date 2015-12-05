using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Service
{
    public partial class QuestionConfigGroupManager : XtraUserControl
    {
        private IUnitOfWork m_uow;
        public QuestionConfigGroupManager()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            m_uow = Scout.Core.Data.GetUnitOfWork();
            gridControl1.DataSource = 
                Scout.Core.Service<IShopfloorService>().GetAllRouteConfigurations(m_uow);
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            if(Scout.Core.Data.Save(m_uow))
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage("Saved", UserMessageType.Information);
            }           
        }
    }
}
