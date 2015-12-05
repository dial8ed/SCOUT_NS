namespace SCOUT.Core.Data
{
    public class PutAwayMaterialValidator : ValidatorBase
    {
        private readonly MaterialWarehouseItem m_item;
        private readonly RackLocation m_location;
        private readonly int m_qty;

        public PutAwayMaterialValidator(MaterialWarehouseItem item, RackLocation location, int qty)
        {
            m_item = item;
            m_location = location;
            m_qty = qty;
        }

        public override void GetError()
        {
           if(m_item.Qty < m_qty)
           {
               m_error = "You cannot issue out more than is available.";
               return;
           }


        }
    }
}