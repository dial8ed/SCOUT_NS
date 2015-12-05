using System.Data;

namespace SCOUT.Core
{
    public static class ObjectExtensions
    {
        public static bool ThrowIfNull(this object instance, string message)
        {            
            if (instance == null)
            {                
                throw new NoNullAllowedException(message);
                return false;
            }

            return true;
        }
    }
}