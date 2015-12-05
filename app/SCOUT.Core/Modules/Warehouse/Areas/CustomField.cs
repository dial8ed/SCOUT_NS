using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Custom Field defined by shopfloorline for collection at receipt.
    /// </summary>
    [Persistent("shopfloorline_custom_fields")]
    public class CustomField : VPObject
    {
        private Guid m_id;
        private string m_fieldName;
        private Shopfloorline m_shopfloorline;

        public CustomField(Session session) : base(session)
        {            
        }

        public CustomField(Session session, string fieldName) : this(session)
        {
            FieldName = fieldName;            
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("field_name")]
        public string FieldName
        {
            get { return m_fieldName; }
            set { SetPropertyValue("FieldName", ref m_fieldName, value); }
        }

        [Persistent("shopfloorline-id")]
        [Association("Shopfloorline-CustomFields")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline",ref m_shopfloorline, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }


        public override string ToString()
        {
            return m_fieldName;
        }

        public override bool Equals(object obj)
        {
            CustomField field = obj as CustomField;
            if (field == null)
                return false;

            return field.FieldName.Equals(m_fieldName);

        }
    }
}