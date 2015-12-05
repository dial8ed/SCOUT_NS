using System.Data;
using System.IO;

namespace SCOUT.Core.Data
{
    public class XipGencoPreAlert : PreAlert
    {
        private XipGencoPreAlertSchemaRev1 m_dataset;

        public XipGencoPreAlert()
        {
            m_dataset = new XipGencoPreAlertSchemaRev1();
        }
  
        public override bool LoadFromFile(FileInfo fileInfo)
        {
            return base.LoadFromFile(fileInfo, ref m_dataset, "xip_genco_pre_alert");
        }

        public override DataTable DataTable
        {
            get { return m_dataset.xip_genco_pre_alert; }
        }

        public override void MapDataSetToPersistedObjects()
        {
            foreach (XipGencoPreAlertSchemaRev1.xip_genco_pre_alertRow row in m_dataset.xip_genco_pre_alert.Rows)
            {
                new XipGencoPreAlertItemMapper(m_purchaseOrder)
                    .MapFrom(row);
            }           
        }

        public override string PartColumnName
        {
            get { return "Part Number"; }
        }

        public override bool SerialIsExpected(PurchaseOrder purchaseOrder, string serialNumber)
        {
            return OrderRepository.GetPreAlertItem<XipPreAlertItem>(
                purchaseOrder, serialNumber) != null;    
        }

        public override string DisplayType
        {
            get { return "XIP Genco Pre Alert"; }
        }

        public override IPreAlertItem GetItemBySerialNumber(PurchaseOrder order, string serialNumber)
        {
            return OrderRepository.GetPreAlertItem<XipPreAlertItem>(order, serialNumber);
        }
    }
}