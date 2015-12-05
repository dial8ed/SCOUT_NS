using SCOUT.Core.Messaging;

namespace SCOUT.WinForms.Core
{
    public class SecurityAccessDeniedCommand : Command
    {
        public override void Execute()
        {
            Scout.Core.UserInteraction.Dialog.ShowMessage("You do not have permission to perform this task.", 
                UserMessageType.Validation);
        }
    }
}