namespace SCOUT.Core.Data
{
    public class MaterialPOValidator : ValidatorBase
    {
        private MaterialPurchaseOrder m_materialPO;

        public MaterialPOValidator(MaterialPurchaseOrder po)
        {         
            m_materialPO = po;
        }

        public override void GetError()
        {            
            if(m_materialPO.LineItems.Count == 0)
            {
                m_error = "This order does not contain any lines items";
                return;
            }
        }
    }
}