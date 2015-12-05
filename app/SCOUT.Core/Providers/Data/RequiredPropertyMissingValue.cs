using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class RequiredPropertyMissingValue : Exception
    {
        public RequiredPropertyMissingValue(VPLiteObject xpObject, string propertyName) 
            : base(string.Format("The {0} property of the {1} object with the id {2} must have a value",
                                 propertyName, xpObject.GetType().Name)){

                                 }
    }
}