using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("part_attribute_values")]
    public class PartAttributeValues : VPObject
    {
        private int m_id;
        private string m_attr1; 
        private string m_attr2;
        private string m_attr3;
        private string m_attr4;
        private string m_attr5;
        private string m_attr6;
        private string m_attr7;
        private string m_attr8;
        private string m_attr9;
        private string m_attr10;
        private Dictionary<string, string> m_attributeNameList;

        private Part m_part;
        private PartAttributesHeader m_header;


        public PartAttributeValues(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
            BuildAttributeDictionary();
        }

        private void BuildAttributeDictionary()
        {
            m_attributeNameList = new Dictionary<string, string>();
            m_attributeNameList.Add("Attr1Label", "Attr1");
            m_attributeNameList.Add("Attr2Label", "Attr2");
            m_attributeNameList.Add("Attr3Label", "Attr3");
            m_attributeNameList.Add("Attr4Label", "Attr4");
            m_attributeNameList.Add("Attr5Label", "Attr5");
            m_attributeNameList.Add("Attr6Label", "Attr6");
            m_attributeNameList.Add("Attr7Label", "Attr7");
            m_attributeNameList.Add("Attr8Label", "Attr8");
            m_attributeNameList.Add("Attr9Label", "Attr9");
            m_attributeNameList.Add("Attr10Label", "Attr10");
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("header_id")]
        public PartAttributesHeader Header
        {
            get { return m_header; }
            set { SetPropertyValue("Header", ref m_header, value); }
        }


        [Persistent("attr_1")]
        public string Attr1
        {
            get { return m_attr1; }
            set { SetPropertyValue("Attr1", ref m_attr1, value); }
        }

        [Persistent("attr_2")]
        public string Attr2
        {
            get { return m_attr2; }
            set { SetPropertyValue("Attr2", ref m_attr2, value); }
        }

        [Persistent("attr_3")]
        public string Attr3
        {
            get { return m_attr3; }
            set { SetPropertyValue("Attr3", ref m_attr3, value); }
        }

        [Persistent("attr_4")]
        public string Attr4
        {
            get { return m_attr4; }
            set { SetPropertyValue("Attr4", ref m_attr4, value); }
        }

        [Persistent("attr_5")]
        public string Attr5
        {
            get { return m_attr5; }
            set { SetPropertyValue("Attr5", ref m_attr5, value); }
        }

        [Persistent("attr_6")]
        public string Attr6
        {
            get { return m_attr6; }
            set { SetPropertyValue("Attr6", ref m_attr6, value); }
        }

        [Persistent("attr_7")]
        public string Attr7
        {
            get { return m_attr7; }
            set { SetPropertyValue("Attr7", ref m_attr7, value); }
        }

        [Persistent("attr_8")]
        public string Attr8
        {
            get { return m_attr8; }
            set { SetPropertyValue("Attr8", ref m_attr8, value); }
        }

        [Persistent("attr_9")]
        public string Attr9
        {
            get { return m_attr9; }
            set { SetPropertyValue("Attr9", ref m_attr9, value); }
        }

        [Persistent("attr_10")]
        public string Attr10
        {
            get { return m_attr10; }
            set { SetPropertyValue("Attr10", ref m_attr10, value); }
        }

        [NonPersistent]
        public string Attr1Label
        {
            get { return m_header == null ? "" : m_header.Attr1; }
        }

        [NonPersistent]
        public string Attr2Label
        {
            get { return m_header == null ? "" : m_header.Attr2; }
        }

        [NonPersistent]
        public string Attr3Label
        {
            get { return m_header == null ? "" : m_header.Attr3; }
        }

        [NonPersistent]
        public string Attr4Label
        {
            get { return m_header == null ? "" : m_header.Attr4; }
        }

        [NonPersistent]
        public string Attr5Label
        {
            get { return m_header == null ? "" : m_header.Attr5; }
        }

        [NonPersistent]
        public string Attr6Label
        {
            get { return m_header == null ? "" : m_header.Attr6; }
        }

        [NonPersistent]
        public string Attr7Label
        {
            get { return m_header == null ? "" : m_header.Attr7; }
        }

        [NonPersistent]
        public string Attr8Label
        {
            get { return m_header == null ? "" : m_header.Attr8; }
        }

        [NonPersistent]
        public string Attr9Label
        {
            get { return m_header == null ? "" : m_header.Attr9; }
        }

        [NonPersistent]
        public string Attr10Label
        {
            get { return m_header == null ? "" : m_header.Attr10; }
        }

        public string GetValueForAttribute(string attribute)
        {
            foreach (KeyValuePair<string, string> pair in m_attributeNameList)
            {
                if (Reflection.GetPropertyValue(this, pair.Key) == attribute)
                    return Reflection.GetPropertyValue(this, pair.Value);
            }

            throw new KeyNotFoundException("Part Attribute -" + attribute + "- cannot be found.");               
        }  

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}