using System;
using System.Collections.Generic;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class DellReceiptLpnIdentifier : IMultiFieldIdentifier, ILineItemIdentifier, ICustomFieldsIdentifier
    {
        private DellReceiptLpnItem m_item;        
        private Dictionary<string, string> m_fieldList;
        private Dictionary<string, string> m_customFields;

        public DellReceiptLpnIdentifier()
        {
            m_fieldList = new Dictionary<string, string>();           
            m_customFields = new Dictionary<string, string>();
        }

        public bool Validate()
        {           
            m_item = OrderService.GetOpenDellReceiptLpnItem(CompleteIdentifier);

            if(m_item == null)
            {
                Scout.Core.UserInteraction
                    .Dialog.ShowMessage("Could not find a open receiving item for LPN { " + CompleteIdentifier + " }", UserMessageType.Error);
                return false;
            }

            BuildFieldList();
            return true;
        }

        public void BuildFieldList()
        {
            if(m_fieldList.Count > 0)
                m_fieldList.Clear();

            if(m_customFields.Count > 0)
                m_customFields.Clear();

            m_fieldList.Add("pn", "");             
            m_fieldList.Add("sn", m_item.SerialNumber);
            m_fieldList.Add("lpn", m_item.Lpn);

            m_customFields.Add("Revision", m_item.Revision);          
            m_customFields.Add("DPS", m_item.Dps);
            m_customFields.Add("PPID", m_item.Ppid);
        }

        public string CompleteIdentifier
        {
            get; set;
        }

        public Dictionary<string, string> MultiFieldList
        {
            get { return m_fieldList; }
        }

        public override string ToString()
        {
            return "Dell LPN";
        }

        public string LineItemIdentifier
        {
            get { return m_fieldList["lpn"]; }
        }

        public Dictionary<string, string> CustomFieldsDictionary
        {
            get { return m_customFields; }
        }
    }
}