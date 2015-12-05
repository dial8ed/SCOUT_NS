using System;
using System.Data;
using System.IO;
using SCOUT.Core.Modules.Orders;

namespace SCOUT.Core.Data
{
    public class GenericPreAlert : PreAlert
    {
        private GenericPreAlertData m_dataSet;

        public GenericPreAlert()
        {
            m_dataSet = new GenericPreAlertData();
        }


        public GenericPreAlert(GenericPreAlertData dataSet)
        {
            m_dataSet = dataSet;
        }


        public override bool LoadFromFile(FileInfo fileInfo)
        {
            return base.LoadFromFile(fileInfo, ref m_dataSet, "Table");            
        }


        public override DataTable DataTable
        {
            get { return m_dataSet.Table; }
        }


        public override void MapDataSetToPersistedObjects()
        {
            // Not Used
        }


        public override string PartColumnName
        {
            get {return "PartNumber"; }
        }


        public override bool SerialIsExpected(PurchaseOrder purchaseOrder,
                                              string serialNumber)
        {
           // Not Used
            return true;
        }


        public override string DisplayType
        {
            get { return "Generic Pre Alert"; }
        }


        public override IPreAlertItem GetItemBySerialNumber(PurchaseOrder order,
                                                            string number)
        {
            return null;
        }
    }
}