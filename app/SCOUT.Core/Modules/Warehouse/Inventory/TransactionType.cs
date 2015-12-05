using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("Inventory_Trans_Types")]
    public class TransactionType : VPLiteObject
    {
        private string m_transCode = "";
        private string m_transDescription = "";
        private DateTime m_creationDate;
        private string m_createdBy = "";

        public TransactionType(Session session) : base(session)
        {
        }

        [Persistent("TRANSCODE")]
        [Key(AutoGenerate = false)]
        public string TransCode
        {
            get { return m_transCode; }
            set { m_transCode = value; }
        }

        [Persistent("TRANSDESC")]
        public string TransDescription
        {
            get { return m_transDescription; }
            set { m_transDescription = value; }
        }

        [Persistent("CREATIONDATE")]
        public DateTime CreationDate
        {
            get { return m_creationDate; }
            set { m_creationDate = value; }
        }

        [Persistent("CREATEDBY")]
        public string CreatedBy
        {
            get { return m_createdBy; }
            set { m_createdBy = value; }
        }

        public override string ToString()
        {
            return m_transDescription;
        }
    }
}