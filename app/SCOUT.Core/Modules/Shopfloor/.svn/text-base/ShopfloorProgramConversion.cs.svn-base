using System.Collections.Generic;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class ShopfloorProgramConversion : IShopfloorServiceMethod
    {
        public MethodResult Execute(RouteStationProcess process, 
            Dictionary<string, object> inputParams)
        {
            InventoryItem item = process.Item;

            string oldProgram = item.ShopfloorProgram;
            string reason = inputParams["Reason"].ToString();
            string newProgram = inputParams["NewProgram"].ToString();

            // Create conversion record
            ShopfloorProgramConversionRecord record =
                new ShopfloorProgramConversionRecord(item, item.ShopfloorProgram, newProgram, reason);

            // Update the inventory items program
            item.ShopfloorProgram = newProgram;
            item.CurrentProcess.ShopfloorProgram = newProgram;

            // Create conversion message
            string msg = string.Format("Converted unit from {0} to {1} because {2}", oldProgram, newProgram, reason);

            // Create conversion transaction record
            Scout.Core.Service<ITransactionService>().CreateTransaction("SFLPROGCONV", item,"", "", msg, reason);
                       
            return new MethodResult(true, msg);           

        }
    }
}