using System;

namespace SCOUT.WinForms.Core
{
    public class UnknownApplicationController : ApplicationController.Controllers.ApplicationController
    {
        public ICommand GetDomainCommand(string request)
        {
            return UnknownDomainCommand.Default();
        }

        public static IApplicationController Default()
        {
            return new UnknownApplicationController();
        }
    }
}