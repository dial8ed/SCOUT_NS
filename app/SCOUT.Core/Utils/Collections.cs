using System.Collections.Generic;

namespace SCOUT.Core
{
    public static class Collections
    {
        public static T[] ToArray<T>(ICollection<T> collection)
        {         
            T[] localArray = new T[collection.Count];
            collection.CopyTo(localArray,0);
            return localArray;   
        }               
    }
}