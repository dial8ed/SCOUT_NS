using SCOUT.Core.Data;
using SCOUT.WinForms.Search;


namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials transaction search window
    /// </summary>
    public class MaterialsSearchTransactionsCommand : Command
    {
        public override void Execute()
        {
            var detail = new SearchDetail<MaterialWarehouseItem>()
                             {
                                 StoredProcedure = "srch_material_transactions",
                                 SearchText = "Materials Transaction Search"
                             };
            var controller= new SearchController<MaterialWarehouseItem>();

            controller.SearchByDetail(detail);         
        }
    }
}