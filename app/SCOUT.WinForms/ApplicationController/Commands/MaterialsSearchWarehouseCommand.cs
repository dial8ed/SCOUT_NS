using SCOUT.Core.Data;
using SCOUT.WinForms.Search;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials warehouse inventory search form
    /// </summary>
    public class MaterialsSearchWarehouseCommand : Command
    {
        public override void Execute()
        {
            var detail = new SearchDetail<MaterialWarehouseItem>()
                             {
                                 StoredProcedure = "srch_materials_warehouse_items",
                                 SearchText = "Materials Warehouse Search"
                             };

            var controller =
                 new SearchController<MaterialWarehouseItem>();

            controller.SearchByDetail(detail);
            
        }
    }
}