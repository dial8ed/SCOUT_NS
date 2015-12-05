using System;
using System.Collections.Generic;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_stations")]
    public class RouteStation : VPObject
    {
        private int m_id;
        private ServiceStation m_station;
        private bool m_allowRepairs = false;
        private bool m_included = true;
        private bool m_isFirstStation = false;
        private ServiceRoute m_serviceRoute;
        private string m_layoutXmlPath = "";
        private bool m_isRepairComponentsRequired;

        public RouteStation(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }
            
        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        { 
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("station_id")]
        public ServiceStation Station
        {
            get { return m_station; }
            set { SetPropertyValue("Station", ref m_station, value); }
        }

        [Persistent("allow_repairs")]
        public bool AllowRepairs
        {
            get { return m_allowRepairs; }
            set { SetPropertyValue("AllowRepairs",ref m_allowRepairs, value); }
        }

        [Persistent("is_repair_components_required")]
        public bool IsRepairComponentsRequired
        {
            get { return m_isRepairComponentsRequired; }
            set { SetPropertyValue("IsRepairComponentsRequired.", ref m_isRepairComponentsRequired, value); }
        }

        [Persistent("included")]
        public bool Included
        {
            get { return m_included;  }
            set
            {
                SetPropertyValue("Included", ref m_included, value);
                
                // Remove the first station status is applied 
                // and the included value is false
                if(m_included == false)
                    IsFirstStation = false;
            }
        }

        [Persistent("is_first_station")]
        public bool IsFirstStation
        {
            get { return m_isFirstStation; }
            set { SetPropertyValue("IsFirstStation", ref m_isFirstStation, value); }
        }

        [Association("Route-Stations")]
        [Persistent("route_id")]
        public ServiceRoute ServiceRoute
        {
            get { return m_serviceRoute; }
            set { SetPropertyValue("ServiceRoute", ref m_serviceRoute, value); }
        }

        [Persistent("layout_file_path")]
        public string LayoutXmlPath
        {
            get { return m_layoutXmlPath; }
            set { SetPropertyValue("LayoutXmlPath", ref m_layoutXmlPath, value); }
        }


        public XPCollection<StationMaterialsTask> MaterialsTasks
        {
            get { return GetCollection<StationMaterialsTask>("MaterialTasks"); }
        }

        [NonPersistent]
        public string Name
        {
            get { return m_station.Name; }            
        }

        [NonPersistent]
        public ServiceStationType StationType
        {
            get { return m_station.Type; }        
        }

        [NonPersistent]
        public Shopfloorline Shopfloorline
        {
            get { return m_station.Shopfloorline; }            
        }

        [NonPersistent]
        public string StationName
        {
            get { return m_station.Name; }
        }

        [NonPersistent]
        public string PassTransition
        {
            get
            {
                return NextStationForOutcome("PASS") == null ? "" : NextStationForOutcome("PASS").Name;
            }
        }

        [NonPersistent]
        public string FailTransition
        {
            get
            {
                return NextStationForOutcome("FAIL") == null ? "" : NextStationForOutcome("FAIL").Name;
            }
        }

        public RouteStation NextStationForOutcome(string outcome)
        {
            foreach (StationOutcomeTransition transition in OutcomeTransitions)
            {
                if (transition.OutcomeValue == outcome)
                    return transition.NextStation;
            }
            return null;
        }

        public StationOutcomeTransition TransitionForOutcome(string outcome)
        {
            foreach (StationOutcomeTransition transition in OutcomeTransitions)
            {
                if (transition.OutcomeValue == outcome)
                    return transition;
            }
            return null;
        }

        public StationOutcomeTransition GetOutcomeTransitionFor(StationOutcome outcome)
        {
            foreach (StationOutcomeTransition transition in OutcomeTransitions)
            {
                if (transition.Outcome.Equals(outcome))
                    return transition;
            }
            return null;
        }
        [NonPersistent]
        public string FullLocation
        {
            get { return m_station.FullLocation; }
        }
      
        [Association("RouteStation-Documents"), Aggregated]
        public XPCollection<RouteStationDocument> Documents
        {
            get { return GetCollection<RouteStationDocument>("Documents"); }
        }

        [Association("RouteStation-FailCategories"), Aggregated]
        public XPCollection<RouteStationFailCategory> FailCategories
        {
            get { return GetCollection<RouteStationFailCategory>("FailCategories"); }
        }

        [Association("RouteStation-OutcomeTransitions"), Aggregated]
        public XPCollection<StationOutcomeTransition> OutcomeTransitions
        {
            get { return GetCollection<StationOutcomeTransition>("OutcomeTransitions"); }
        }

        [Association("RouteStation-Configurations")]
        public XPCollection<RouteStationConfiguration> StationConfigurations
        {
            get { return GetCollection<RouteStationConfiguration>("StationConfigurations"); }
        }

        public RouteStationConfiguration GetConfigurationFor(RouteConfiguration config)
        {
            foreach (RouteStationConfiguration configuration in StationConfigurations)
            {
                if (configuration.Config.Equals(config))
                    return configuration;
            }

            return null;
        }

        public RouteStationConfiguration GetConfigurationByName(string name)
        {
            foreach (RouteStationConfiguration configuration in StationConfigurations)
            {
                if (configuration.Config.Name == name)
                    return configuration;
            }

            return null;
            
        }

        public RouteStationConfiguration GetConfigurationFor(Part part)
        {
            // Try to load the configuration by the part number            
            RouteStationConfiguration config =  m_serviceRoute.GetConfigurationFor(this,part);

            // If not configuration exists then try to load the default
            if (config == null)
                // Load Default Configuration. This might not exist, 
                //so the caller must handle a null return value
                config = GetConfigurationByName("DEFAULT");

            return config;            
        }

        public RouteStationConfiguration AddConfiguration(RouteConfiguration routeConfig)
        {
            RouteStationConfiguration stationConfig =Scout.Core.Data.CreateEntity<RouteStationConfiguration>(Session);
            stationConfig.Station = this;
            stationConfig.Config = routeConfig;

            return stationConfig;
        }
      
        public void MapOutcomeTransitions(ICollection<StationOutcome> outcomes)
        {
            foreach (StationOutcome outcome in outcomes)
            {
                bool found = false;
                foreach (StationOutcomeTransition transition in OutcomeTransitions)
                {
                    if(transition.Outcome.Equals(outcome))
                        found = true;
                }

                if(!found)
                    OutcomeTransitions.Add(new StationTransitionMapper().MapFrom(outcome));                
            }           
        }

        public void MapCodeCategories(ICollection<ServiceCodeCategory> categories)
        {
            foreach (ServiceCodeCategory category in categories)
            {
                bool found = false;
                foreach (RouteStationFailCategory failCategory in FailCategories)
                {
                    if(failCategory.CodeCategory.Equals(category))
                        found = true;
                }

                if(!found)
                    FailCategories.Add(new FailCodeCategoryMapper().MapFrom(category));
            }
        }

        public override string ToString()
        {
            return m_station.Name;  
        }

        public override bool Equals(object obj)
        {
            RouteStation station = obj as RouteStation;
            if(station == null) return false;

            return station.Station.Id == m_station.Id;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            //Verify.IsTrue(Steps.Count >= 1, "StepsReq", "At least one step is required", "Steps");
            //Verify.IsTrue(FailCategories.Count >=1,"FailCatsReq","At least one fail category is required", "FailCategories");
            //Verify.IsTrue(Outcomes.Count >= 1, "OutcomesReq", "At least one station outcome is required", "Outcomes");            
       }

        public bool CopyStepsToConfig(int[] indexes, RouteStationConfiguration fromConfig, RouteStationConfiguration toConfig)
        {
            try
            {
                for (int i = 0; i < indexes.Length; i++)
                {
                    toConfig.Steps.Add(new RouteStationStepMapper().MapFrom(fromConfig.Steps[indexes[i]]));                
                }
            }
            catch (Exception ex)
            {
                return false;                       
            }
                return true;
        }
    }
}