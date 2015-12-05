using SCOUT.Core.Services;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class QuestionConfigGroupManager2 : PersistentBaseControl
    {
        public QuestionConfigGroupManager2() : base(Scout.Core.Data.GetUnitOfWork())
        {
            InitializeComponent();
            Init();
        }
            
        private void Init()
        {           
            questionGroupsGrid.DataSource = 
                Scout.Core.Service<IShopfloorService>().GetAllRouteConfigurations(UnitOfWork);
        }        
    }
}
