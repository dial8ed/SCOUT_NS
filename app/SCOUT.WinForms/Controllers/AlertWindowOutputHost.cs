using System;
using DevExpress.XtraBars.Alerter;
using SCOUT.Core.Messaging;

namespace SCOUT.Entities.CS.Controllers
{
    public class AlertWindowOutputHost : AlertControl, IUserMessageOutputHost
    {
        public void ProcessMessage(UserMessageEventArgs message)
        {
            Show(null,"User Message",message.Message);            
        }
    }
}