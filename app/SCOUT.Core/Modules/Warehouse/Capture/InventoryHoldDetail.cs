using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_inventory_hold_details")]
    public class InventoryHoldDetails : VPLiteObject
    {
        public InventoryHoldDetails(Session session) : base(session)
        {
        }

        [Persistent("Id")]
        [Key(AutoGenerate = false)]
        public Guid Id { get; set; }

        [Persistent("hold_id")]
        public InventoryHold Hold { get; set; }

        [Persistent("hold_status")]
        public string HoldStatus { get; set; }

        [Persistent("hold_reason")]
        public string HoldReason { get; set; }

        [Persistent("multiple_capture_ids")]
        public string MultipleCaptureIds { get; set; }

        [Persistent("lotid")]
        public string LotId { get; set; }

        [Persistent("serial_number")]
        public string SerialNumber { get; set; }

        [Persistent("part_number")]
        public string PartNumber { get; set; }

        [Persistent("model")]
        public string Model { get; set; }

        [Persistent("shopfloorline")]
        public string Shopfloorline { get; set; }

        [Persistent("program")]
        public string Program { get; set; }

        [Persistent("capture_description")]
        public string CaptureDescription { get; set; }

        [Persistent("capture_message")]
        public string CaptureMessage { get; set; }

        [Persistent("capture_priority")]
        public string CapturePriority { get; set; }

        [Persistent("capture_type")]
        public string CaptureType { get; set; }
       
    }
}