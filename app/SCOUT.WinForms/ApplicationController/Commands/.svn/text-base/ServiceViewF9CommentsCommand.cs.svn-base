using System.Data;
using SCOUT.Core.Data;
using SCOUT.Core.Services;
using SCOUT.WinForms.Service;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Launches the F9Comments view.
    /// </summary>
    public class ServiceViewF9CommentsCommand : Command
    {
        private InventoryItem m_item;


        public ServiceViewF9CommentsCommand(params object[] input) : base(input)
        {
            //If the args are null or not of type InventoryItem throw exception.
            if (Args == null || (Args[0].GetType() != typeof (InventoryItem)))
                throw new NoNullAllowedException(
                    "A argument of type InventoryItem is required.");

            m_item = Args[0] as InventoryItem;
        }


        public override void Execute()
        {
            // Get the service properties which contains the F9 Comments
            InventoryServiceProperties serviceProperties =
                Scout.Core.Service<IInventoryService>().GetServicePropertiesForItem(m_item.Session,
                                                             m_item);

            // Load the form.
            ViewLoader.Instance().CreateFormWithArgs<F9CommentsView>(false,
                                                                     serviceProperties);
        }
    }
}