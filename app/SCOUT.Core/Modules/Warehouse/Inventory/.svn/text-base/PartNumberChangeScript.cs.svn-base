using System;
using DevExpress.Xpo;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class PartNumberChangeScript : ITransactionScript
    {
        private InventoryItem m_item;
        private Part m_newPart;

        public PartNumberChangeScript(InventoryItem item, Part newPart)
        {
            m_item = item;
            m_newPart = newPart;
        }

        public bool Run()
        {                
            // Validate
            if(!new PartNumberChangeValidator(m_item, m_newPart).Validated()) 
                return false;

            // Make Changes
            try
            {
                // Create part change transaction log
                Transaction trans = Scout.Core.Service<ITransactionService>()
                    .CreateTransaction("PNCHNG",
                                       m_item,
                                       m_item.Domain.FullLocation,
                                       m_item.Domain.FullLocation,
                                       "Part change from " + m_item.PartNumber + " to " + m_newPart.PartNumber,
                                       "");

                // Update inventory item part to new part
                m_item.Part = m_newPart;

                Scout.Core.Data.Save(m_item.Session);

                return true;
            }
            catch(Exception ex)
            {                
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }
   
        }
    }
}