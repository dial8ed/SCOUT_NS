using System;

namespace SCOUT.Core.Data
{
    public class LineItemAllowMembersChange : ValidatorBase
    {
        private ILineItem m_lineItem;
        private bool m_allowMembers;

        public LineItemAllowMembersChange(ILineItem lineItem, bool allowMembers)
        {
            m_lineItem = lineItem;
            m_allowMembers = allowMembers;
        }

        public override void GetError()
        {
            if (m_allowMembers == false) return;

            if (m_lineItem.Part == null)
            {
                m_error = "Change Cancelled - Part is not valid.";
                return;
            }

            if(m_lineItem.Part.PartFamily == null)
            {
                m_error = "Change Cancelled - Part is not in a family.";
            }
            
            if (!m_lineItem.Part.IsTopLevel)
            {
                m_error = "Change Cancelled - Part is not top level.";
                return;
            }
        }
    }
}