using System;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.WinForms.Search;

namespace SCOUT.WinForms.Core
{
    public class OrdersSearchPacklistsCommand : Command
    {
        public override void Execute()
        {
            SearchDetail<Packlist> searchDetail =
                new SearchDetail<Packlist>()
                {                                        
                    StoredProcedure = "srch_shipping_configuration_packlists",
                    SearchText = "Shipping Configuration Packlists",                    
                    SearchButtons = new PacklistSearchButtons(),
                    WindowState = FormWindowState.Normal                    
                };

            SearchController<Packlist> searchController
                = new SearchController<Packlist>();

            searchController.SearchByDetail(searchDetail);
          
        }
    }
}