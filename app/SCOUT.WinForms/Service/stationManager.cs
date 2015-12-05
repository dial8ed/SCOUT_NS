using System;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class StationManager : XtraUserControl
    {
        public StationManager()
        {
            InitializeComponent();
            Init();
            WireEvents();
        }

        private void WireEvents()
        {
            
        }

        private void Init()
        {
            stationTypeSelList.DataSource = 
                Enum.GetValues(typeof(ServiceStationType));
        }
    }
}
