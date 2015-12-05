using System;
using System.Data;

namespace SCOUT.Core.Data
{
    public class XipPreAlertItemMapper : IMapper<XIPPreAlertRev1.xip_pre_alertRow, XipPreAlertItem>
    {
        private PurchaseOrder m_po;

        public XipPreAlertItemMapper(PurchaseOrder po)
        {
            m_po = po;
        }

        public XipPreAlertItem MapFrom(XIPPreAlertRev1.xip_pre_alertRow input)
        {
            foreach (DataColumn column in input.Table.Columns)
            {
                if (input[column.ColumnName] == DBNull.Value)
                    input[column.ColumnName] = "";
            }

            XipPreAlertItem item = Scout.Core.Data.CreateEntity<XipPreAlertItem>(m_po.Session);
            item.CustrtnWbn = input.custrtn_wbn;
            item.DateShipped = input.Date_Shipped;
            item.Description = input.description;
            item.DpsNumber = input._DPS__;
            item.F9Comments = input.F9_Comments;
            item.FromStockRoom = input.From_Stock_Room;
            item.Ioc = input.Ioc;
            item.LicensePlate = input.License_Plate;
            item.OEM = input.OEM;
            item.OrderDate = input.Order_Date;
            item.OrderNumber = input._Order__;
            item.OrderTime = input.Order_Time;
            item.Packslip = input.Packslip;
            item.PartNumber = input.Part_Num;
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
            item.Waybill = input.waybill;

            return item;            
        }
    }
}