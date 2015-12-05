using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class RouteStationListManager : DevExpress.XtraEditors.XtraUserControl
    {
        public RouteStationListManager()
        {
            InitializeComponent();
        }

        public RouteStationListManager(ServiceRoute route)
        {
            InitializeComponent();
        }

        public void SetGridSource(XPCollection<RouteStation> stations)
        {            
            stationsGrid.DataSource = stations;
        }
    }
}
