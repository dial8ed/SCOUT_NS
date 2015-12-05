using System;
using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class StationManager2 : PersistentBaseControl
    {
        private ICollection<ServiceStation> m_stationsData;
        private ICollection<Domain> m_domainsData;

        public StationManager2() : base(Scout.Core.Data.GetUnitOfWork())
        {
            InitializeComponent();
            LoadStations();
        }

        private void LoadStations()
        {
            m_stationsData = Scout.Core.Data.GetList<ServiceStation>(UnitOfWork).All();
            stationsGrid.DataSource = m_stationsData;

            m_domainsData = Scout.Core.Data.GetList<Domain>(UnitOfWork).All();

            domainColumnEditor.DataSource = m_domainsData;

            stationTypeSelList.DataSource =
                Enum.GetValues(typeof(ServiceStationType));
        }
    }
}
