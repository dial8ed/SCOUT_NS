namespace SCOUT.Core.Data
{
    public class OutgoingPartAssignment : ValidatorBase
    {
        private PurchaseLineItem m_lineItem;
        private Part m_part;
        private Part m_outgoingPart;

        public OutgoingPartAssignment(PurchaseLineItem lineItem, Part outgoingPart)
        {
            m_lineItem = lineItem;
            m_outgoingPart = outgoingPart;
        }

        public override void GetError()
        {
            if(m_outgoingPart == null) return;

            m_part = m_lineItem.Part;

            if(m_part == null)
            {
                m_error = "Line item part has not been selected or is invalid.";
                return;
            }

            if(m_part.PartFamily == null)
            {
                m_error = string.Format("Change Cancelled: {0} is not part of a family and cannot have a outgoing part.", m_part.PartNumber);
                return;
            }

            if (m_part.PartFamily.AllowOutgoingOverride)
            {
                m_error = "";
                return;
            }
 
            if(!m_outgoingPart.IsTopLevel)
            {
                m_error = string.Format("Change Cancelled: {0} is not top level and cannot be a outgoing part",
                                        m_outgoingPart.PartNumber);
                return;
            }

            if(!m_part.PartFamily.Equals(m_outgoingPart.PartFamily))
            {
                m_error = string.Format("Change Cancelled: {0} and {1} are not in the same family", m_part.PartNumber, m_outgoingPart.PartNumber);
                return;
            }            
        }
    }
}