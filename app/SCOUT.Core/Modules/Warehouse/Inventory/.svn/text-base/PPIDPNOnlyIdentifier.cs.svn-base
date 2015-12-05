using System;
using System.Collections.Generic;

namespace SCOUT.Core.Data
{
    public class PPIDPNOnlyIdentifier : PPIDIdentifier
    {
        public override void BuildFieldList()
        {
            if(m_fieldList.Count > 0)
                m_fieldList.Clear();

            m_fieldList.Add("pn", m_completeIdentifier.Substring(3, 5));
            //m_fieldList.Add("sn", m_completeIdentifier.Substring(8,m_completeIdentifier.Length - 8));
            m_fieldList.Add("sn", "");
            
        }
    }
}