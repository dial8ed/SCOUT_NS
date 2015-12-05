using System;

namespace SCOUT.Core.Mvc
{
    public interface IMvcActionEventController
    {
        void RegisterActionRequestHandler(string action,
                            EventHandler<ActionRequestEventArgs> handler);


        void UnRegisterActionRequestHandler(string action,
                              EventHandler<ActionRequestEventArgs> handler);
       
    }


}