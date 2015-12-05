using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Tests.Data
{
    public class XpoTestEntity : VPLiteObject
    {
        private int m_id;
        private string m_name;
        private string m_type;

        public XpoTestEntity(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("name")]
        public string Name
        {
            get { return m_name; }
            set { SetPropertyValue("Name", ref m_name, value); }
        }

        [Persistent("type")]
        public string Type
        {
            get { return m_type; }
            set { SetPropertyValue("Type", ref m_type, value); }
        }


    }

    [NonPersistent]
    public class NullXpoTestEntity : XpoTestEntity
    {
        public NullXpoTestEntity(Session session) : base(session)
        {
            Name = "NULL";
            Type = "NULL";
        }
    }
}