namespace SCOUT.Core.Data
{
    public class PartNumberChangeValidator : ValidatorBase
    {
        private InventoryItem m_item;
        private Part m_newPart;

        public PartNumberChangeValidator(InventoryItem item, Part newPart)
        {
            m_item = item;
            m_newPart = newPart;
        }

        public override void GetError()
        {
            if(m_newPart == null)
            {
                m_error = "Part is not valid";
                return;
            }
         
            if(m_item.Part == null) return;

            if(!m_item.Part.ServiceCommodity.Equals(m_newPart.ServiceCommodity))
            {
                m_error = "Part " + m_newPart.PartNumber + " is not associated with the same service commodity";
                return;
            }

            
        }
    }
}