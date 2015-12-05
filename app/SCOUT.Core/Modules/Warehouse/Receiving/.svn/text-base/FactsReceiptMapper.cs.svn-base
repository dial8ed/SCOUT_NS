using System;

namespace SCOUT.Core.Data
{
    public class FactsReceiptMapper : IMapper<ReceiptFacts, Receipt>
    {
        public Receipt MapFrom(ReceiptFacts input)
        {
            Receipt receipt = Scout.Core.Data.CreateEntity<Receipt>(input.Session);
            receipt.SerialNumber = input.SerialNumber;
            receipt.Qty = input.Qty;
            receipt.Condition = input.Condition;
            receipt.Comments = input.Comments;
            receipt.Part = input.Part;
            receipt.ReceivingCart = input.ReceivingCart;
            receipt.RoutingRequired = input.RoutingRequired;
            receipt.PurchaseOrder = input.PurchaseOrder;
            receipt.PurchaseLineItem = input.PurchaseLineItem;
            receipt.Grade = input.Grade;
            receipt.CustomFields = input.CustomFields;            
            receipt.ReceiveDate = DateTime.Now;
            receipt.UnitTrackingId = LotID.Generate();
            receipt.Warnings = input.Warnings;
            receipt.LineItemIdentifier = input.LineItemIdentifier;
            return receipt;            
        }
    }
}