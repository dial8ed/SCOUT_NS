using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_repair_components")]
    public class RepairComponent : VPObject
    {
        private Guid m_id;
        private ServiceCommodityComponent m_component;
        private Part m_partIn;
        private Part m_partOut;
        private string m_serialNumberIn;
        private string m_serialNumberOut;
        private RouteStationRepair m_repair;
        private int m_consumptionId;
        private bool m_consumptionReversed;

        public RepairComponent(Session session) : base(session)
        {
            
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("commodity_component_id")]
        public ServiceCommodityComponent Component
        {
            get { return m_component; }
            set { SetPropertyValue("Component", ref m_component, value); }
        }

        [Persistent("part_in_id")]
        public Part PartIn
        {
            get { return m_partIn; }
            set { SetPropertyValue("PartIn", ref m_partIn, value); }
        }

        [Persistent("part_out_id")]
        public Part PartOut
        {
            get { return m_partOut; }
            set { SetPropertyValue("PartOut", ref m_partOut, value); }
        }

        [Persistent("serial_number_in")]
        public string SerialNumberIn
        {
            get { return m_serialNumberIn; }
            set { SetPropertyValue("SerialNumberIn", ref m_serialNumberIn, value); }
        }

        [Persistent("serial_number_out")]
        public string SerialNumberOut
        {
            get { return m_serialNumberOut; }
            set { SetPropertyValue("SerialNumberOut", ref m_serialNumberOut, value); }
        }

        [Association("RouteStationRepair-Components")]
        [Persistent("repair_id")]
        public RouteStationRepair Repair
        {
            get { return m_repair; }
            set
            {
                SetPropertyValue("Repair", ref m_repair, value);               
            }
        }

        [Persistent("consumption_id")]
        public int ConsumptionId
        {
            get { return m_consumptionId; }
            set
            {
                if(!IsLoading)
                if (value == default(int) && m_consumptionId > 0)
                    ConsumptionReversed = true;

                SetPropertyValue("ConsumptionId", ref m_consumptionId, value);
            }
        }

        [Persistent("consumption_reversed")]
        public bool ConsumptionReversed
        {
            get { return m_consumptionReversed; }
            private set { SetPropertyValue("ConsumptionReversed", ref m_consumptionReversed, value); } 
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}