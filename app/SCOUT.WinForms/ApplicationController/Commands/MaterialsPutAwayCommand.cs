using System;
using SCOUT.WinForms.Materials;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials put away form.
    /// </summary>
    public class MaterialsPutAwayCommand : Command
    {
        public override void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<MaterialsPutAwayForm>(false, null);            
        }
    }
}