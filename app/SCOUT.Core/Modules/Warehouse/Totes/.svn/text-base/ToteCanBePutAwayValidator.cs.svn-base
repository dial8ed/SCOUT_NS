using System;

namespace SCOUT.Core.Data
{
    public class ToteCanBePutAwayValidator :ValidatorBase
    {
        private Tote m_tote;
        public ToteCanBePutAwayValidator(Tote tote)
        {
            m_tote = tote;
        }

        public override void GetError()
        {
            if (m_tote.Domain == null || !m_tote.Domain.LocatorControlled)
            {
                m_error = "This tote is not in a locator controlled domain.";
                return;
            }                           
        }
    }
}