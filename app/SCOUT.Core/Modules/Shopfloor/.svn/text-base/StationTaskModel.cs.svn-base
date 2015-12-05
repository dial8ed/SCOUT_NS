using System.Collections.Generic;
using System.Collections.ObjectModel;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    public class StationTaskModel// : PersistentModel
    {
        private RouteStationProcess m_process;
        private IUnitOfWork m_materialsUow;
        private IUnitOfWork m_inspectionsUow;
        
        private Collection<IStationTask> m_tasks;
        private ICollection<StationInspectionTaskResult> m_inspectionResults;

        public StationTaskModel(RouteStationProcess process)  
        {
            m_process = process;
            LoadTasks();            
        }

        private void LoadTasks()
        {
            m_tasks = new Collection<IStationTask>();
            LoadUnitOfWorks();
            LoadMaterialTasks();
            LoadInspectionTasks();
            //LoadStepTasks();    
            //LoadMrbTasks();
            //LoadFaTasks();
            //LoadRepairTasks();
        }

        private void LoadUnitOfWorks()
        {
            m_inspectionsUow = m_process.Session;
            m_materialsUow = Scout.Core.Data.GetUnitOfWork();
        }

        internal void LoadInspectionTasks()
        {
            m_inspectionResults =
                RoutingRepository.GetInspectionResults(m_inspectionsUow,
                                                       m_process.Item);
        }

        private void LoadMaterialTasks()
        {
            RouteStationProcess materialsProcess =
                RoutingRepository.GetRouteStationProcess(m_materialsUow,
                                                         m_process.Id);

            // Get the material tasks from the database.
            ICollection<ItemStationMaterialsTask> materialsTasks =
                RoutingRepository.GetProcessMaterialTasks(m_materialsUow, materialsProcess);

            // Add the material tasks to the model task list
            foreach (ItemStationMaterialsTask task in materialsTasks)
            {
                if(task.Task.ContainsProgramSpecification(m_process.Item.ShopfloorProgram))
                    m_tasks.Add(task);
            }           
        }

        public Collection<IStationTask> Tasks
        {
            get { return m_tasks; }
        }

        public RouteStationProcess Process
        {
            get { return m_process; }            
        }

        public RouteStation RouteStation
        {
            get { return m_process.Station; }
        }

        public ICollection<StationInspectionTaskResult> InspectionResults
        {
            get { return m_inspectionResults; }            
        }
    }
}