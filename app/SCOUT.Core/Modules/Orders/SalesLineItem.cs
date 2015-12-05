using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Xpo;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    [Persistent("sales_line_items")]
    public class SalesLineItem : VPObject, ILineItem
    {
        #region fields
                
        private int m_id = -1;        
        private Part m_part;
        private int m_quantity = 1;
        private SalesOrder m_salesOrder;        
        private ILineItemState m_state = new LineItemOpen();
        private LineItemStatus m_status = LineItemStatus.Open;
        private decimal m_unitCost;
        private IShippingLineStatusManager m_lineStatusManager = new ScheduledLineStatusUpdater();
        private IShippingOpenQtyManager m_openQtyManager = new ScheduledShippingOpenQtyManager();
        private Func<SalesLineItem, int> m_processedQtyLocator;
        
        #endregion

        #region .ctor

        public SalesLineItem(Session session) : base(session)
        {
            this.Changed +=InternalPropertyChangedHandler;
        }

        private void InternalPropertyChangedHandler(object sender, ObjectChangeEventArgs e)
        {
            if (e.PropertyName == "Quantity")
                GetDefaultSchedule().Qty = (int) e.NewValue;
                
        }

        #endregion

        #region properties

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [NonPersistent]
        public int PartId
        {
            get { return m_part == null ? 0 : m_part.Id; }
        }

        [NonPersistent]
        public string PartNumber
        {
            get { return (m_part != null) ? m_part.PartNumber : ""; }
            set
            {
                Part part = Part.GetPartByPartNumber(Session, value);
                if (part != null)
                {
                    Part = part;
                }
            }
        }

        [NonPersistent]
        public string PartDescription
        {
            get { return (m_part != null) ? m_part.Description : ""; }
        }

        [Association("SalesOrder-CartItems"), Aggregated]
        [Persistent("sales_order_id")]
        public SalesOrder SalesOrder
        {
            get { return m_salesOrder; }
            set { SetPropertyValue("SalesOrder", ref m_salesOrder, value); }
        }

        [Persistent("unit_cost")]
        public decimal UnitCost
        {
            get { return m_unitCost; }
            set { SetPropertyValue("UnitCost", ref m_unitCost, value); }
        }

        [NonPersistent]
        public decimal ExtendedCost
        {
            get
            {
                return (m_salesOrder.SalesTax > 0
                            ? (((m_unitCost*m_quantity)*m_salesOrder.SalesTax) + m_unitCost*m_quantity)
                            : (m_unitCost*m_quantity));
            }
        }

        [Persistent("line_status_id")]
        public LineItemStatus Status
        {
            get { return m_status; }
            set
            {
                if(!IsLoading && !State.CanChangeStatusTo(value))
                    return;
 
                SetPropertyValue("Status", ref m_status, value);
            }
        }


        [NonPersistent]
        private ILineItemState State
        {
            get { return LineItemState.GetStateForStatus(m_status); }
        }

        [NonPersistent]
        public Func<SalesLineItem, int> ProcessedQtyLocator
        {
            get
            {
                // Default
                if(m_processedQtyLocator == null)
                    return (sli) => OrderService.GetShipQtyForLine(this);

                return m_processedQtyLocator;
            }
        }

        public int ProcessedQty
        {
            get
            {
                if (!IsLoading)
                    return ProcessedQtyLocator.Invoke(this);                    
                return 0;
            }
        }

        public bool AllowDownlevels
        {
            get { return false; }
        }
        
        [NonPersistent]
        public virtual int OpenQty
        {
            get
            {
                return m_openQtyManager.GetOpenQty(this);                                
            }
        }


        [Persistent("quantity"), DefaultValue(1)]
        public virtual int Quantity
        {
            get { return m_quantity; }
            set
            {
                if (IsLoading)
                {
                    SetPropertyValue("Quantity", ref m_quantity, value);
                    return;
                }

                if (State.CanChangeQty(this, value))
                {
                    SetPropertyValue("Quantity", ref m_quantity, value);
                }
                    
            }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set
            {
                if (IsLoading | m_part == null)
                {
                    SetPropertyValue("Part", ref m_part, value);
                    return;
                }

                if (State.CanChangePart(this, value))
                    SetPropertyValue("Part", ref m_part, value);
            }
        }

        [Association("LineItem-Schedules")]
        public XPCollection<SalesLineItemSchedule> Schedules
        {
            get { return GetCollection<SalesLineItemSchedule>("Schedules"); }
        }

        #endregion

        #region base overrides

        protected override void ValidateRules(BrokenRules Verify)
        {
            if (!IsDeleted)
                Verify.IsNotNull(m_part,
                                 "INVALIDLINEITEM",
                                 "Invalid Part Number ",
                                 "PartId");

            if (!IsDeleted)
                if (m_part != null)
                {
                    Verify.IsTrue(m_part.IsShippable,
                                  "SOINOSHIPPART", "Part is not shippable.", "PartId");
                }
        }

        protected override void BeginEdit()
        {
        }

        protected override void CancelEdit()
        {
        }

        protected override void EndEdit()
        {
        }

        #endregion

        #region system.object overrides

        public override bool Equals(object obj)
        {
            SalesLineItem salesLineItem = obj as SalesLineItem;

            if (salesLineItem != null)
            {
                return
                    (salesLineItem.Part.Equals(Part));
            }

            return false;
        }

        #endregion

        public void UpdateStatusFromShipment(int qty)
        {
            Status = m_lineStatusManager.GetStatusAfterShipment(this, qty);
        }

        public void UpdateStatusFromUnShipment(int qty)
        {
            Status = m_lineStatusManager.GetStatusAfterUnship(this, qty);
        }

        public SalesLineItemSchedule GetDefaultSchedule()
        {
            return Schedules.FirstOrDefault(s => s.IsDefault);
        }


        public void CreateDefaults()
        {            
            Schedules.Add(new SalesLineItemSchedule((Session)Session)
                              {
                                  LineItem = this,ScheduledDate  = DateTime.Now, Qty = 0, IsDefault = true
                              });
        }
    }
}