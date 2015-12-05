using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SCOUT.Core.Data
{
    public interface IPreAlert
    {
        bool LoadFromFile(FileInfo fileInfo);
        DataTable DataTable { get; }
        List<PartToImport> ImportList { get;}
        bool AssociateLinesToPurchaseOrder();
        LineItemImportValidator Validator { get;}
        bool Import();
        PurchaseOrder PurchaseOrder { get; set;}
        void MapDataSetToPersistedObjects();
        string PartColumnName { get;}
        bool SerialIsExpected(PurchaseOrder purchaseOrder, string serialNumber);
        string DisplayType { get;}
        IPreAlertItem GetItemBySerialNumber(PurchaseOrder order, string number);        
    }
}