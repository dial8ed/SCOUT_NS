using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using SCOUT.Core.Data;


namespace SCOUT.Core.Data
{
    internal class RoutingRepository
    {
        internal static ICollection<RouteStation> GetRouteStationsFromProcess(RouteStationProcess process)
        {
            ServiceRoute route = process.Station.ServiceRoute;
            XPCollection<RouteStation> routeStations = 
                new XPCollection<RouteStation>(route.Stations);

            return routeStations;                       
        }

        internal static ICollection<ServiceRoute> GetAllServiceRoutes(IUnitOfWork session)
        {
            BinaryOperator criteria = new BinaryOperator("Active", true);
            return Repository
                .GetList<ServiceRoute>(session)
                .ByCriteria(criteria);
        }

        internal static ICollection<ServiceTaskType> GetAllStepTypes(IUnitOfWork uow)
        {
            return Repository
                .GetList<ServiceTaskType>(uow)
                .All();
        }

        internal static ICollection<RouteStationConfiguration> GetAllStationConfigurations(IUnitOfWork uow)
        {
            return Repository
                .GetList<RouteStationConfiguration>(uow)
                .All();
        }

        internal static ICollection<RouteConfiguration> GetAllRouteConfigurations(IUnitOfWork uow)
        {
            return Repository
                .GetList<RouteConfiguration>(uow)
                .All();
        }

        internal static ICollection<StationOutcome> GetAllStationOutcomes(IUnitOfWork uow)
        {
            return Repository
                .GetList<StationOutcome>(uow)
                .All();
        }

        public static RouteStationConfiguration GetConfigurationFor(RouteStation station, Part part)
        {           
            ICollection<RouteStationConfiguration> configurations;            
            BinaryOperator op1 = new BinaryOperator("Part", part);
            BinaryOperator op2 = new BinaryOperator("Station", station);
            
            ContainsOperator containsOperator = new ContainsOperator("Config.ConfigurationParts", op1);
            GroupOperator groupOperator = new GroupOperator(op2, containsOperator);

            configurations = 
                Repository 
                .GetList<RouteStationConfiguration>(part.Session)
                .ByCriteria(groupOperator);

            if(configurations.Count == 0)
                return null;

            foreach (RouteStationConfiguration config in configurations)
            {
                if (config != null)
                    return config;            
            }

            return null;
        }


        public static ICollection<RouteStation> GetAllRouteStations(IUnitOfWork uow)
        {
            return Repository
                .GetList<RouteStation>(uow)
                .All();
        }


        public static StationMaterialsTask GetMaterialsTask(IUnitOfWork uow, RouteStationProcess process)
        {
            BinaryOperator op1 = new BinaryOperator("Configuration.PartModel", process.Item.Part.Model);
            BinaryOperator op2= new BinaryOperator("Configuration.RouteStation", process.Station);            
            GroupOperator criteria = new GroupOperator(op1,op2);

            return
                Repository
                .Get<StationMaterialsTask>(uow)
                .ByCriteria(criteria);                               
        }


        public static StationTaskResult GetTaskResult(StationTaskBase task, InventoryItem item)
        {
            BinaryOperator op1 = new BinaryOperator("Task", task);
            BinaryOperator op2 = new BinaryOperator("Item", item);
            GroupOperator criteria = new GroupOperator(op1,op2);

            return
                Repository
                .Get<StationTaskResult>(task.Session)
                .ByCriteria(criteria);
            
        }


        public static RouteStationProcess GetRouteStationProcess(IUnitOfWork uow, int id)
        {
            BinaryOperator op1 = new BinaryOperator("Id", id);

            return Repository
                .Get<RouteStationProcess>(uow)
                .ByCriteria(op1);
        }


        public static ICollection<ItemStationMaterialsTask> GetProcessMaterialTasks(IUnitOfWork uow, RouteStationProcess process)
        {
            BinaryOperator op1 = new BinaryOperator("RouteStationProcess", process);
            return Repository
                .GetList<ItemStationMaterialsTask>(uow)
                .ByCriteria(op1);
        }


        public static ICollection<StationMaterialsTask> GetStationMaterialTasks(IUnitOfWork uow, RouteStation station)
        {
            BinaryOperator op1 = new BinaryOperator("RouteStation", station);
            return Repository
                .GetList<StationMaterialsTask>(uow)
                .ByCriteria(op1);            
        }


        public static ICollection<StationInspectionTaskResult> GetInspectionResults(IUnitOfWork uow, InventoryItem item)
        {            
            BinaryOperator op1 = new BinaryOperator("Item", item);
            return
                Repository
                .GetList<StationInspectionTaskResult>(uow)
                .ByCriteria(op1);
        }

        public static ICollection<RouteStation> GetAllRouteStations(IUnitOfWork uow, Shopfloorline line)
        {
            BinaryOperator op1 = new BinaryOperator("Station.Shopfloorline", line);

            return Repository
                .GetList<RouteStation>(uow)
                .ByCriteria(op1);            
        }
    }
}