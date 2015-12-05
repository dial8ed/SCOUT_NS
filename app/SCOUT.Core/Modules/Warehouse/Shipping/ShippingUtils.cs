namespace SCOUT.Core.Data
{
    public class ShippingUtils
    {
        public static string GeneratePacklistId()
        {
            Query q = new StoredProc("usp_GenerateNewPacklistId");
            return q.ExecuteSingle<string>();
        }
    }
}