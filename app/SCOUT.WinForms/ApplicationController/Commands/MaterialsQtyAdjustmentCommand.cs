using System;
using SCOUT.Core.Security;
using SCOUT.WinForms.Materials;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials qty adjustment form
    /// </summary>
    public class MaterialsQtyAdjustmentCommand : Command, ISecurityCommand
    {
        public override void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<MaterialsQtyAdjustmentForm2>(false, null);
        }

        public UserSecurity.Action SecurityAction
        {
            get { return UserSecurity.Action.MaterialAdjustments; }
        }
    }
}