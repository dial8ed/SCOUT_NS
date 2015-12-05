using System.Collections.Generic;
using System.Drawing;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public class StationInspectionTaskModel : IPersistentModel
    {
        private RouteStationProcess m_process;
        private StationInspectionTaskResult m_taskResult;
        private ServiceCode m_failureCode;
        private RouteStationStep m_step;
        private string m_damageType;
        private string m_damageMethod;
        private string m_comments;
        private Image m_image;
        private RouteStationFailure m_failure;


        public StationInspectionTaskModel(RouteStationProcess process)
        {
            m_process = process;
        }


        public StationInspectionTaskModel(StationInspectionTaskResult taskResult)
        {
            m_taskResult = taskResult;
            MapDataToModel(m_taskResult);
        }


        private void MapDataToModel(StationInspectionTaskResult result)
        {
            PropertyMapper
                <StationInspectionTaskResult, StationInspectionTaskModel> mapper
                    =
                    new PropertyMapper
                        <StationInspectionTaskResult, StationInspectionTaskModel
                            >();

            mapper.MapFrom(result, this);
        }


        public RouteStationProcess Process
        {
            get { return m_process; }
            set { m_process = value; }
        }

        public ServiceCode FailureCode
        {
            get { return m_failure != null ? m_failure.FailCode : null; }
            set { m_failureCode = value; }
        }

        public RouteStationFailure Failure
        {
            get
            {
                if (m_failureCode == null)
                    return null;

                if (m_failure == null ||
                    !m_failure.FailCode.Equals(m_failureCode))
                    MapServiceCodeToFailure(m_failureCode);

                return m_failure;
            }
            set { m_failure = value; }
        }

        public RouteStationStep Step
        {
            get { return m_step; }
            set { m_step = value; }
        }

        public string DamageType
        {
            get { return m_damageType; }
            set { m_damageType = value; }
        }

        public string DamageMethod
        {
            get { return m_damageMethod; }
            set { m_damageMethod = value; }
        }

        public string Comments
        {
            get { return m_comments; }
            set { m_comments = value; }
        }

        public Image Image
        {
            get { return m_image; }
            set
            {
                m_image = value;
            }
        }

        public StationTaskOutcome Outcome
        {
            get { return StationTaskOutcome.Performed; }
            set { }
        }

        public InventoryItem Item
        {
            get { return m_process != null ? m_process.Item : null; }
            set { }
        }

        internal StationInspectionTaskResult TaskResult
        {
            get
            {
                if (m_taskResult == null)
                    m_taskResult = Scout.Core.Data.CreateEntity<StationInspectionTaskResult>(UnitOfWork);

                return m_taskResult;
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get { return m_process.Session as IUnitOfWork; }
        }

        public ICollection<ServiceCode> FailCodes
        {
            get
            {
                PartModel partModel = m_process.Item.Part.Model;
                PartServiceCommodity commodity = m_process.Item.ServiceCommodity;

                if (partModel != null)
                    return commodity.ServiceCodesByModel(partModel);

                return commodity.ServiceCodes;
            }
        }

        public ICollection<RouteStationStep> Steps
        {
            get
            {
                RouteStationConfiguration config = m_process.Configuration;
                if (config == null)
                    return null;

                return config.ActiveSteps;
            }
        }

        internal void MapServiceCodeToFailure(ServiceCode code)
        {
            if (m_failure == null)
                m_failure = Scout.Core.Data.CreateEntity<RouteStationFailure>(UnitOfWork);

            m_failure.FailCode = code;
            m_failure.StationProcess = m_process;
            m_failure.Comments = m_comments;
        }
    }
}