using SCOUT.Core.Data;
using SCOUT.WinForms.Search;


namespace SCOUT.WinForms.Core
{
    public class MaterialsSearchAllCommand : Command
    {
        /// <summary>
        /// Loads the search all materials inventory form.
        /// </summary>
        public override void Execute()
        {
            var detail = new SearchDetail<IMaterialItem>()
                             {
                                 StoredProcedure = "srch_materials_all_items",
                                 SearchText = "Materials All Inventory Search"
                             };

            var controller = new SearchController<IMaterialItem>();

            controller.SearchByDetail(detail);
        }
    }
}