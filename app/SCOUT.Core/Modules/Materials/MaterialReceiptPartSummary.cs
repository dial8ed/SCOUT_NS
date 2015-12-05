using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_material_rec_qty_rollup")]
    public class MaterialReceiptPartSummary : VPLiteObject
    {
        private Guid m_id;
        private MaterialPurchaseOrder m_po;
        private Part m_part;
        private int m_receiveQty;


        public MaterialReceiptPartSummary(Session session) : base(session)
        {
        }

        [Persistent("id"), Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("material_po_id")]
        public MaterialPurchaseOrder MaterialPurchaseOrder
        {
            get { return m_po; }
            set { m_po = value; }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { m_part = value; }
        }

        [Persistent("receive_qty")]
        public int ReceiveQty
        {
            get { return m_receiveQty; }
            set { m_receiveQty = value; }
        }
    }
}