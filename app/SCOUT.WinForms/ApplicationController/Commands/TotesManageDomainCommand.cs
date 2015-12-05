using System;
using SCOUT.WinForms.Inventory;

namespace SCOUT.WinForms.Core
{
    public class TotesManageDomainCommand : Command
    {
        public TotesManageDomainCommand(params object[] input) : base(input)
        {

        }

        public override void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<ToteManagerForm>(true, Args);
        }
    }
}