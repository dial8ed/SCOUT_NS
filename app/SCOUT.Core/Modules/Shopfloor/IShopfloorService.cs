using System.Collections.Generic;
using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface IShopfloorService
    {
        void StageUnitAtFirstStation(ServiceRoute route,
                                                     InventoryItem inventoryItem);

        void MoveUnitToNextStation(RouteStationProcess process);

        void MoveUnitToNewStation(RouteStationProcess process,
                                                  RouteStation station);

        void MoveUnitToExistingStation(RouteStationProcess process);
        bool ProcessStation(RouteStationProcess process);
        void ProcessStationConditions(RouteStationProcess process);
        void RemoveBlankStepResults(RouteStationProcess process);
        void EndProcess(RouteStationProcess process);

        MethodResult ConvertProgram
            (RouteStationProcess process, string newProgram, string reason);

        ServiceRouteDisposition GetRouteDisposition(InventoryItem item, ServiceRoute route);

        ICollection<RouteStation> GetRouteStationsFromProcess(
            RouteStationProcess process);


        ICollection<ServiceRoute> GetAllServiceRoutes(
            IUnitOfWork uow);

        ICollection<ServiceTaskType> GetAllStepTypes(
            IUnitOfWork uow);

        ICollection<RouteStationConfiguration>
            GetAllStationConfigurations(IUnitOfWork uow);

        ICollection<RouteConfiguration> GetAllRouteConfigurations
            (IUnitOfWork uow);

        ICollection<StationOutcome> GetAllStationOutcomes(
            IUnitOfWork uow);

        ICollection<RouteStation> GetAllRouteStations(IUnitOfWork uow);
        ICollection<RouteStation> GetAllRouteStations(IUnitOfWork uow, Shopfloorline line);
        ICollection<StationMaterialsTask> GetStationMaterialTasks(IUnitOfWork uow, RouteStation station);
    }
}