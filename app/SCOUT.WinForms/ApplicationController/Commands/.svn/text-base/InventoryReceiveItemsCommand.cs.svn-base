using SCOUT.Core.Data;
using SCOUT.WinForms.Search;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads PO search form. Once a PO is selected the receiving form will open
    /// </summary>
    public class InventoryReceiveItemsCommand : Command, ISecurityCommand
    {
        public override void Execute()
        {
            SearchController<PurchaseOrder> controller =
                new SearchController<PurchaseOrder>();

            controller.SearchByType();                
        }

        /// <summary>
        /// Specifies which security actions are required to perform this task
        /// </summary>
        public SCOUT.Core.Security.UserSecurity.Action SecurityAction
        {
            get { return SCOUT.Core.Security.UserSecurity.Action.ReceiveItems; }
        }
    }
}