using System;
using SCOUT.WinForms.Inventory;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteTransferContentsDomainCommand : Command
    {
        public ToteTransferContentsDomainCommand(params object[] input)
            : base(input)
        {
            if(input[0] is Tote)
            {
                Args[0] = new ToteContentsTransferCommandArguments(input[0] as Tote);       
            }            
        }

        public override void Execute()
        {
            ToteContentsTransferCommandArguments contentsTransferArguments =
                Args[0] as ToteContentsTransferCommandArguments;

            if(contentsTransferArguments == null)
                throw new NotSupportedException();
           
            // Load the tote contents selection form
            ViewLoader.Instance()
                .CreateFormWithArgs<ToteContentsSelectorForm>(
                    false,contentsTransferArguments);

            // If inventory items have been selected to transfer
            // then load the transfer form
            if (contentsTransferArguments.ItemsToMove.Count > 0)
                ViewLoader.Instance()
                    .CreateFormWithArgs<ToteContentsTransferForm>(
                        false, 
                        contentsTransferArguments);
        }
    }
}