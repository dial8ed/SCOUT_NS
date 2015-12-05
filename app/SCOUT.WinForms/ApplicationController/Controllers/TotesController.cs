using System;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class TotesController : ApplicationController.Controllers.ApplicationController
    {
        public TotesController()
        {
            AddCommand(ToteCommands.ToteTransfer, typeof(ToteTransferDomainCommand));
            AddCommand(ToteCommands.RemoveItems, typeof (ToteRemoveItemDomainCommand));
            AddCommand(ToteCommands.ToteContentsTransfer,typeof(ToteTransferContentsDomainCommand));            
            AddCommand(ToteCommands.ToteCreate, typeof(ToteCreateDomainCommand));
            AddCommand(ToteCommands.TotePrintLabel,typeof(TotePrintLabelDomainCommand));
            AddCommand(ToteCommands.TotesManage, typeof(TotesManageDomainCommand));
            AddCommand(ToteCommands.ToteContentsSelector, typeof(ToteContentsSelectorCommand));
            AddCommand(ToteCommands.AddItems, typeof(ToteAddItemsDomainCommand));
            AddCommand(ToteCommands.TotePutAway, typeof(ToteContentsPutAwayCommand));
        }

        public override ICommand GetCommand(string request, params object[] input)
        {
            // Check if the command is in the format of module.request.id
            object[] requestValues = request.Split(char.Parse("."));
            if (requestValues.Length == 3)
            {                
                object id = Int32.Parse(requestValues[2].ToString());
                return GetCommand<Tote>(request, id ,input);
            }
            
            return base.GetCommand(request, input);
        }       
    }
}