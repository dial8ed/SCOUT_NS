using SCOUT.Core.Data;
using SCOUT.WinForms.Search;

namespace SCOUT.WinForms.Core
{

    /// <summary>
    /// Loads the SO search form. Once a SO is selected the shipping form will open.
    /// </summary>
    public class InventoryShipItemsCommand : Command, ISecurityCommand
    {
        #region ISecurityCommand Members

        public SCOUT.Core.Security.UserSecurity.Action SecurityAction
        {
            get { return SCOUT.Core.Security.UserSecurity.Action.ShipItems; }
        }

        #endregion

        public override void Execute()
        {
            var controller = new SearchController<SalesOrder>();

            controller.SearchByType();
        }
    }
}