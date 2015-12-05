using System;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Service
{
    public partial class RouteBuilderForm : XtraForm
    {
        private RouteBuilderController m_controller;
        private ServiceRoute m_route;
        private IUnitOfWork m_session;
        
        public RouteBuilderForm(ServiceRoute route)
        {
            InitializeComponent();
            m_route = route;
            Init();
            Bind();
            WireEvents();
        }

        private void Bind()
        {
            routeBinding.DataSource = m_route;
            errorProvider.DataSource = routeBinding;

            routeNameText.DataBindings.Add("EditValue", routeBinding, "Name");
            sflSelList.DataBindings.Add("EditValue", m_route, "Shopfloorline!");
            activeChk.DataBindings.Add("Checked", routeBinding, "Active");
            returnTypeLookup.DataBindings.Add("EditValue", m_route, "ReturnType");
        }

        private void Init()
        {
            m_session = m_route.Session;
            m_controller = new RouteBuilderController(m_route);
            sflSelList.Properties.DataSource = 
                Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);


            returnTypeLookup.Properties.DataSource = Enum.GetValues(typeof (ReturnType));
        }

        private void WireEvents()
        {
            sflSelList.EditValueChanged += sflSelList_EditValueChanged;            
            stationsGrid.DoubleClick += stationsGrid_DoubleClick;
            stationsView.FocusedRowChanged += stationsView_FocusedRowChanged;
        }

        void stationsView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RouteStation station = stationsView.GetFocusedRow() as RouteStation;
            if (station != null)
            {
                if (station.Included)
                {
                    stationIncludedButton.Caption = "Remove Station";
                    stationIncludedButton.ImageIndex = 0;
                }
                else
                {
                    stationIncludedButton.Caption = "Include Station";
                    stationIncludedButton.ImageIndex = 1;
                }
            }
        }

        private void stationsGrid_DoubleClick(object sender, EventArgs e)
        {
            LoadStationConfiguration();
        }

        private void LoadStationConfiguration()
        {
            RouteStation station = stationsView.GetFocusedRow() as RouteStation;
            if (station != null)
            {
                if (!station.Included)
                {
                    MessageBox.Show("This station is not included in the current route.", Application.ProductName,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ServiceStationForm form = new ServiceStationForm(station);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        private void sflSelList_EditValueChanged(object sender, EventArgs e)
        {
            Shopfloorline shopfloorline = sflSelList.EditValue as Shopfloorline;
            if (shopfloorline != null)
            {
                // ask the controller to generate the stations
                m_controller.GenerateStations(shopfloorline);

                // display the stations in the grid
                stationsGrid.DataSource = m_route.Stations;
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            stationsGrid.Focus();

            if(m_route.Error.Length > 0 )
            {
                MessageBox.Show(m_route.Error, Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Scout.Core.Data.Save(m_session);                
                VerifySaveClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Application.ProductName, 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void VerifySaveClose()
        {
            InfoBox ib = new InfoBox();
            DialogResult ans;

            Text = "Route " + m_route.Name;

            ib.Buttons = MessageBoxButtons.YesNo;
            ans = ib.Show(
                "The route {0} has been saved successfully.\n" +
                "Do you wish to close this window?",
                m_route.Name);

            if (ans == DialogResult.Yes)
                Close();
        }

        private void refreshStationsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            sflSelList_EditValueChanged(null, null);
        }

        private void setfirstStationButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            RouteStation station = stationsView.GetFocusedRow() as RouteStation;
            if(station != null)
            {
                if (!StationIsIncluded(station))
                    return;

                if(!VerifyFirstStationChange(station))
                    return;

                m_route.SetFirstStation(station);
            }
        }

        private bool StationIsIncluded(RouteStation station)
        {
            if (station.Included == false)
            {
                MessageBox.Show(
                    "This station is not currently included in the route and cannot be set as the first station.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;   
            }

            return true;    
        }

        private bool VerifyFirstStationChange(RouteStation station)
        {                       
            string msg = "Are you sure that you";
            msg += " that you want to set station";
            msg += " {0} as the first station?";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(msg, station.Name);

            DialogResult result = MessageBox.Show(sb.ToString(), 
                                    Application.ProductName, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            return result == DialogResult.Yes;

        }

        private void stationIncludedButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            RouteStation station = stationsView.GetFocusedRow() as RouteStation;
            if(station != null)
            {
                if(station.Included)
                {
                    if (MessageBox.Show("Are you sure that you want to remove this station?",
                        Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if(m_route.IsTransitionStation(station))
                        {
                            MessageBox.Show("This station is part of outcome routing and must be included.",
                                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        
                        station.Included = false;
                    }
                } else
                {
                    station.Included = true;    
                }
            }
        }

        private void closeButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void serviceSetupButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewLoader.Instance().CreateFormWithArgs<ServiceSetupForm>(false, null);
        }
    }
}
