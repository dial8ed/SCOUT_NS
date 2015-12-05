namespace SCOUT.WinForms.Core
{
    public class SecurityController : ApplicationController.Controllers.ApplicationController
    {
        public SecurityController()
        {
            AddCommand("security.access-denied", typeof(SecurityAccessDeniedCommand));
        }

        static public IApplicationController Default()
        {
            return new SecurityController();
        }
    }
}