using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using System.Linq;


namespace SCOUT.WinForms.Service
{
    public partial class RouteStationMaintForm : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork m_session;
        private InventoryItem m_item;
        private RouteStation m_station;

        public RouteStationMaintForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();
            WireEvents();
        }

        private void WireEvents()
        {
            snText.Validated += snText_Validated;
            allStationsListBox.SelectedIndexChanged += allStationsListBox_SelectedIndexChanged;
            routesListBox.SelectedIndexChanged += routesListBox_SelectedIndexChanged;
        }

        void routesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_item == null)
                return;

            ServiceRoute route = routesListBox.SelectedValue as ServiceRoute;
            if(route != null)
            {                
                LoadStationDetails(route.FirstStation());
            }
        }

        void allStationsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RouteStation station
             = allStationsListBox.SelectedValue as RouteStation;

            if (station != null)
                LoadStationDetails(station);
        }

        private void LoadStationDetails(RouteStation station)
        {
            m_station = station;

            if (m_station == null)
            {
                Clear();
                return;
            }

            stationText.Text = m_station.Station.Name;
            domainText.Text = m_station.Station.Domain.Label;
        }


        private void Clear()
        {
            stationText.Text = "";
            domainText.Text = "";
            snText.Text = "";
            currentStationText.Text = "";
            m_item = null;
            m_station = null;
            allStationsListBox.DataSource = null;
            routesListBox.SelectedValue = null;            
            snText.Focus();
        }

        void snText_Validated(object sender, EventArgs e)
        {
            if(snText.Text.Length == 0)
                return;

            m_item = Scout.Core.Service<IInventoryService>()
                .GetItemBySN(m_session, snText.Text);

            if (m_item == null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage
                    ("Invalid serial number",UserMessageType.Error);
                return;
            }


            if(m_item.Hold != null)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage
                    ("This unit is on hold and cannot be routed at this time.", UserMessageType.Validation);
                snText.SelectAll();
                return;                
            }

            LoadUnit(m_item);
        }

        private void LoadUnit(InventoryItem item)
        {            
            if(item.CurrentProcess == null)
            {
                MessageBox.Show("This unit is not being processed on a route", Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            } 
            else
            {
                currentStationText.Text = item.CurrentProcess.Station.Name;
                allStationsListBox.DataSource =  
                    Scout.Core.Service<IShopfloorService>()
                    .GetRouteStationsFromProcess(item.CurrentProcess)
                    .Where(s => s.Station.Active).ToList();

                allStationsListBox.SelectedIndex = -1;
            }

            routesListBox.DataSource = 
                Scout.Core.Service<IShopfloorService>()
                .GetAllServiceRoutes(m_session);
        }

        private void newProcessButton_Click(object sender, EventArgs e)
        {            
            if(m_station != null)
            {
                if (m_item.CurrentProcess == null || 
                    !m_item.CurrentProcess.Station.ServiceRoute.Equals(m_station.ServiceRoute))
                {
                    Scout.Core.Service<IShopfloorService>()
                        .StageUnitAtFirstStation(m_station.ServiceRoute,m_item); 
                } 
                else
                {
                    Scout.Core.Service<IShopfloorService>()
                        .MoveUnitToNewStation(m_item.CurrentProcess, m_station);
                }
                                
                try
                {
                    Scout.Core.Data.Save(m_session);                   
                    MessageBox.Show("Unit moved.", Application.ProductName, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}