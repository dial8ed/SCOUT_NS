using System.Text.RegularExpressions;

namespace SCOUT.Core.Data
{
    public class ServiceTagValidator
    {
        private string m_serviceTag;
        private string m_pattern = "[a-zaA-Z0-9]{7}" ;

        public ServiceTagValidator(string serviceTag)
        {
            m_serviceTag = serviceTag;
        }

        public bool Validated()
        {
            return new Regex(m_pattern).IsMatch(m_serviceTag);            
        }        
    }
}