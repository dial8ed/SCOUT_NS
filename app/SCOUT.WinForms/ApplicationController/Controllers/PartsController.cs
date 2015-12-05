using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.ApplicationController.Controllers
{
    public class PartsController : ApplicationController
    {
        public PartsController()
        {
            AddCommand(PartCommands.ManagePartModelBomMaster, typeof(PartsManageBomMasterCommand));
            AddCommand(PartCommands.ManageBomConfiguration, typeof(PartsManageBomConfigurationCommand));
        }
    }
}