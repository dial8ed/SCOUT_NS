using System;
using System.Collections.Generic;
using System.Reflection;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("item_custom_fields")]
    public class ItemCustomFields : VPObject
    {
        private Guid m_id;
        private InventoryItem m_item;        
        private string m_ppid;
        private string m_dps;
        private string m_revision;
        private string m_serviceTag;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public ItemCustomFields(Session session) : base(session)
        {
            
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }


        [Persistent("ppid")]
        public string PPID
        {
            get { return m_ppid; }
            set { SetPropertyValue("PPID", ref m_ppid, value); }
        }

        [Persistent("dps")]
        public string DPS
        {
            get { return m_dps; }
            set { SetPropertyValue("DPS", ref m_dps, value); }
        }

        [Persistent("revision")]
        public string Revision
        {
            get { return m_revision; }
            set { SetPropertyValue("Revision", ref m_revision, value); }
        }


        [Persistent("service_tag")]
        public string ServiceTag
        {
            get { return m_serviceTag; }
            set { SetPropertyValue("ServiceTag", ref m_serviceTag, value); }
        }
        
        public static string[] GetCustomFieldsList()
        {
            return new string[]{"Revision", "DPS", "ServiceTag", "PPID"};
        }

        public Dictionary<string ,string> GetCustomFieldsDictionary()
        {            
            dictionary.Add("Revision", m_revision);
            dictionary.Add("DPS",m_dps);
            dictionary.Add("ServiceTag",m_serviceTag);
            dictionary.Add("PPID",m_ppid);
           
            return dictionary;
        }

        public bool RequiredFieldsAreValid(XPCollection<CustomField> fields)
        {
            foreach (CustomField field in fields)
            {
                PropertyInfo info = GetType().GetProperty(field.FieldName);

                object rval = info.GetValue(this, null);

                if(rval == null)
                    return false;

            }

            return true;
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}