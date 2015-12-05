using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DevExpress.Xpo;
using System.Reflection;
using DevExpress.Xpo.Metadata;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Validated Persistant Object.
    /// </summary>
    /// <remarks>
    /// Provides a business logic layer to the DevExpress XPObject class.
    /// </remarks>
    [NonPersistent]
    public abstract class VPObject : VPLiteObject,
                                     IDataErrorInfo
    {
        #region Member Variables

        [NonPersistent] private bool m_isDirty = false;

        [NonPersistent] private bool m_isNew = true;

        [NonPersistent] private UserTracking m_userTracking = new UserTracking();

        #endregion

        #region Construction/Destruction

 
        protected VPObject(Session session)
            : base(session)
        {
            Changed += (s, e) => RaisePropertyChangedEvent(e.PropertyName);      
        }

        #endregion

        #region Properties

        [NonPersistent]
        [Bindable(true)]
        [Browsable(false)]        
        public bool IsDirty
        {
            get { return m_isDirty; }
        }

        [NonPersistent]
        [Bindable(true)]
        [Browsable(false)]        
        public bool IsNew
        {
            get { return m_isNew; }
        }

        [Persistent("created_by")]
        [ReadOnly(true)]        
        public string CreatedBy
        {
            get { return m_userTracking.CreatedBy; }
            set
            {
                SetPropertyValue("CreatedBy", value);
                m_userTracking.CreatedBy = value;
            }
        }

        [Persistent("create_date")]
        [ReadOnly(true)]        
        public DateTime CreatedDate
        {
            get { return m_userTracking.CreatedDate; }
            set
            {
                SetPropertyValue("CreatedDate", value);
                m_userTracking.CreatedDate = value;
            }
        }

        [Persistent("updated_by")]
        [ReadOnly(true)]        
        public string UpdatedBy
        {
            get { return m_userTracking.UpdatedBy; }
            set
            {
                SetPropertyValue("UpdatedBy", value);
                m_userTracking.UpdatedBy = value;
            }
        }

        [Persistent("last_update")]
        [ReadOnly(true)]        
        public DateTime LastUpdated
        {
            get { return m_userTracking.LastUpdated; }
            set
            {
                SetPropertyValue("LastUpdated", value);
                m_userTracking.LastUpdated = value;
            }
        }

        [NonPersistent]
        public UserTracking UserTracking
        {
            get { return m_userTracking; }                  
        }

        #endregion
        
        #region Rule Validation

        /// <summary>
        /// Returns a list of rules that have been broken.
        /// </summary>
        /// <returns></returns>
        public List<BrokenRule> GetBrokenRules()
        {
            BrokenRules rules = new BrokenRules();
            ValidateRules(rules);
            return rules;
        }

        /// <summary>
        /// Validates any business logic rules.
        /// </summary>
        protected abstract void ValidateRules(BrokenRules Verify);

        #endregion

        #region IDataErrorInfo Members

        [Bindable(false), Browsable(false)]
        public string Error
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;

                foreach (BrokenRule rule in GetBrokenRules())
                {
                    if (i > 0)
                        sb.Append("\n");

                    sb.Append("- ");
                    sb.Append(rule.Description);

                    ++i;
                }

                return sb.ToString();
            }
        }

        public string this[string columnName]
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int cnt = 0;

                foreach (BrokenRule rule in GetBrokenRules())
                {
                    if (rule.Column != columnName)
                        continue;

                    if (cnt > 0)
                        sb.Append("\n");

                    sb.Append("- ");
                    sb.Append(rule.Description);
                    ++cnt;
                }

                return sb.ToString();
            }
        }

        #endregion

        #region Events

        protected override void OnSaving()
        {
            List<BrokenRule> m_brokenRules = GetBrokenRules();

            if (m_brokenRules.Count > 0)
            {
                //CancelEdit();
                throw new BrokenRuleException(this, m_brokenRules);
            }

            if (IsDirty)
            {
                m_userTracking.SetUpdateInfo();

                if (IsNew)
                {
                    SetPropertyValue("CreatedBy", m_userTracking.CreatedBy);
                    SetPropertyValue("CreatedDate", m_userTracking.CreatedDate);
                }

                SetPropertyValue("UpdatedBy", m_userTracking.UpdatedBy);
                SetPropertyValue("LastUpdated", m_userTracking.LastUpdated);
            }

            base.OnSaving();
        }

        protected override void OnSaved()
        {
            base.OnSaved();

            m_isDirty = false;
            m_isNew = false;
        }

        protected override void OnChanged(string propertyName,
                                          object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            if(!IsLoading)
                m_isDirty = true;
        }

        #endregion


        public virtual bool HasChanges()
        {
            if (this.Session == null) return false;

            foreach (var obj in Session.GetObjectsToSave())
            {
                if (this.Equals(obj))
                    return true;
            }

            return false;
        }

    }
}