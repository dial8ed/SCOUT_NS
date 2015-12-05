using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("route_station_failures")]
    public class RouteStationFailure : VPObject
    {
        private string m_comments;
        private ServiceCode m_failCode;
        private int m_id;
        private string m_machineName = "";
        private RouteStationProcess m_stationProcess;
        private string m_lotId = "";
        private RouteStation m_station;
        private StationTaskResult m_taskResult;
        private bool m_isFpErrorCode = false;

        public RouteStationFailure(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
            Repairs.ListChanged += (s, e) => m_stationProcess.RaiseFailuresChanged();
        }


        [Persistent("Id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("station_process_id")]
        [Association("RouteStation-Failures"), Aggregated]
        public RouteStationProcess StationProcess
        {
            get { return m_stationProcess; }
            set
            {
                SetPropertyValue("StationProcess", ref m_stationProcess, value);
                if (!IsLoading && value != null)
                {
                    m_lotId = m_stationProcess.Item.LotId;
                    Station = m_stationProcess.Station;
                }
            }
        }

        [Persistent("fail_code_id")]
        public ServiceCode FailCode
        {
            get { return m_failCode; }
            set { SetPropertyValue("FailCode", ref m_failCode, value); }
        }

        [Persistent("comments")]
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }

        [Persistent("lotid")]
        public string LotId
        {
            get { return m_lotId; }
            set { SetPropertyValue("LotId", ref m_lotId, value); }
        }

        [Persistent("route_station_id")]
        public RouteStation Station
        {
            get { return m_station; }
            set { SetPropertyValue("Station", ref m_station, value); }
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

        [Association("RouteStationFailure-Repairs"), Aggregated]
        public XPCollection<RouteStationRepair> Repairs
        {
            get { return GetCollection<RouteStationRepair>("Repairs"); }
        }

        [NonPersistent]
        public InventoryItem Item
        {
            get { return m_stationProcess.Item; }
        }

        [NonPersistent]
        public string RepairDetails
        {
            get
            {
                return
                    string.Format(
                        "There are [ {0} ] repairs logged for this failure.",
                        Repairs.Count.ToString());
            }
        }

        [Persistent("is_fp_error_code")]        
        public bool IsFpErrorCode
        {
            get { return m_isFpErrorCode; }
            set { SetPropertyValue("IsFpErrorCode", ref m_isFpErrorCode, value); }
        }

        [NonPersistent]
        public bool HasConsumedRepairParts
        {
            get { return Repairs.Count(r => r.HasConsumedRepairParts) > 0; }
        }

            protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_failCode, "FailCodeRequired",
                             "Fail code is required", "FailCode");
        }

        public override bool HasChanges()
        {
            var rval = base.HasChanges();
            return (rval | Repairs.Count((r) => r.HasChanges()) > 0);
        }

        public void RaiseRepairChanged()
        {
            m_stationProcess.RaiseFailuresChanged();            
        }
    }
}