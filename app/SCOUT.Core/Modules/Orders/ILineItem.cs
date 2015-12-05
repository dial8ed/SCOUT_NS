namespace SCOUT.Core.Data
{
    public interface ILineItem
    {
        int Quantity { get; }
        Part Part { get; }
        int ProcessedQty { get;}
        bool AllowDownlevels { get;}
        int OpenQty { get; }
        //ILineItem ParentLineItem { get;}
    }
}