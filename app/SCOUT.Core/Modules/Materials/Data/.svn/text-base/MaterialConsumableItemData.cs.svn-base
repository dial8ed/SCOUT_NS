using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("material_consumable_items")]    
    [OptimisticLocking(true)]
    public partial class MaterialConsumableItem : VPObject, IMaterialItem
    {
        private Guid m_id;
        private Part m_part;
        private Shopfloorline m_shopfloorline;
        private int m_qty;

        public MaterialConsumableItem(Session session) : base(session)
        {
            UserTracking.SetUserInfoGetter(new SecurityUserGetter());
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("part_id")]        
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("shopfloorline_id")]
        public Shopfloorline Shopfloorline
        {
            get { return m_shopfloorline; }
            set { SetPropertyValue("Shopfloorline", ref m_shopfloorline, value); }
        }

        [NonPersistent]
        public Domain Domain
        {
            get { return null; }
        }

        [NonPersistent]
        public string RackLocation
        {
            get { return ""; }
        }

        [Persistent("qty")]
        public int Qty
        {
            get { return m_qty; }
            set { SetPropertyValue("Qty", ref m_qty, value); }
        }

        protected override void ValidateRules(BrokenRules Verify)
        {
            
        }
    }
}