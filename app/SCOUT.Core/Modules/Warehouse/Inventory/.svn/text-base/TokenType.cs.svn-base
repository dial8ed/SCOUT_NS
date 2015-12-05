using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vwTOKENTRAVELERS")]
    public class TokenType : VPLiteObject
    {
        private string m_travelerId = "";
        private string m_tokenString = "";

        public TokenType(Session session) : base(session)
        {

        }

        [Persistent("TRAVELERID")]
        [Key(AutoGenerate = true)]
        public string TravelerId
        {
            get { return m_travelerId; }
            set { SetPropertyValue("TravelerId", ref m_travelerId, value);}
        }

        [Persistent("TOKENSTRING")]
        public string TokenString
        {
            get { return m_tokenString; }
            set { SetPropertyValue("TokenString", ref m_tokenString, value); }
        }

        public override string ToString()
        {
            return m_travelerId;
        }
    }
}