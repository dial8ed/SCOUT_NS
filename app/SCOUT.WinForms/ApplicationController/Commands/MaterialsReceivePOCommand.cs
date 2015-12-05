using SCOUT.Core.Data;
using SCOUT.WinForms.Materials;
using SCOUT.WinForms.Search;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials receiving form.
    /// </summary>
    public class MaterialsReceivePOCommand : Command
    { 
        public override void Execute()
        {
            // Initialize a new controller for output only and call
            // LoadReceivingForm when a item is selected.
            var detail = new SearchDetail<MaterialPurchaseOrder>()
                             {
                                 SearchText = "Material Purchase Order Search",
                                 StoredProcedure = "srch_material_purchase_orders",
                                 IdColumn = "id",
                                 EditFormType = typeof (MaterialsReceivingForm),
                                 OnSelection = LoadReceivingForm
                             };

            var controller =
                new SearchController<MaterialPurchaseOrder>();
          
            controller.SearchByDetail(detail);                            
        }

        private void LoadReceivingForm(MaterialPurchaseOrder po)
        {
            ViewLoader.Instance()
                .CreateFormWithArgs<MaterialsReceivingForm>(false, new object[]{po});
        }
    }
}