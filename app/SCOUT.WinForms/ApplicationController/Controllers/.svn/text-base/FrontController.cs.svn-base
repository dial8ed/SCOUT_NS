using System;
using System.Collections.Generic;
using SCOUT.WinForms.ApplicationController.Controllers;

namespace SCOUT.WinForms.Core
{
    public class FrontController
    {
        private static FrontController s_singleton;
        private Dictionary<string, Type> m_controllerMap;
        //private UserActivityHook activityHook;
        //private List<string> m_keySequence;

        protected FrontController()
        {
            //activityHook = new UserActivityHook(false,true);            
            //activityHook.KeyUp += activityHook_KeyUp;
            //m_keySequence = new List<string>();

            m_controllerMap = new Dictionary<string, Type>();
            m_controllerMap.Add("inventory", typeof (InventoryController));
            m_controllerMap.Add("orders", typeof (OrdersController));
            m_controllerMap.Add("totes", typeof (TotesController));
            m_controllerMap.Add("input", typeof (InputController));
            m_controllerMap.Add("security", typeof (SecurityController));
            m_controllerMap.Add("materials", typeof(MaterialsController));
            m_controllerMap.Add("service", typeof(ServiceController));
            m_controllerMap.Add("parts", typeof(PartsController));

            //m_controllerMap.Add("areas", typeof(AreasController));
            //m_controllerMap.Add("users", typeof(UsersController));
            //m_controllerMap.Add("help", typeof(HelpController));
            //m_controllerMap.Add("reporting", typeof(ReportingController));
            //m_controllerMap.Add("organizations", typeof(OrganizationsController));
            //m_controllerMap.Add("parts", typeof(PartsController));            
            //m_controllerMap.Add("processes", typeof(ProcessesController));
        }

        public static FrontController GetInstance()
        {
            if (s_singleton == null)
                s_singleton = new FrontController();

            return s_singleton;
        }

        private IApplicationController GetController(string request)
        {
            string key = request.Split(char.Parse("."))[0];

            IApplicationController controller;

            try
            {
                controller =
                    (IApplicationController) Activator.CreateInstance(m_controllerMap[key]);
            }
            catch (KeyNotFoundException exception)
            {
                return new UnknownApplicationController();
            }

            return controller;
        }

        public ICommand GetCommand(string request, params object[] input)
        {
            if (string.IsNullOrEmpty(request))
                request = "invalid.request";

            IApplicationController controller = GetController(request);
            return controller.GetCommand(request, input);
        }

        public ICommand RunCommand(string request, params object[] input)
        {
            ICommand command = GetCommand(request, input);

            if (!UserHasPermissionToRun(command))
                return null;

            command.Execute();
            return command;
        }

        private bool UserHasPermissionToRun(ICommand command)
        {
            ISecurityCommand securityCommand = command as ISecurityCommand;
            if (securityCommand == null) return true;

            if (securityCommand.SecurityAction == null)
                return true;

            bool rval;
            rval = SCOUT.Core.Security.UserSecurity.CurrentUser.CanPerform
                (securityCommand.SecurityAction);

            if (rval == false)
            {
                ICommand permissionCommand = GetCommand("security.access-denied", null);
                permissionCommand.Execute();
            }

            return rval;
        }

    }
}