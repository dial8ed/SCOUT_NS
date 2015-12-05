using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("STKRTNTRACKING")]
    public class SerializedUnit : VPLiteObject
    {
        private InventoryItem m_item;
        private string m_initIdent;
        private string m_endIdent;
        private int m_returnSeed;
        private DateTime m_returnDate;
        private DateTime m_returnEndDate;
        private TokenType m_tokenType;
        private string m_tokenTraveler = "";
        private DateTime m_tokenCreateDate;
        private string m_tokenCreatedBy;
        private DateTime m_tokenLastUpdate;
        private string m_tokenUpdatedBy;
        private ReturnType m_returnType = ReturnType.NotDefined;
        private int m_returnTypeCount = 0;

        public SerializedUnit(Session session) : base(session)
        {
        }


        [Key(AutoGenerate = false)]
        [Persistent("LOTID")]
        [Size(16)]
        public InventoryItem Item
        {
            get { return m_item; }
            set { SetPropertyValue("LotId", ref m_item, value); }
        }

        [Persistent("INITIDENT")]
        public string InitIdent
        {
            get { return m_initIdent; }
            set { SetPropertyValue("InitIdent", ref m_initIdent, value); }
        }

        [Persistent("ENDIDENT")]
        public string EndIdent
        {
            get { return m_endIdent; }
            set { SetPropertyValue("EndIdent", ref m_endIdent, value); }
        }

        [Persistent("RTNSEED")]
        public int ReturnSeed
        {
            get { return m_returnSeed; }
            set { SetPropertyValue("ReturnSeed", ref m_returnSeed, value); }
        }

        [Persistent("RTNDATE")]
        public DateTime ReturnDate
        {
            get { return m_returnDate; }
            set { SetPropertyValue("ReturnDate", ref m_returnDate, value); }
        }

        [Persistent("RTNENDDATE")]
        public DateTime ReturnEndDate
        {
            get { return m_returnEndDate; }
            set { SetPropertyValue("ReturnEndDate", ref m_returnEndDate , value); }
        }

        [Persistent("TOKENTYPE")]
        [Size(100)]
        [NoForeignKey]
        public TokenType TokenType
        {
            get { return m_tokenType; }
            set { SetPropertyValue("TokenType", ref m_tokenType, value); }
        }

        [Persistent("TOKENTRAVELER")]
        [Size(SizeAttribute.Unlimited)]
        public string TokenTraveler
        {
            get { return m_tokenTraveler; }
            set
            {
                if (value == null)
                    value = "";

                if (m_tokenTraveler.Length == 0 && value.Length > 0)
                {
                    m_tokenCreateDate = DateTime.Now;
                    m_tokenCreatedBy = Security.UserSecurity.CurrentUser.Login;
                }

                if (m_tokenTraveler.Length > 0 && !m_tokenTraveler.Equals(value))
                {
                    m_tokenLastUpdate = DateTime.Now;
                    m_tokenUpdatedBy = Security.UserSecurity.CurrentUser.Login;
                }
                    
                SetPropertyValue("TokenTraveler", ref m_tokenTraveler, value);
                
            }
        }

        [Persistent("TOKENCREATEDATE")]
        public DateTime TokenCreateDate
        {
            get { return m_tokenCreateDate; }
            set { SetPropertyValue("TokenCreateDate", ref m_tokenCreateDate, value); }
        }

        [Persistent("TOKENCREATEDBY")]
        public string TokenCreatedBy
        {
            get { return m_tokenCreatedBy; }
            set { SetPropertyValue("TokenCreateDate", ref m_tokenCreatedBy, value); }
        }

        [Persistent("TOKENLASTUPDATE")]
        public DateTime TokenLastUpdate
        {
            get { return m_tokenLastUpdate; }
            set { SetPropertyValue("TokenLastUpdate", ref m_tokenLastUpdate, value); }
        }

        [Persistent("TOKENUPDATEDBY")]
        public string TokenUpdatedBy
        {
            get { return m_tokenUpdatedBy; }
            set { SetPropertyValue("TokenUpdatedBy", ref m_tokenUpdatedBy, value); }
        }


        [Persistent("return_type")]
        public ReturnType ReturnType
        {
            get { return m_returnType; }
            set { SetPropertyValue("ReturnType", ref m_returnType, value); }
        }


        [Persistent("return_type_count")]
        public int ReturnTypeCount
        {
            get { return m_returnTypeCount; }
            set { SetPropertyValue("ReturnTypeCount", ref m_returnTypeCount, value); }
        }
    }
}