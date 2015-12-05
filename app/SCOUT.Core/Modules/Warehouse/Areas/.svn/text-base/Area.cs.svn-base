using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Base class of a Area within the business 
    /// IE: Site, Shopfloorline, Domain, RackLocation
    /// </summary>
    [Persistent("areas")]
    public abstract class Area : VPLiteObject, IArea, IEquatable<Area>
    {
        #region members

        private int m_id = 0;
        private string m_label = "";
        protected Area m_parent = null;
        private AreaStatus m_status;
        private bool m_active;

        #endregion

        #region ctor

        public Area(Session session) : base(session)
        {
           
        }

        #endregion

        #region properties

        [Persistent("area_label")]         
        public virtual string Label
        {
            get { return m_label; }
            set
            {
                m_label = value;
                SetPropertyValue("Label", ref m_label, value);
            }
        }

        [Key(AutoGenerate = true)] 
        [Persistent("area_id")]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("status_id")]
        public AreaStatus Status
        {
            get
            {
                // Inherit status from the parent if the one is not defined.
                if (m_status == null && m_parent != null)
                {
                    return m_parent.Status;
                }

                return m_status;
            }

            set { SetPropertyValue("Status", ref m_status, value); }
        }

        [Persistent("active")]
        public bool Active
        {
            get { return m_active; }
            set { SetPropertyValue("Active", ref m_active, value); }
        }

        public string AreaType
        {
            get { return GetType().Name;  }
        }
        
        [Persistent("area_full_location")]        
        public string FullLocation
        {
            get
            {
                if (m_parent != null)
                {
                    return string.Format("{0}-{1}",
                                         m_parent.FullLocation,
                                         Label);
                }
                else
                {
                    return m_label;
                }
            }
            set { } // do nothing 
        }

        #endregion

        #region IEquatable<Area> Members

        public bool Equals(Area other)
        {
            if(other == null)
                return false;

            return FullLocation == other.FullLocation;
        }

        #region overrides

        public override string ToString()
        {
            return string.Format("{0}", m_label);
        }

        #endregion

        #region methods

        //private void AddSubArea(Area area)
        //{
        //    if (AreaController.Current().SubAreaIsValid(this, area))
        //    {
        //        _subAreas.Add(area);
        //        SetParentArea(area);
        //    }
        //}

        //public void SetParentArea(Area subArea)
        //{
        //    subArea._parent = this;
        //}

        //protected virtual void RemoveSubArea(Area area)
        //{
        //    _subAreas.Remove(area);
        //}

        //public bool HasSubAreas()
        //{
        //    return _subAreas.Count > 0;
        //}

        //public IEnumerable<Area> GetAllSubAreas()
        //{
        //    foreach (Area area in _subAreas)
        //    {
        //        yield return area;
        //    }
        //}

        #endregion

        #endregion

        protected override void OnSaving()
        {
            if(m_label.Length <=0)
            {
                throw new RequiredPropertyMissingValue(this,"Label");
            }
        }
    }
}