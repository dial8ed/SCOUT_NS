using System;

namespace SCOUT.Core.Data
{
    public class RobotRepository
    {
        public static object GetObjectByKey<T>(object id)
        {
            if(typeof(T) == typeof(Part))
            {
                return Part.GetPart((int)id);
            }

            return null;
        }
    }
}