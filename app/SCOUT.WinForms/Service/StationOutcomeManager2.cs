using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class StationOutcomeManager2 : PersistentBaseControl
    {
        private ICollection<StationOutcome> m_outcomeData;

        public StationOutcomeManager2() : base(Scout.Core.Data.GetUnitOfWork())
        {
            InitializeComponent();
            LoadStationOutcomes();
        }

        private void LoadStationOutcomes()
        {
            m_outcomeData = Scout.Core.Data.GetList<StationOutcome>(UnitOfWork).All();
            outcomeListGrid.DataSource = m_outcomeData;
        }
    }
}
