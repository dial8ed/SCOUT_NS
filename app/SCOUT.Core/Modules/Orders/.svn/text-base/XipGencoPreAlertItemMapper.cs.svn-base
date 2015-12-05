using System;
using System.Data;

namespace SCOUT.Core.Data
{
    public class XipGencoPreAlertItemMapper : IMapper<XipGencoPreAlertSchemaRev1.xip_genco_pre_alertRow, XipPreAlertItem>
    {
        private PurchaseOrder m_po;

        public XipGencoPreAlertItemMapper(PurchaseOrder po)
        {
            m_po = po;
        }

        public XipPreAlertItem MapFrom(XipGencoPreAlertSchemaRev1.xip_genco_pre_alertRow input)
        {
            foreach (DataColumn column in input.Table.Columns)
            {
                if (input[column.ColumnName] == DBNull.Value)
                    input[column.ColumnName] = "";
            }

            XipPreAlertItem item =Scout.Core.Data.CreateEntity<XipPreAlertItem>(m_po.Session);
            item.CustrtnWbn = "";
            item.DateShipped = input.Date_Shipped;
            item.Description = "";
            item.DpsNumber = input._DPS_;
            item.F9Comments = input.F9_Comments;
            item.FromStockRoom = input.From_Stock_Room;
            item.Ioc = "";
            item.LicensePlate = "";
            item.OEM = "";
            item.OrderDate = "";
            item.OrderNumber = "";
            item.OrderTime = "";
            item.Packslip = input.Packslip;
            item.PartNumber = input.Part_Number;
            item.PPID = input.PPID;
            item.PurchaseOrder = m_po;
            item.RMA = input.RMA;
            item.SerialNumber = input.Service_Tag;
            item.ShipCode = input.Ship_Code;
            item.ShipmentReferenceNumber = input.Shipment_Reference_Number;           
            item.ShippedBy = input.Shipped_By;
            item.ShippedTo = input.Shipped_To;
            item.TimeShipped = input.Time_Shipped;
            item.UnitCost = input.Unit_Cost;
            item.Waybill = "";
            
            return item;            
        }
    }
}