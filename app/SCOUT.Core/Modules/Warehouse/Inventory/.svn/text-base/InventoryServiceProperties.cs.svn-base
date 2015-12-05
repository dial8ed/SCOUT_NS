using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_inventory_service_properties")]
    public class InventoryServiceProperties : VPLiteObject
    {
        private Guid m_id;
        private InventoryItem m_item;
        private string m_f9Comments = "";
        private string m_serialNumber = "";
        private string m_partNumber = "";

        public InventoryServiceProperties(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("lotid")]
        public InventoryItem Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        [Persistent("f9_comments")]
        public string F9Comments
        {
            get { return m_f9Comments; }
            set { m_f9Comments = value; }
        }

        [Persistent("serial_number")]
        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { m_serialNumber = value; }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return m_partNumber; }
            set { m_partNumber = value; }
        }
    }
}