using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.WinForms.Materials;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials purchase order form
    /// </summary>
    public class MaterialsCreatePOCommand : Command
    {
        public override void Execute()
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<MaterialsPurchaseOrderForm>(
                    false,
                    Scout.Core.Data.CreateEntity<MaterialPurchaseOrder>(Scout.Core.Data.GetUnitOfWork()));                
        }
    }
}