using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("materials_parts_xref")]
    public class MaterialsPartXref : VPObject
    {
        private int m_id;
        private MaterialsPart m_materialsPart;
        private string m_xrefPartNumber;        
        private string m_xrefPartNumberAlt;
        private string m_notes;
        

        public MaterialsPartXref(Session session) : base(session)
        {
        }


        [Persistent("id"), Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("materials_part_id")]
        [Association("MaterialsPart-XrefPartNumbers")]
        public MaterialsPart MaterialsPart
        {
            get { return m_materialsPart; }
            set { SetPropertyValue("MaterialsPart", ref m_materialsPart, value); }
        }

        [Persistent("xref_part_number")]
        public string XrefPartNumber
        {
            get { return m_xrefPartNumber; }
            set { SetPropertyValue("XrefPartNumber", ref m_xrefPartNumber, value); }
        }


        [Persistent("xref_part_number_alt")]
        public string XrefPartNumberAlt
        {
            get { return m_xrefPartNumberAlt; }
            set { SetPropertyValue("XrefPartNumberAlt", ref m_xrefPartNumberAlt, value); }
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