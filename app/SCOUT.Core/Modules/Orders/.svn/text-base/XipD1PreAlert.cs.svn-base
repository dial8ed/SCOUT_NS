using System.Data;
using System.IO;

namespace SCOUT.Core.Data
{
    public class XipD1PreAlert : PreAlert
    {
        private XIPPreAlertRev1 m_dataset;
       
        public XipD1PreAlert()
        {
            m_dataset = new XIPPreAlertRev1();            
        }

        public override bool LoadFromFile(FileInfo fileInfo)
        {
            return base.LoadFromFile(fileInfo, ref m_dataset, "xip_pre_alert");
        }

        public override DataTable DataTable
        {
            get { return m_dataset.xip_pre_alert; }
        }

     
        public override void MapDataSetToPersistedObjects()
        {
            foreach (XIPPreAlertRev1.xip_pre_alertRow row in m_dataset.xip_pre_alert.Rows)
            {
                new XipPreAlertItemMapper(m_purchaseOrder)
                    .MapFrom(row);
            }
        }

        public override string PartColumnName
        {
            get { return "Part Num"; }
        }

        public override bool SerialIsExpected(PurchaseOrder purchaseOrder, string serialNumber)
        {
            return OrderRepository.GetPreAlertItem<XipPreAlertItem>(
                purchaseOrder, serialNumber) != null;           
        }

        public override string DisplayType
        {
            get { return "XIP D1 Pre Alert"; }
        }

        public override IPreAlertItem GetItemBySerialNumber(PurchaseOrder order, string serialNumber)
        {
            return OrderRepository.GetPreAlertItem<XipPreAlertItem>(order, serialNumber);
        }
    }
}