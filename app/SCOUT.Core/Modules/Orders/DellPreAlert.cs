using System.Collections.Generic;
using System.Data;
using System.IO;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class DellPreAlert : PreAlert
    {
        private DellPreAlert_Rev1 m_dataset;

        public DellPreAlert()
        {
            m_dataset = new DellPreAlert_Rev1();
        }

        public override DataTable DataTable
        {
            get { return m_dataset.prealert; }
        }


        public override string PartColumnName
        {
            get { return "PART# "; }
        }

        /// <summary>
        /// Returns true if the PPID passed is expected 
        /// on the pre alert associated with the purchase order.
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public override bool SerialIsExpected(PurchaseOrder purchaseOrder, string serialNumber)
        {
            ICollection<DellPreAlertItem> preAlertItems =
                OrderRepository.GetPreAlertItems<DellPreAlertItem>(
                       purchaseOrder);

            if (preAlertItems.Count == 0) return true;

            foreach (DellPreAlertItem item in preAlertItems)
            {
                string preAlertSerial = item.PPID;

                // Parse out the PPID for comparison if the item PPID
                // is formatted as a 2D PPID.                            
                PPID2DParser ppid2DParser = new PPID2DParser(item.PPID);
                if (ppid2DParser.IsParsed)
                    preAlertSerial = ppid2DParser.PPID;

                if (preAlertSerial == serialNumber)
                    return true;
            }
            return false;
        }

        public override string DisplayType
        {
            get { return "Dell Pre Alert"; }
        }

        /// <summary>
        /// Gets a pre alert item by serial number. The serial number for a dell pre 
        /// alert item is the PPID.
        /// </summary>
        /// <param name="order">Purchase order the unit is expected to be received against</param>
        /// <param name="serialNumber">The PPID of the unit being received.</param>
        /// <returns></returns>
        public override IPreAlertItem GetItemBySerialNumber(PurchaseOrder order, string serialNumber)
        {
            // Only match the left 20 of the PPID in case 
            // the PPID in the prealert contains the rev.
            CriteriaOperator op1 =
                CriteriaOperator.Parse("Substring([PPID],0,20)='" + serialNumber + "'");

            BinaryOperator op2 = new BinaryOperator("PurchaseOrder", order);
            GroupOperator criteria = new GroupOperator(op1,op2);

            return Repository
                .Get<DellPreAlertItem>(order.Session)
                .ByCriteria(criteria);
            
        }

        /// <summary>
        /// Fills a dataset from a CSV file path.
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public override bool LoadFromFile(FileInfo fileInfo)
        {
            return base.LoadFromFile(fileInfo, ref m_dataset, "prealert");
        }

        /// <summary>
        /// Maps a series of pre alert items from a data set. 
        /// The pre alert items are associated with the DellPreAlert.PurchaseOrder Session
        /// </summary>
        public override void MapDataSetToPersistedObjects()
        {
            foreach (DellPreAlert_Rev1.prealertRow row in m_dataset.prealert.Rows)
            {
                new DellPreAlertItemMapper(m_purchaseOrder)
                    .MapFrom(row);
            }
        }
    }
}