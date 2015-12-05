namespace SCOUT.Core.Data
{
    public class LineItemClosedShort : LineItemState
    {
        public override bool CanCancel()
        {
            RaiseMessage("Change Cancelled: This line cannot be cancelled because it is closed short.");
            return false;
        }

        public override bool CanClose()
        {
            RaiseMessage("Change Cancelled: This line cannot be closed because it is closed short.");
            return false;
        }

        public override bool CanOpen()
        {
            return true;
        }

        public override bool CanCloseShort()
        {
            return true;
        }

        public override bool CanDelete()
        {
            return false;
        }

        public override bool CanChangePart(ILineItem lineItem, Part newPart)
        {
            RaiseMessage("Change Cancelled: This lines part cannot be changed because it is closed short.");
            return false;
        }

        public override bool CanChangeQty(ILineItem lineItem, int qty)
        {            
            RaiseMessage("Change Cancelled: This lines qty cannot be changed because it is closed short.");
            return false;
        }
    }
}