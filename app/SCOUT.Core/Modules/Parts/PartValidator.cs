namespace SCOUT.Core.Data
{
    public class PartValidator : ValidatorBase
    {
        private Part m_part;

        public PartValidator(Part part)
        {
            m_part = part;
        }

        public override void GetError()
        {
            if (m_part.IsNew)
            {
                Part p = Part.GetPartByPartNumber(m_part.Session, m_part.PartNumber);

                if (p != null)
                {
                    if (!p.Id.Equals(m_part.Id))
                        m_error = "Part already exists: " +
                                  m_part.PartNumber;
                    return;
                }
            }


            if(m_part.ServiceCommodity == null)
            {
                m_error = "Service Commodity is required.";
                return;
            }

        }
    }
}