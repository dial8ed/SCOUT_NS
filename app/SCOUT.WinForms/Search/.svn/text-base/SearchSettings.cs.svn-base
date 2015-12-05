using SCOUT.WinForms.Inventory;
using SCOUT.WinForms.Materials;
using SCOUT.WinForms.Parts;
using SCOUT.WinForms.Sales;
using SCOUT.WinForms.Search;
using SCOUT.WinForms.Service;
using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public class SearchSettings
    {        
        public static SearchDetail<T> GetSearchDetailsFor<T>()
        {
            var searchDetail = new SearchDetail<T>();

            if(typeof(T) == typeof(Order))
            {
                searchDetail.SearchText = "Order Search";
                searchDetail.StoredProcedure = "srch_Orders";
                searchDetail.IdColumn = "id";
                searchDetail.MdiParent = MainForm.GetInstance();
                searchDetail.EditFormType = typeof (mainOrderForm);   
                         
                return searchDetail;
            }

            if(typeof(T) == typeof(PurchaseOrder))
            {
                searchDetail.SearchText = "Purchase Order Search";
                searchDetail.StoredProcedure = "srch_PO_Receiving";
                searchDetail.IdColumn = "id";
                searchDetail.EditFormType = typeof (receivingForm);
                return searchDetail;
            }

            if(typeof(T) == typeof(InventoryItem))
            {
                searchDetail.SearchText = "Inventory Search";
                searchDetail.StoredProcedure = "srch_Inventory_Search";
                searchDetail.IdColumn = null;
                searchDetail.EditFormType = null;
                searchDetail.SearchButtons = new InventorySearchButtons();                
                return searchDetail;
            }

            if(typeof(T)== typeof(SalesOrder))
            {
                searchDetail.SearchText = "Sales Order Search";
                searchDetail.StoredProcedure = "srch_SO_Shipping";
                searchDetail.IdColumn = "id";
                searchDetail.EditFormType = typeof(shippingForm);
                return searchDetail;                
            }

            if (typeof(T) == typeof(Transaction))
            {
                searchDetail.SearchText = "Transaction Search";
                searchDetail.StoredProcedure = "srch_transaction_search";
                searchDetail.IdColumn = null;
                searchDetail.EditFormType = null;
                searchDetail.SearchButtons = new UnitHistorySearchButtons();
                return searchDetail;
            }

            if(typeof(T) == typeof(Part))
            {
                searchDetail.SearchText = "Parts Search";
                searchDetail.StoredProcedure = "srch_Parts";
                searchDetail.IdColumn = "Id";
                searchDetail.EditFormType = typeof (PartEditForm);
                return searchDetail;
            }

            if(typeof(T) == typeof(Tote))
            {
                searchDetail.SearchText = "Tote Search";
                searchDetail.StoredProcedure = "srch_totes";
                searchDetail.IdColumn = "area_id";
                searchDetail.EditFormType = typeof (ToteManagerForm);
                return searchDetail;
            }

            if(typeof(T) == typeof(ServiceRoute))
            {
                searchDetail.SearchText = "Service route search";
                searchDetail.StoredProcedure = "srch_routes";
                searchDetail.IdColumn = "id";
                searchDetail.EditFormType = typeof (RouteBuilderForm);
                return searchDetail;
            }

            if(typeof(T) == typeof(InventoryCapture))
            {
                searchDetail.SearchText = "Inventory capture search";
                searchDetail.StoredProcedure = "srch_inventory_captures";
                searchDetail.IdColumn = "id";
                searchDetail.EditFormType = typeof(InventoryCaptureManager);
                return searchDetail;
            }

            if(typeof(T) == typeof(PartFamily))
            {
                searchDetail.SearchText = "Part Family Search";
                searchDetail.StoredProcedure = "srch_part_families";
                searchDetail.IdColumn = "id";
                searchDetail.EditFormType = typeof(PartFamilyForm);
                return searchDetail;
            }

            if(typeof(T) == typeof(MaterialPurchaseOrder))
            {
                searchDetail.SearchText = "Material Purchase Order Search";
                searchDetail.StoredProcedure = "srch_material_purchase_orders";
                searchDetail.IdColumn = "id";
                searchDetail.EditFormType = typeof(MaterialsPurchaseOrderForm);
                return searchDetail;                
            }

            return null;           
        }        
    }  
}