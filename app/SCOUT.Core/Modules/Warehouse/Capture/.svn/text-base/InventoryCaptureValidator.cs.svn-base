using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public class InventoryCaptureValidator : ValidatorBase
    {
        private InventoryCapture m_capture;

        public InventoryCaptureValidator(InventoryCapture capture)
        {
            m_capture = capture;
        }

        public InventoryCaptureValidator(InventoryCapture capture, MessageListener listener) : base(listener)
        {
            m_capture = capture;
        }

        public override void GetError()
        {
            if (m_capture.Shopfloorline == null)
            {
                m_error = "Shopfloorline is required.";
                return;
            }
                
            if(string.IsNullOrEmpty(m_capture.Message))
            {
                m_error = "Message is required.";
                return;
            }

            if(string.IsNullOrEmpty(m_capture.Criteria))
            {
                m_error = "Capture criteria is required.";
                return;
            }

        }        
    }
}