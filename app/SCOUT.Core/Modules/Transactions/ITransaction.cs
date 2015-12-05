using System;

namespace SCOUT.Core.Data
{
    public interface ITransaction
    {

        int TransId { get; set; }

        
        string TransType { get; set; }

        
        string LotId { get; set; }
        
        int Qty { get; set; }

        
        string TransRef { get; set; }

        
        DateTime TransDate { get; set; }

        
        string TransBy { get; set; }

        
        string Comments { get; set; }

        
        Part Part { get; set; }

        
        string DepartLocation { get; set; }

       
        string ArrivalLocation { get; set; }
    }
}