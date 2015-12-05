using SCOUT.Core.Data;
using SCOUT.WinForms.Search;


namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Loads the materials consumable items search form
    /// </summary>
    public class MaterialsSearchConsumablesCommand : Command
    {
        public override void Execute()
        {
            var detail = new SearchDetail<MaterialConsumableItem>()
                             {
                                 StoredProcedure = "srch_materials_consumable_items",
                                 SearchText = "Search consumable materials"
                             };
            
            var controller = new SearchController<MaterialConsumableItem>();

            controller.SearchByDetail(detail);
        }
    }
}