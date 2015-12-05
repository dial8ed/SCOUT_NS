using System;
using System.Collections.Generic;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.ApplicationController.Controllers
{
    public abstract class ApplicationController : IApplicationController
    {
        private Dictionary<string, Type> m_commandMap;

        protected ApplicationController()
        {
            m_commandMap = new Dictionary<string, Type>();
        }

        protected void AddCommand(string request, Type commandType)
        {
            if (!m_commandMap.ContainsKey(request))
                m_commandMap.Add(request, commandType);
        }

        public virtual ICommand GetCommand(string request, params object[] input)
        {
            ICommand command;
            try
            {
                command =
                    (ICommand)Activator.CreateInstance(m_commandMap[request],input);
                
            }
            catch (KeyNotFoundException exception)
            {
                return UnknownDomainCommand.Default();
            }

            return command;
        }

        public ICommand GetCommand<T>(string request, object id, params object[] input)
        {
            //TODO: Write command format validation code
            //this request should be in the format of category.request.objectid
            string[] requestValues = request.Split(char.Parse("."));  
        
            T t = XPOFactory.GetInstanceOfById<T>(id);

            return GetCommand(requestValues[0] + "." + requestValues[1], t);            
        }
    }
}