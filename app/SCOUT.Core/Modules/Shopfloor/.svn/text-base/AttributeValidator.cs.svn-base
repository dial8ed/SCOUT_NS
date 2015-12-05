using System;
using SCOUT.Core.Data;
using SCOUT.Core.Utils;

namespace SCOUT.Core.Modules.Shopfloor
{
    public class AttributeValidator : ValidatorBase
    {
        public Func<bool> IsValid { get; set; }
        public string InvalidMessage { get; set; }

        public AttributeValidator(Func<bool> isValid, string invalidMessage)
        {
            IsValid = isValid;
            InvalidMessage = invalidMessage;
        }

        public override void GetError()
        {           
            if (!IsValid())
                Error = InvalidMessage;

        }

    }

}