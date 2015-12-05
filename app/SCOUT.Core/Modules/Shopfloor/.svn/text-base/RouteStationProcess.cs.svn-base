using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_processes")]
    public class RouteStationProcess : VPObject
    {
        private int m_id;
        private InventoryItem m_item;
        private RouteStation m_nextStation;
        private RouteStationProcess m_prevProcess;
        private bool m_routingEnabled;
        private RouteStation m_station;
        private StationOutcome m_stationOutcome;
        private RouteStationConfiguration m_configuration;
        private string m_shopfloorProgram;

        public event Action<RepairComponent> RepairComponentAdded;

        public RouteStationProcess(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
            Failures.DeleteObjectOnRemove = true;

            Failures.ListChanged += Failures_ListChanged;            
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("route_station_id")]
        public RouteStation Station
        {
            get { return m_station; }
            set { SetPropertyValue("Station", ref m_station, value); }
        }

        [Persistent("prev_process_id")]
        public RouteStationProcess PrevProcess
        {
            get { return m_prevProcess; }
            set { SetPropertyValue("PrevProcess", ref m_prevProcess, value); }
        }

        [Persistent("outcome_id")]
        public StationOutcome StationOutcome
        {
            get { return m_stationOutcome; }
            set { SetPropertyValue("StationOutcome", ref m_stationOutcome, value); }
        }

        [Persistent("lotid")]
        [Association("InventoryItem-Processes")]
        [Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("Item", ref m_item, value); }
        }

        [Persistent("next_station_id")]
        public RouteStation NextStation
        {
            get { return m_nextStation; }
            set { SetPropertyValue("NextStation", ref m_nextStation, value); }
        }

        [NonPersistent]
        public string NextStationName
        {
            get { return m_nextStation == null ? "" : m_nextStation.Name; }
        }

        [Persistent("routing_enabled")]
        public bool RoutingEnabled
        {
            get { return m_routingEnabled; }
            set { SetPropertyValue("RoutingEnabled", ref m_routingEnabled, value); }
        }

        [Persistent("service_route_id")]
        public ServiceRoute ServiceRoute
        {
            get { return m_station.ServiceRoute; }
            set { }
        }

        [Persistent("shopfloor_program")]
        public string ShopfloorProgram
        {
            get { return m_shopfloorProgram; }
            set { SetPropertyValue("ShopfloorProgram", ref m_shopfloorProgram, value); }
        }

        //[Persistent("route_process_id")]
        //public RouteProcess RouteProcess
        //{
        //    get { return m_routeProcess; }
        //    set { SetPropertyValue("RouteProcess", ref m_routeProcess, value); }
        //}

        [NonPersistent]
        public RouteStationConfiguration Configuration
        {
            get { return m_configuration; }
        }

        [Association("RouteStation-Results")]
        public XPCollection<RouteStationResult> Results
        {
            get { return GetCollection<RouteStationResult>("Results"); }
        }

        [Association("RouteStation-Failures"), Aggregated]
        public XPCollection<RouteStationFailure> Failures
        {
            get { return GetCollection<RouteStationFailure>("Failures"); }
        }


        public ICollection<RouteStationFailure> AllProcessFailures
        {
            get
            {
                BinaryOperator criteria = new BinaryOperator("LotId",
                                                             m_item.LotId);

                return Repository
                    .GetList<RouteStationFailure>(Session)
                    .ByCriteria(criteria);
            }
        }


        public bool HasDuplicateOpenFailures()
        {
            Dictionary<string, int> failureRollup =
                new Dictionary<string, int>();

            // Check if a duplicate open failure exists. Return true if so.
            foreach (RouteStationFailure failure in Failures)
            {
                string failCodeKey = failure.FailCode.Code;
                if (failureRollup.ContainsKey(failure.FailCode.Code))
                {
                    return true;
                }

                // Add the open failure to the dictionary
                if (failure.Repairs.Count == 0)
                    failureRollup.Add(failCodeKey, 1);
            }

            return false;
        }

        public bool HasOpenFailures()
        {
            foreach (RouteStationFailure failure in AllProcessFailures)
            {
                if (failure.Repairs.Count == 0)
                    return true;
            }

            return false;
        }

        public void SortResultsBySeqNo()
        {
            SortingCollection sortCollection = new SortingCollection();
            sortCollection.Add(new SortProperty("Step.SeqNo",
                                                SortingDirection.Ascending));
            Results.Sorting = sortCollection;
        }

        public void MapStepsToResults(RouteStationConfiguration config)
        {
            m_configuration = config;

            foreach (RouteStationStep step in config.ActiveSteps)
            {
                bool found = false;

                foreach (RouteStationResult result in Results)
                {
                    if (result.Step.Equals(step))
                        found = true;
                }

                if (!found)
                {
                    if (!string.IsNullOrEmpty(m_item.ShopfloorProgram)
                        && !step.ContainsProgramSpecification(m_item.ShopfloorProgram))
                    {
                        continue;
                    }

                    if (!step.HasRequiredConditions(m_item.ShopfloorConditions))
                    {
                        continue;
                    }

                    Results.Add(new RouteStationResultMapper().MapFrom(step));
                    Results[Results.Count - 1].Item = Item;
                }
            }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsTrue(FailuresListIsValid, "FailuresMustBeValid",
                          "There are invalid failures. Please correct before saving.",
                          "FailuresListIsValid");
        }


        private bool FailuresListIsValid
        {
            get
            {
                foreach (RouteStationFailure failure in Failures)
                {
                    if (!string.IsNullOrEmpty(failure.Error))
                        return false;
                }

                return true;
            }
        }


        public bool ValidRequiredFields()
        {
            foreach (RouteStationResult result in Results)
            {
                if (result.Step.Required && result.Result.Length == 0)
                    return false;
            }

            return true;
        }

        public RouteStationFailure AddFailure(ServiceCode code, string comments)
        {
            RouteStationFailure failure = Scout.Core.Data.CreateEntity<RouteStationFailure>(Session);
            failure.FailCode = code;
            failure.Comments = comments;
            Failures.Add(failure);

            return failure;
        }

        public string GetResult(string step)
        {
            foreach (RouteStationResult r in Results)
            {
                if (r.Step.DisplayPrompt == step)
                    return r.Result;
            }

            return "";
        }

        public void ChangeFpErrorCodeOwner(RouteStationFailure failure)
        {
            var currentFpHolder = AllProcessFailures.FirstOrDefault(f => f.IsFpErrorCode);

            if (currentFpHolder == null)
                currentFpHolder = Failures.FirstOrDefault(f => f.IsFpErrorCode);

            if (currentFpHolder != null)
                currentFpHolder.IsFpErrorCode = false;

            failure.IsFpErrorCode = true;
        }

        private void Failures_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (AllProcessFailures.FirstOrDefault(f => f.IsFpErrorCode) == null)
                {
                    ChangeFpErrorCodeOwner(AllProcessFailures.Take(1).ToArray()[0]);
                    return;
                }
            }

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                if (AllProcessFailures.Count == 0 && Failures.Count == 1)
                {
                    Failures[0].IsFpErrorCode = true;
                }
            }                                   
        }

        public bool HasNewMaterialsConsumed()
        {
            var query = from f in Failures
                        from r in f.Repairs
                        from c in r.Components
                        where c.Repair.HasChanges() && c.ConsumptionId != default(int)
                        select c;
                                                 
            var list = query.ToList();

            return list.Count() > 0;

        }

        public void RaiseFailuresChanged()
        {
            RaisePropertyChangedEvent("Failures");
        }

        public override bool HasChanges()
        {
            var rval = base.HasChanges();
            rval = (rval | Failures.Count((f) => f.HasChanges()) > 0);
            return rval;
        }

        public bool HasReversedMaterialsConsumed()
        {
            var query = from f in Failures
                        from r in f.Repairs
                        from c in r.Components
                        where c.Repair.HasChanges() && c.ConsumptionReversed
                        select c;

            var list = query.ToList();

            return list.Count() > 0;
        }
    }
}