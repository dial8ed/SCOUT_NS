using SCOUT.Core.Data;

namespace SCOUT.Core.Services
{
    public interface IReceivingService
    {        
        bool ReceiveUnit(ReceiptFacts facts);

        /// <summary>
        /// Deletes a receipt from the database.
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>        
        /// TODO: needs to move to repository layer.
        bool DeleteReceipt(Receipt receipt);
        void PrintReceiveLabel(Receipt receipt);
        //void PrintIdLabel(Receipt receipt);        
    }
}