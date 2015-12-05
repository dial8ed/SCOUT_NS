using System;

namespace SCOUT.Core.Data
{
    public class ServiceTagIdentifier : ISerialIdentifier
    {
        private string m_serviceTag = "";        

        public string Example
        {
            get { return "0000000"; }
        }

        public string DisplayName
        {
            get { return "Service Tag"; }
        }

        public bool SilentValidate()
        {
            return new ServiceTagValidator(m_serviceTag).Validated();
        }

        public void SetSerial(string sn)
        {
            m_serviceTag = sn;
        }
    }
}