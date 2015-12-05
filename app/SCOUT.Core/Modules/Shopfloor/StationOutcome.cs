using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("station_outcomes")]
    public class StationOutcome : VPLiteObject
    {
        private int m_id;
        private string m_label;

        public StationOutcome(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("label")]
        public string Label
        {
            get { return m_label; }
            set { SetPropertyValue("Label", ref m_label, value); }
        }


        public override string ToString()
        {
            return m_label;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            return (m_label == ((StationOutcome) obj).Label);
        }
    }
}