namespace SCOUT.Core.Data
    {
        public class ServiceCommodityChangeValidator : ValidatorBase
        {
            private Part m_part; 
            private PartServiceCommodity m_serviceCommodity;

            public ServiceCommodityChangeValidator(Part part, PartServiceCommodity serviceCommodity)
            {
                m_part = part;
                m_serviceCommodity = serviceCommodity;
            }

            public override void GetError()
            {
                if (m_part.PartFamily != null)
                {
                    if (!m_part.PartFamily.ServiceCommodity.Equals(m_serviceCommodity))
                        m_error = "Change Cancelled: The service commodity must match that of the part family";                    
                }
            }
        }
    }