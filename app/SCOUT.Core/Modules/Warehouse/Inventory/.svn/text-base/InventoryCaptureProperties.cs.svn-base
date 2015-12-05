using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Represents the properties of an inventory item that a capture can 
    /// be created upon.
    /// </summary>
    [Persistent("vw_inventory_capture_properties")]
    public class InventoryCaptureProperties : XPLiteObject
    {        
        public InventoryCaptureProperties(Session session) : base(session)
        {

        }

        [Persistent("id"), Key(AutoGenerate = false)]
        public Guid Id { get; set; }

        [Persistent("RMA")]
        public string RMA { get; set; }

        [Persistent("PO")]
        public string PO { get; set; }

        [Persistent("shopfloorline_id")]
        public Shopfloorline Shopfloorline { get; set; }

        [Persistent("lotid")]
        public InventoryItem Item { get; set; }

        [Persistent("sn")]
        public string SerialNumber { get; set; }

        [Persistent("part_number")]
        public string PartNumber { get; set; }

        [Persistent("ppid")]
        public string PPID { get; set; }

        [Persistent("return_count")]
        public int ReturnCount { get; set; }

        [Persistent("time_in_field")]
        public int TimeInField { get; set; }

        [Persistent("dps")]
        public string DPS { get; set; }

        [Persistent("revision")]
        public string Revision { get; set; }

        [Persistent("receipt_warnings")]
        public string ReceiptWarnings { get; set; }

        [Persistent("xip_return_count")]
        public int XipReturnCount { get; set; }

        [Persistent("model")]
        public string Model { get; set; }

        [Persistent("program")]
        public string Program { get; set; }

        [Persistent("captured")]
        public string Captured { get; set; }

        [Persistent("qty")]
        public int Qty { get; set; }

        [Persistent("return_seed")]
        public int ReturnSeed { get; set; }

        [Persistent("service_commodity")]
        public string ServiceCommodity { get; set; }
        
    }
}