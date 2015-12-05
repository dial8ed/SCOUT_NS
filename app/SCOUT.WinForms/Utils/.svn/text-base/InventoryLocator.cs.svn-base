using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;

namespace SCOUT.WinForms
{
    public class InventoryLocator
    {
        public InventoryItem LocateOrWarn(IUnitOfWork uow, string ident)
        {
            InventoryItem item = Scout.Core.Service<IInventoryService>()
                .GetItemByLotIdOrSerialNumber(uow, ident);

            if (item == null)
            {
                string error = string.Format("A Inventory Item for: {0} could not be found.", ident);
                Scout.Core.UserInteraction.Dialog.ShowMessage(error, UserMessageType.Error);
                return null;
            }

            return item;

        }

    }
}
