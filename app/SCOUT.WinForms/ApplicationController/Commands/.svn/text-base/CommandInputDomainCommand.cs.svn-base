using System;

namespace SCOUT.WinForms.Core
{
    public class CommandInputDomainCommand : Command
    {
        /// <summary>
        /// Creates an instance of the <cref>CommandInputForm</cref>
        /// </summary> 
        public override void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<CommandInputForm>(false, Args);
        }

    }
}