using SCOUT.WinForms.Inventory;

namespace SCOUT.WinForms.Core
{
    public class ToteTransferDomainCommand : Command
    {
        public ToteTransferDomainCommand(params object[] input)
            : base(input)
        {
        }

        public override void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<ToteTransferForm>(false, Args);
        }
    }
}