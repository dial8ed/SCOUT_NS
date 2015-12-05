using System.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public class HoldResolutionValidator : ValidatorBase
    {
        private InventoryHold m_hold;
        public HoldResolutionValidator(InventoryHold hold) : base()
        {
            m_hold = hold;
        }

        public HoldResolutionValidator(MessageListener listener, InventoryHold hold) : base(listener)
        {
            if(m_listener == null)
                throw new NoNullAllowedException("MessageListener cannot be null");

            m_hold = hold;
        }

        public override void GetError()
        {
            if (string.IsNullOrEmpty(m_hold.Resolution))
            {
                m_error = "Resolution is required.";
                return;
            }                        
        }
    }
}