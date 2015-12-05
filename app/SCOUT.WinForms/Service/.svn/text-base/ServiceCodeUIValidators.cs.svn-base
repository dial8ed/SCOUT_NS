using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public class ServiceCodeUIValidators
    {
        public static void ValidateRow(object sender, ValidateRowEventArgs e, GridControl grid)
        {
            ColumnView currentView = (ColumnView)sender;

            e.Valid = (
                          CodeIsValid(currentView, e) &&
                          IsNotDuplicateCode(currentView, e)
                      );               
        }

       
        private static bool CodeIsValid(ColumnView view, ValidateRowEventArgs e)
        {
            ServiceCode code = e.Row as ServiceCode;
            GridColumn column = view.Columns["Code"];

            if (code != null && code.Code.Length > 0) return true;

            view.SetColumnError(column, "Code is required.");        
            return false;
        }

        private static bool IsNotDuplicateCode(ColumnView view, ValidateRowEventArgs e)
        {
            ServiceCode code = e.Row as ServiceCode;
            GridColumn column = view.Columns["Code"];

            ServiceCode existingCode = Scout.Core.Data.GetUnitOfWork().FindObject<ServiceCode>(
                new BinaryOperator("Code", code.Code));
           
            if(existingCode != null)
            {                
                view.SetColumnError(column, code.Code + " already exists.");                
                return false;
            }

            return true;
        }


    }
}