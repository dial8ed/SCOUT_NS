using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("materials_part_suppliers")]
    public class MaterialsPartSupplier : VPObject
    {
        private int m_id;
        private MaterialsPart m_materialsPart;
        private string m_supplier;
        private int m_leadTime;
        private string m_notes = "";


        public MaterialsPartSupplier(Session session) : base(session)
        {
        }


        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }
        
        [Persistent("materials_part_id")]
        [Association("MaterialsPart-Suppliers")]
        public MaterialsPart MaterialsPart
        {
            get { return m_materialsPart; }
            set { SetPropertyValue("MaterialsPart", ref m_materialsPart, value); }
        }

        [Persistent("supplier")]
        public string Supplier
        {
            get { return m_supplier; }
            set { SetPropertyValue("Supplier", ref m_supplier, value); }
        }

        [Persistent("lead_time")]
        public int LeadTime
        {
            get { return m_leadTime; }
            set { SetPropertyValue("LeadTime", ref m_leadTime, value); }
        }

        [Persistent("notes")]
        public string Notes
        {
            get { return m_notes; }
            set { SetPropertyValue("Notes", ref m_notes, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}