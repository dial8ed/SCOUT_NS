using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Modules;

namespace SCOUT.Core.Services
{
    public class ShopfloorService: ModuleService, IShopfloorService
    {
        public ShopfloorService(IModule module) : base(module)
        {
            
        }

        public void StageUnitAtFirstStation(ServiceRoute route,
                                                   InventoryItem inventoryItem)
        {
            inventoryItem.Processes.Add(
                route.CreateRouteStationProcess(route.FirstStation(),
                                                inventoryItem));
           
            Scout.Core.Service<ITransactionService>().CreateTransaction("ROUTETRANS", inventoryItem, "",
                                                 inventoryItem.CurrentProcess.
                                                     Station.FullLocation,
                                                 "Unit was moved to the first station.",
                                                 "");

            inventoryItem.ChangeDomain(route.FirstStation().Station.Domain);

        }

        public void MoveUnitToNextStation(RouteStationProcess process)
        {
            InventoryItem item = process.Item;
            ServiceRoute route = process.Station.ServiceRoute;

            Scout.Core.Service<ITransactionService>().CreateTransaction("STATIONTRANS", item,
                                                 process.Station.FullLocation,
                                                 process.NextStation.
                                                     FullLocation,
                                                 "Unit was moved to the next station.",
                                                 "");

            RouteStationProcess newProcess =
                route.CreateRouteStationProcess(process.NextStation, item);
            newProcess.PrevProcess = process;

            item.CurrentProcess = newProcess;
            item.ChangeDomain(process.NextStation.Station.Domain);
        }


        public void MoveUnitToNewStation(RouteStationProcess process,
                                                RouteStation station)
        {
            InventoryItem item = process.Item;
            ServiceRoute route = process.Station.ServiceRoute;

            Scout.Core.Service<ITransactionService>().CreateTransaction("STATIONTRANS", item,
                                                 process.Station.FullLocation,
                                                 station.FullLocation,
                                                 "Unit was manually moved to a new station.",
                                                 "");


            if (item.CurrentProcess != null)
                item.CurrentProcess.PrevProcess = item.CurrentProcess;

            RouteStationProcess newProcess =
                route.CreateRouteStationProcess(station, item);

            item.CurrentProcess = newProcess;
            item.ChangeDomain(newProcess.Station.Station.Domain);
        }


        public void MoveUnitToExistingStation(RouteStationProcess process)
        {
            InventoryItem item = process.Item;
            item.CurrentProcess = process;
            item.ChangeDomain(process.Station.Station.Domain);
        }

        public bool ProcessStation(RouteStationProcess process)
        {
            RemoveBlankStepResults(process);

            if (!new RouteStationProcessValidator(process).Validated())
                return false;

            if (process.StationOutcome == null)
                return true;

            // Get the station outcome transition if it exists.
            StationOutcomeTransition transition =
                process.Station.GetOutcomeTransitionFor(process.StationOutcome);

            if (
                !new StationOutcomeTransitionValidator(transition, process).
                     Validated())
                return false;

            // Move the unit to the next station if defined.
            if (process.NextStation != null)
            {
                MoveUnitToNextStation(process);
            } 
                // End the process if a transition was determined and the transition is defined
                // as the end of a process
            else if (transition != null && transition.EndProcessRoute)
            {
                EndProcess(process);
            }

            ProcessStationConditions(process);

            return true;
        }

        public void ProcessStationConditions(RouteStationProcess process)
        {
            // Get the station conditions
            IEnumerable<IActionSpecification<RouteStationProcess>> conditions
                = ShopfloorRepository.GetShopfloorConditions(process);

            // Check condition and execute action
            foreach (IActionSpecification<RouteStationProcess> c in conditions)
            {
                if (c.IsSatisfiedBy(process))
                {                    
                    c.ExecuteAction();
                    string msg = c.Message.Message;

                    if (!string.IsNullOrEmpty(msg))
                        Scout.Core.UserInteraction.Dialog.ShowMessage(msg, UserMessageType.Information);
                       
                }                    
            }                          
       }

        public void RemoveBlankStepResults(RouteStationProcess process)
        {
            IUnitOfWork uow = process.Session;

            for (int i = 0; i < process.Results.Count; i++)
            {
                RouteStationResult result = process.Results[i];
                if (string.IsNullOrEmpty(result.Result))
                {
                    process.Results.Remove(result);
                    result.Process = null;

                    if (uow != null)
                        uow.Delete(result, false);

                    RemoveBlankStepResults(process);
                }
            }

            Scout.Core.Data.Save(uow);            
        }

        public void EndProcess(RouteStationProcess process)
        {
            if (new EndProcessValidator(process).Validated())
            {
                process.RoutingEnabled = false;
                process.Item.CurrentProcess = null;
            }
        }


        public ICollection<RouteStation> GetRouteStationsFromProcess(
            RouteStationProcess process)
        {
            return RoutingRepository.GetRouteStationsFromProcess(process);
        }


        public ICollection<ServiceRoute> GetAllServiceRoutes(
            IUnitOfWork uow)
        {
            return RoutingRepository.GetAllServiceRoutes(uow);
        }


        public ICollection<ServiceTaskType> GetAllStepTypes(
            IUnitOfWork uow)
        {
            return RoutingRepository.GetAllStepTypes(uow);
        }


        public ICollection<RouteStationConfiguration>
            GetAllStationConfigurations(IUnitOfWork uow)
        {
            return RoutingRepository.GetAllStationConfigurations(uow);
        }


        public ICollection<RouteConfiguration> GetAllRouteConfigurations
            (IUnitOfWork session)
        {
            return RoutingRepository.GetAllRouteConfigurations(session);
        }


        public ICollection<StationOutcome> GetAllStationOutcomes(
            IUnitOfWork session)
        {
            return RoutingRepository.GetAllStationOutcomes(session);
        }


        public ICollection<RouteStation> GetAllRouteStations(IUnitOfWork session)
        {
            return RoutingRepository.GetAllRouteStations(session);
        }

        public ICollection<RouteStation> GetAllRouteStations(IUnitOfWork session, Shopfloorline line)
        {            
            return RoutingRepository.GetAllRouteStations(session, line);                        
        }


        public ICollection<StationMaterialsTask> GetStationMaterialTasks(IUnitOfWork uow, RouteStation station)
        {
            return RoutingRepository.GetStationMaterialTasks(uow, station);           
        }


        public MethodResult ConvertProgram
            (RouteStationProcess process, string newProgram, string reason)
        {
            // Create conversion record
            ShopfloorProgramConversion c =
                new ShopfloorProgramConversion();

            Dictionary<string, object> inputParams =
                new Dictionary<string, object>(2);

            inputParams.Add("Reason", reason);
            inputParams.Add("NewProgram", newProgram);

            return c.Execute(process, inputParams);

        }

        public ServiceRouteDisposition GetRouteDisposition(InventoryItem item, ServiceRoute route)
        {
            BinaryOperator op1 = new BinaryOperator("Item", item);
            BinaryOperator op2 = new BinaryOperator("ServiceRoute", route);

            GroupOperator criteria = new GroupOperator(op1, op2);

            ServiceRouteDisposition disposition = Repository
                .Get<ServiceRouteDisposition>(item.Session)
                .ByCriteria(criteria);

            if (disposition != null)
                return disposition;

            return null;
        }

    }
}