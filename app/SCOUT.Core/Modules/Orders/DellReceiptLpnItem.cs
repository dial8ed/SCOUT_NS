using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_open_dell_receipt_lpn_items")]
    public class DellReceiptLpnItem : XPLiteObject
    {
        public DellReceiptLpnItem(Session session) : base(session)
        {
        }

        [Persistent("id"), Key(AutoGenerate = false)]
        public Guid Id { get; set; }

        [Persistent("part_number")]
        public string PartNumber { get; set; }

        [Persistent("ppid")]
        public string Ppid { get; set; }

        [Persistent("dps_number")]
        public string Dps { get; set; }

        [Persistent("lpn")]
        public string Lpn { get; set; }


        [NonPersistent]
        public string Revision { get; set; }
                
        [NonPersistent]
        public string SerialNumber
        {
            get
            {
                PPID2DParser parser = new PPID2DParser(Ppid);
                if (parser.IsParsed)
                {
                    Revision = parser.Revision;
                    Ppid = parser.PPID;
                    return parser.SN;
                }
                    
                return Ppid;
            }            
        }
    }


    [Persistent("vw_open_dell_shipment_lpn_items")]
    public class DellShipmentLpnItem : XPLiteObject
    {
        public DellShipmentLpnItem(Session session) : base(session)
        {
        }

        [Persistent("id"), Key(AutoGenerate = false)]
        public Guid Id { get; set; }

        [Persistent("lpn")]
        public string Lpn { get; set; }     
    }
}