using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// The status of an Area
    /// IE: Finished Goods, Scrap, WIP.
    /// </summary>
    [Persistent("area_statuses")]
    public class AreaStatus : VPLiteObject
    {
        #region fields

        private bool _active = false;
        private int _id = 0;
        private string _status = "";

        #endregion

        #region ctor

        public AreaStatus(Session session) : base(session)
        {
            
        }

        public AreaStatus(Session session, string status, bool active)
            : base(session)
        {
            Status = status;
            Active = active;
        }

        #endregion

        #region overrides

        public override string ToString()
        {
            return _status;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            AreaStatus status = obj as AreaStatus;

            if (status == null)
                return false;

            if(status.Status == _status)
                return true;

            return false;
        }

        #endregion

        #region properties

        [Key(AutoGenerate = true)]
        [Persistent("status_id")]
        public int Id
        {
            get { return _id; }
            set { SetPropertyValue("Id", ref _id, value); }
        }

        [Persistent("status")]
        public string Status
        {
            get { return _status; }
            set { SetPropertyValue("Status", ref _status, value); }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return _active; }
            set { SetPropertyValue("Active", ref _active, value); }
        }

        #endregion
    }
}