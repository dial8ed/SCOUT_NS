using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents the serial number entry of a non-serialized inventory item
    /// Tell me about it! It doesnt make any sense.
    /// </summary>
    [Persistent("ns_lotid_serials")]
    public class NSLotIdSerial : VPLiteObject
    {
        private int m_id;
        private string m_lotId;
        private string m_serialNumber;
        private string m_userName;
        private string m_revision = "";
        private DateTime m_timeStamp;

        public NSLotIdSerial(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("lotid"), Size(16)]
        public string LotId
        {
            get { return m_lotId; }
            set { SetPropertyValue("LotId", ref m_lotId, value); }
        }

        [Persistent("serial_number"), Size(50)]
        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { SetPropertyValue("SerialNumber", ref m_serialNumber, value); }
        }

        [Persistent("user_name")]
        public string UserName
        {
            get { return m_userName; }
            set { SetPropertyValue("UserName", ref m_userName, value); }
        }

        [Persistent("revision")]
        public string Revision
        {
            get { return m_revision;  }
            set { SetPropertyValue("Revision", ref m_revision, value); }
        }

        [Persistent("timestamp")]
        public DateTime TimeStamp
        {
            get { return m_timeStamp; }
            set { SetPropertyValue("TimeStamp", ref m_timeStamp, value); }
        }
    }
}