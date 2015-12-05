using System;
using SCOUT.WinForms.Inventory;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteContentsPutAwayCommand : Command
    {
        private Tote m_tote;

        public ToteContentsPutAwayCommand(params object[] input) : base(input)
        {
            m_tote = input[0] as Tote;
            if(m_tote != null)            
            {
                Args[0] = new ToteContentsTransferCommandArguments(input[0] as Tote);
            }
        }

        public override void Execute()
        {
            if(!new ToteCanBePutAwayValidator(m_tote).Validated())
                return;

            ToteContentsTransferCommandArguments contentsTransferArguments =
                Args[0] as ToteContentsTransferCommandArguments;

            if (contentsTransferArguments == null)
                throw new NotSupportedException();

            // Load the tote contents selection form
            ViewLoader.Instance()
                .CreateFormWithArgs<ToteContentsSelectorForm>(
                    false, contentsTransferArguments);


            // If inventory items have been selected to transfer
            // then load the transfer form
            if (contentsTransferArguments.ItemsToMove.Count > 0)
                ViewLoader.Instance()
                    .CreateFormWithArgs<ToteContentsPutAwayForm>(
                        false,
                        contentsTransferArguments);
            
        }
    }
}