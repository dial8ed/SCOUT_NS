using System;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class ReceiptValidator : ValidatorBase
    {
        private ReceiptFacts m_facts;

        public ReceiptValidator(ReceiptFacts facts)
        {
            m_facts = facts;
        }

        public override void GetError()
        {
            if (SerialIsOnDfile()) return;
            
            // Line item validation for non blanket purchase orders.
            if (!m_facts.PurchaseOrder.IsBlanket())
            {                
                if (!LineItemIsReceivable()) return;
                if (!PartNumberIsExpected()) return;
                if (SerialNumberIsMissing()) return;
                if (ReceiveQtyExceedsExpected()) return;
            }

            if (!ReceiptHasAssociatedLineItem()) return;

            // Serialized Rules
            if (!string.IsNullOrEmpty(m_facts.SerialNumber))
            {
                if (!SerialNumberMatchesFormat()) return;
                //if (DuplicateSNItem()) return;
                if (InvalidCustomFields()) return;
            }
        }

        private bool PartNumberIsExpected()
        {
            if(m_facts.PurchaseOrder.GetLineByPart(m_facts.Part) == null)
            {
                m_error = "This part number is not expected.";
                return false;
            }

            return true;            
        }

        private bool SerialIsOnDfile()
        {
            IDfileService dfile = Scout.Core.Service<IDfileService>();
            DfileItem dfileItem = dfile.Repository.GetUnResolvedItemBySerialNumber
                                        (dfile.Providers.Data.GetUnitOfWork(), m_facts.SerialNumber);

            if(dfileItem != null)
            {
                m_error = "Unit is on dfile and cannot be received";
                return true;
            }

            return false;
        }

        private bool SerialNumberIsMissing()
        {
            if (m_facts.PurchaseLineItem.IdentType.Name.ToLower() == "serialized")
            {
                if (string.IsNullOrEmpty(m_facts.SerialNumber))
                {
                    m_error = "Serial Number is required.";
                    return true;
                }
            }

            return false;
        }

        private bool ReceiptHasAssociatedLineItem()
        {
            // Blanket PO
            if (m_facts.PurchaseOrder.LineItems.Count == 0) return true;

            if (m_facts.PurchaseLineItem == null)
            {
                m_error = "This receipt is not associated with a line item item.";
                return false;
            }

            return true;
        }

        private bool ReceiveQtyExceedsExpected()
        {
            if ((m_facts.Qty + m_facts.PurchaseLineItem.ProcessedQty) > m_facts.PurchaseLineItem.Quantity)
            {
                m_error = "Exceeds expected qty for this part.";
                return true;
            }

            return false;
        }

        private bool LineItemIsReceivable()
        {
            bool rval = new PurchaseLineItemReceiptValidator(m_facts.PurchaseLineItem).Validated();
            if (rval == false)
            {
                m_error = "Line item not receivable";
                return false;
            }

            return true;
        }

        private bool InvalidCustomFields()
        {
            if (m_facts.CustomFields == null)
                return false;

            if (!m_facts.CustomFields.RequiredFieldsAreValid(
                m_facts.PurchaseOrder.Shopfloorline.CustomFields))
            {
                m_error = "Custom fields are required.";
                return true;
            }
            
            if(!string.IsNullOrEmpty(m_facts.CustomFields.PPID))
            {
                if(!new PPIDValidator(m_facts.CustomFields.PPID).Validate())
                {
                    m_error = "PPID is not valid.";
                    return true;
                }
            }

            return false;
        }

        private bool SerialNumberMatchesFormat()
        {
            if (OrderService.ForceSerialFormatFor(m_facts.PurchaseOrder, m_facts.Part))
            {
                if (!PartService.SnMatchesFormat(m_facts.Part, m_facts.SerialNumber))
                {
                    m_error = "This serial number doesnt match any of the defined serial formats";
                    return false;
                }
            }

            return true;
        }

        //private bool DuplicateSNItem()
        //{
        //    if (Scout.Core.Service<IInventoryService>().DuplicateSNItemExists(m_facts.SerialNumber))
        //    {
        //        m_error = "This unit already exists in inventory.";
        //        return true;
        //    }

        //    return false;
        //}
    }
}