using System;
using DevExpress.Xpo;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    [Persistent("material_purchase_line_items")]
    public class MaterialPurchaseLineItem : VPObject, ILineItem
    {
        private Guid m_id;
        private Part m_part;
        private int m_qty;
        private MaterialPurchaseOrder m_materialPurchaseOrder;
        private LineItemStatus m_status = LineItemStatus.Open;
        private DateTime m_eta;
        private string m_customerPo;

        public MaterialPurchaseLineItem(Session session): base(session)
        {           
           UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value);}
        }

        [Persistent("quantity")]
        public int Quantity
        {
            get { return m_qty; }
            set
            {                                      
                if(!IsLoading)
                {
                    SetPropertyValue("Qty", ref m_qty, value);
                    return;
                }
             
                if (State.CanChangeQty(this, value))
                    SetPropertyValue("Quantity", ref m_qty, value);
                
            }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set
            {                
                if(!IsLoading)
                {
                    SetPropertyValue("Part", ref m_part, value);
                    return; 
                }

                if (State.CanChangePart(this, value))
                    SetPropertyValue("Part", ref m_part, value);
            }
        }

        [NonPersistent]
        public int ProcessedQty
        {                               
            get
            {
                if (!IsLoading)
                    return MaterialRepository
                        .GetReceiveQtyForPart(m_materialPurchaseOrder, m_part);

                return 0;
            }            
        }

        [NonPersistent]
        public int OpenQty
        {
            get { return Quantity - ProcessedQty; }
        }

        [NonPersistent]
        public bool AllowDownlevels
        {
            get { return false; }
        }

        [NonPersistent]
        public string PartNumber
        {
            get { return m_part == null ? "" : m_part.PartNumber; }
            set
            {                
                if(value != null)                                    
                     Part = MaterialService.GetPartByPartNumber(Session, value);                                                       
                else                
                    Part = null;               
            }
        }

        [Persistent("line_status_id")]
        public LineItemStatus Status
        {
            get { return m_status; }
            set
            {
                if (IsLoading)
                {
                    SetPropertyValue("Status", ref m_status, value);
                    return;
                }

                if (State.CanChangeStatusTo(value))
                    SetPropertyValue("Status", ref m_status, value);
            }
        }

        [NonPersistent]
        private ILineItemState State
        {
            get { return LineItemState.GetStateForStatus(m_status); }
        }

        [Association("MaterialPO-LineItems")]
        [Persistent("material_po_id")]
        public MaterialPurchaseOrder MaterialPurchaseOrder
        {
            get { return m_materialPurchaseOrder; }
            set { SetPropertyValue("MaterialPurchaseOrder", ref m_materialPurchaseOrder, value); }
        }

        [Persistent("eta")]
        public DateTime Eta
        {
            get { return m_eta; }
            set { SetPropertyValue("Eta", ref m_eta, value); }
        }

        [Persistent("customer_po")]
        public string CustomerPo
        {
            get { return m_customerPo; }
            set { SetPropertyValue("CustomerPo", ref m_customerPo, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            Verify.IsNotNull(m_part,"PartIsRequired", "A valid part number is required","Part");
            Verify.IsTrue(m_qty > 0, "QtyGreaterThanZero", "Qty must be greater than zero", "Qty");
        }

        public void UpdateStatusFromReceipt(int qty)
        {
            if (Quantity == (ProcessedQty + qty))
                Status = LineItemStatus.Closed;
        }

    }
}