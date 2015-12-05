using System;
using DevExpress.Xpo;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;
using SCOUT.WinForms.Inventory;
using SCOUT.Core.Data;


namespace SCOUT.WinForms.Core
{
    public class ToteRemoveItemDomainCommand : Command
    {
        private IUnitOfWork m_session;
        private Tote m_tote;

        public ToteRemoveItemDomainCommand(params object[] input) : base(input)
        {
            Tote tote = input[0] as Tote;
            if (tote != null)
                Args[0] = new ToteContentsTransferCommandArguments(tote);

            m_session = tote.Session;
        }

        public override void Execute()
        {
            ToteContentsTransferCommandArguments arguments 
                = Args[0] as ToteContentsTransferCommandArguments;

            if (arguments == null)
                throw new NotSupportedException();

            //Load the tote contents selection form
            ViewLoader.Instance()
                .CreateFormWithArgs<ToteContentsSelectorForm>(
                false, arguments);


            if (arguments.ItemsToMove.Count > 0)
            {
                foreach (InventoryItem item in arguments.ItemsToMove)
                {
                    Scout.Core.Service<IInventoryService>()
                        .RemoveItemFromTote(item);
                }

                try
                {
                    Scout.Core.Data.Save(m_session);                    
                    Scout.Core.UserInteraction.Dialog.ShowMessage
                        ("Items removed", UserMessageType.Information);              
                }
                catch (Exception ex)
                {
                    Scout.Core.UserInteraction.Dialog.ShowMessage
                        (ex.Message, UserMessageType.Error);
                }
            }
        }
    }
}