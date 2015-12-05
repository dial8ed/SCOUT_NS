using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_repairs")]
    public class RouteStationRepair : VPObject
    {
        private int m_id;
        private RouteStationFailure m_failure;
        private RepairAction m_repair;
        private string m_comments;
        private ServiceCommodityComponent m_component;
        private string m_machineName = "";
        private string m_result = "";
        private bool m_arePartsRequired;

        public RouteStationRepair(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
            Components.ListChanged += (s, e) => m_failure.RaiseRepairChanged();
        }


        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("failure_id")]
        [Association("RouteStationFailure-Repairs")]
        public RouteStationFailure Failure
        {
            get { return m_failure; }
            set { SetPropertyValue("Failure", ref m_failure, value); }
        }

        [Persistent("repair_id")]
        public RepairAction Repair
        {
            get { return m_repair; }
            set { SetPropertyValue("Repair", ref m_repair, value); }
        }

        [Persistent("comments")]
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }

        [Persistent("component_id")]
        public ServiceCommodityComponent Component
        {
            get { return m_component; }
            set { SetPropertyValue("Component", ref m_component, value); }
        }

        [Persistent("result")]
        public string Result
        {
            get { return m_result; }
            set { SetPropertyValue("Result", ref m_result, value); }
        }

        [Persistent("are_parts_req")]
        public bool ArePartsRequired
        {
            get { return m_arePartsRequired; }
            set { SetPropertyValue("ArePartsRequired", ref m_arePartsRequired, value); }
        }


        [Association("RouteStationRepair-Components"), Aggregated]
        public XPCollection<RepairComponent> Components
        {
            get { return GetCollection<RepairComponent>("Components"); }
        }

        [Persistent("machine_name")]
        public string MachineName
        {
            get
            {
                if (m_machineName == "")
                    m_machineName = Security.UserSecurity.CurrentUser.MachineName;
                return m_machineName;
            }
            set { SetPropertyValue("MachineName", ref m_machineName, value); }
        }

        [NonPersistent]
        public InventoryItem Item
        {
            get { return m_failure.Item; }
        }

        [NonPersistent]
        public string ComponentDetails
        {
            get
            {
                return
                    string.Format(
                        "There are [ {0} ] components logged for this repair.",
                        Components.Count.ToString());
            }
        }

        [NonPersistent]
        public bool HasConsumedRepairParts
        {
            get { return Components.Count(c => c.ConsumptionId > 0) > 0; }            
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
         
        }

        internal void RaiseComponentsChanged()
        {
            m_failure.RaiseRepairChanged();
        }

        public bool ContainsReplacement(ReplacementComponentFacts facts)
        {
            foreach (RepairComponent component in Components)
            {
                if (component.PartIn.Id == facts.PartIn.Id &&
                    component.PartOut.Id == facts.PartOut.Id &&
                    component.SerialNumberIn == facts.SerialNumberIn &&
                    component.SerialNumberOut == facts.SerialNumberOut)

                    return true;
            }

            return false;
        }

        public override bool HasChanges()
        {
            var rval = base.HasChanges();
            rval =  (rval | Components.Count((c) => c.HasChanges()) > 0);
            return rval;
        }
    }
}