using System;

namespace SCOUT.Core.Data
{
    public class ReceiptSerializedUnitMapper : Core.IMapper<Receipt, SerializedUnit>
    {
        public SerializedUnit MapFrom(Receipt input)
        {
            SerializedUnit serializedUnit = 
                Scout.Core.Data.CreateEntity<SerializedUnit>(input.Session);
           
            serializedUnit.InitIdent = input.SerialNumber;
            serializedUnit.ReturnDate = DateTime.Now;
            serializedUnit.Item = input.Item;
            serializedUnit.ReturnType = input.PurchaseOrder.ReturnType;
            serializedUnit.ReturnSeed = SerializedHistoryService.GetReturnSeedFor(serializedUnit);
            serializedUnit.ReturnTypeCount = SerializedHistoryRepository.GetReturnTypeCount(serializedUnit);            
            return serializedUnit;
        }
    }
}