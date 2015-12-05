using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public class DfileCondition
    {        
        private UserMessage m_message = new UserMessage("",UserMessageType.Information);

        public bool IsSatisfiedBy(ReceiptFacts facts)
        {
            if (!IsSerialized(facts)) return false;
            if (!IsExpectedPartNumber(facts)) return true;
            if (!LineItemIsOpen(facts)) return true;
            if (!IsExpectedOnPreAlert(facts)) return true;
            if (!PreAlertPartNumberMatchesItem(facts)) return true;
            
            return false;
        }

        private bool IsSerialized(ReceiptFacts facts)
        {
            if (!string.IsNullOrEmpty(facts.SerialNumber) && facts.SerialNumber != "NON SERIALIZED")
                return true;

            return false;
        }

        private bool IsExpectedPartNumber(ReceiptFacts facts)
        {            
            if(facts.PurchaseOrder.GetLineByPart(facts.Part) == null)
            {
                m_message = new UserMessage
                    ("This part number is not expected", UserMessageType.Error);

                return false;
            }

            return true;
        }

        private bool IsExpectedOnPreAlert(ReceiptFacts facts)
        {
            if (!facts.PurchaseOrder.IsExpectedPreAlertItem(facts.SerialNumber))
            {
                m_message = new UserMessage
                    ("This serial number is not expected on the pre-alert", UserMessageType.Validation);
                return false;
            }

            return true;
        }

        private bool PreAlertPartNumberMatchesItem(ReceiptFacts facts)
        {
            IPreAlertItem preAlertItem = facts.PurchaseOrder.GetPreAlertItem(facts.SerialNumber);

            if (preAlertItem == null) return true;

            if (string.IsNullOrEmpty(preAlertItem.PartNumber))
                return true;

            if(preAlertItem.PartNumber != facts.Part.PartNumber)
            {
                m_message = 
                    new UserMessage("This part number does not match the pre-alert part number - " 
                        + preAlertItem.PartNumber,UserMessageType.Validation);

                return false;
            }
            return true;
        }

        private bool LineItemIsOpen(ReceiptFacts facts)
        {
            if(facts.PurchaseLineItem.Status != LineItemStatus.Open)
            {
                m_message = new UserMessage("The line item is not open", UserMessageType.Validation);
                return false;
            }

            return true;
        }

        public UserMessage Message
        {
            get { return m_message; }            
        }
    }
}