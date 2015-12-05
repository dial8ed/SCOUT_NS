using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_receiving_qtys_raw")]
    public class ReceivingPartSummary : VPLiteObject{
    
        private Guid m_id;
        private PurchaseOrder m_purchaseOrder;
        private Order m_order;
        private Part m_part;
        private int m_qty;        

        public ReceivingPartSummary(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = false)]        
        public Guid Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [Persistent("contract_id")]
        public PurchaseOrder PurchaseOrder
        {
            get { return m_purchaseOrder; }
            set { m_purchaseOrder = value; }
        }

        [Persistent("order_id")]
        public Order Order
        {
            get { return m_order; }
            set { m_order = value; }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { m_part = value; }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { m_qty = value; }
        }
    }
}