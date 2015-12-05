using System;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class ExceedsPageCountCondition : IActionSpecification<RouteStationProcess>
    {
        private const string ExceedsPageCountMessage = "EXCEEDS PAGE COUNT";
        private bool m_canExecute = false;
        private RouteStationProcess m_process;
        private UserMessage m_message;
       
        public bool IsSatisfiedBy(RouteStationProcess process)
        {
            m_process = process;
            m_canExecute = false;

            if (process.Item.ShopfloorProgram != "CRA" ||
                process.Station.Station.Name != "OPS20-Repair")
                return false;
                        
            // Get the page count result
            string result = process.GetResult("Page Count");

            if(result.Length > 0)
            {
                int pageCount;
                if(int.TryParse(result, out pageCount))
                {
                    if(pageCount > 3000)
                    {
                        m_canExecute = true;
                        return true;
                    }
                }                              
            }

            return false;
        }

        public UserMessage Message
        {
            get { return m_message; }
        }

        public void ExecuteAction()
        {
            if (!m_canExecute)
                return;

            IShopfloorService sfl = Scout.Core.Service<IShopfloorService>();
            MethodResult result = sfl.ConvertProgram(m_process, "IW", ExceedsPageCountMessage);
            
            if(!string.IsNullOrEmpty(result.Message))
            {
                UserMessageType messageType;
                if (result.WasSuccessful == false)
                    messageType = UserMessageType.Error;
                else
                    messageType = UserMessageType.Information;

                m_message = new UserMessage(result.Message,messageType);
            }                
        }
    }
}