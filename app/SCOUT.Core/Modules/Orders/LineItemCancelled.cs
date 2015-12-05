using System;

namespace SCOUT.Core.Data
{
    public class LineItemCancelled : LineItemState
    {
        public override bool CanCancel()
        {
            return true;
        }

        public override bool CanClose()
        {
            RaiseMessage("Change Cancelled: This line cannot be closed because it is cancelled.");
            return false;
        }

        public override bool CanOpen()
        {
            return true;
        }

        public override bool CanCloseShort()
        {
            RaiseMessage("Change Cancelled: This line cannot be closed short because it is cancelled.");
            return false;
        }

        public override bool CanDelete()
        {
            return true;
        }
    }
}