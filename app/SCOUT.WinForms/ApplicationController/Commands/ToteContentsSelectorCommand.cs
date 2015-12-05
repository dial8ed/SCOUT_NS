using System;
using System.Collections.Generic;
using SCOUT.WinForms.Inventory;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteContentsSelectorCommand : Command, IOutputCommand<List<InventoryItem>>
    {
        public ToteContentsSelectorCommand(params object[] input) : base(input)
        {
            if (input[0] is Tote)
            {
                Args[0] = new ToteContentsTransferCommandArguments(input[0] as Tote);
            }
        }

        public override void Execute()
        {
            ToteContentsTransferCommandArguments contentsTransferArguments =
                Args[0] as ToteContentsTransferCommandArguments;

            if (contentsTransferArguments == null)
                throw new NotSupportedException();

            // Load the tote contents selection form
            ViewLoader.Instance()
                .CreateFormWithArgs<ToteContentsSelectorForm>(
                    false, contentsTransferArguments);

        }

        public List<InventoryItem> Output
        {
            get { return ((ToteContentsTransferCommandArguments)Args[0]).ItemsToMove ; }
        }
    }
}