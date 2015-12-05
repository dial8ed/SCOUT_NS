using System;
using System.Data;

namespace SCOUT.Core.Data
{
    public class DellPreAlertItemMapper : IMapper<DellPreAlert_Rev1.prealertRow, DellPreAlertItem>
    {
        private PurchaseOrder m_po;

        public DellPreAlertItemMapper(PurchaseOrder po)
        {
            m_po = po;
        }

        public DellPreAlertItem MapFrom(DellPreAlert_Rev1.prealertRow input)
        {
            foreach (DataColumn column in input.Table.Columns)
            {
                if (input[column.ColumnName] == DBNull.Value)
                    input[column.ColumnName] = "";
            }
                      
            DellPreAlertItem preAlertItem =Scout.Core.Data.CreateEntity<DellPreAlertItem>(m_po.Session);
            preAlertItem.CartonId = input.CARTON_ID;
            preAlertItem.Cost = (int)input.COST;
            preAlertItem.DpsNumber = input._DPS_;
            preAlertItem.PartNumber = input._PART_;
            preAlertItem.PoNumber = input._PO_;
            preAlertItem.PPID = input.PPID;
            preAlertItem.ProblemDes = input.PROBLEM_DES;
            preAlertItem.PurchaseOrder = m_po;
            preAlertItem.RaNumber = input._RA_;
            preAlertItem.ReasonCode = input.REASON_CODE;
            preAlertItem.RtvNumber = input._RTV_;
            preAlertItem.ScanTime = input.SCAN_TIME;
            preAlertItem.ScnLp = input.SCN_LP;
            preAlertItem.SerialNumber = input._SERIAL_;

            return preAlertItem;
            
        }
    }
}