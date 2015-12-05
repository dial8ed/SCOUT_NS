using SCOUT.Core.Messaging;
using SCOUT.WinForms.Inventory;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteAddItemsDomainCommand :Command
    {
        private Tote m_tote;
        public ToteAddItemsDomainCommand(params object[] input) : base(input)
        {
           m_tote = input[0] as Tote;
        }

        public override void Execute()
        {
            if(m_tote == null)
                Scout.Core.UserInteraction.Dialog.ShowMessage("Invalid tote", UserMessageType.Error);

            ViewLoader.Instance()
               .CreateFormWithArgs<ToteAddContentsForm>(
               false, m_tote);            
        }
    }
}