using SCOUT.Core.Messaging;

namespace SCOUT.WinForms.Core
{
    public class UnknownDomainCommand : ICommand
    {
        public void Execute()
        {
            Scout.Core.UserInteraction.Dialog.ShowMessage
                ("Invalid domain command.", UserMessageType.Error);
        }

        public static ICommand Default()
        {
            return new UnknownDomainCommand();
        }       
    }
}