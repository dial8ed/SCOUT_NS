using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class ResultListManager2 : PersistentBaseControl
    {
        private ICollection<ResultList> m_dataSource;

        public ResultListManager2() : base(Scout.Core.Data.GetUnitOfWork())
        {            
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            m_dataSource = Scout.Core.Data.GetList<ResultList>(UnitOfWork).All();
            resultsListGrid.DataSource = m_dataSource;                                               
        }
    }
}
