using System;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_configurations")]
    public class RouteStationConfiguration : VPObject
    {
        private int m_id;
        private RouteStation m_station;
        private RouteConfiguration m_config;
        
        public RouteStationConfiguration(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }


        [Association("RouteStation-Configurations")]
        [Persistent("route_station_id")]
        public RouteStation Station
        {
            get { return m_station; }
            set { SetPropertyValue("Station", ref m_station, value); }
        }

        [Persistent("route_config_id")]
        public RouteConfiguration Config
        {
            get { return m_config; }
            set { SetPropertyValue("Config", ref m_config, value); }
        }

        [Association("RouteStationConfig-Steps")]
        public XPCollection<RouteStationStep> Steps
        {
            get { return GetCollection<RouteStationStep>("Steps"); }
        }

        public XPCollection<RouteStationStep> ActiveSteps
        {
            get
            {
                return new XPCollection<RouteStationStep>(
                    Steps, new BinaryOperator("Active", true));
            }
        }

        [NonPersistent]
        public string Route
        {
            get { return m_station != null ? m_station.ServiceRoute.Name : ""; }
        }

        public void SortStepsBySeqNo()
        {
            SortingCollection sortCollection = new SortingCollection();
            sortCollection.Add(new SortProperty("SeqNo", SortingDirection.Ascending));
            Steps.Sorting = sortCollection;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }

        public bool CopyStepsToConfig(int[] indexes, RouteStationConfiguration toConfig)
        {
            try
            {
                for (int i = 0; i < indexes.Length; i++)
                {
                    toConfig.Steps.Add(new RouteStationStepMapper().MapFrom(Steps[indexes[i]]));
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        public override string ToString()
        {
            return m_config.Name;
        }
    }
}