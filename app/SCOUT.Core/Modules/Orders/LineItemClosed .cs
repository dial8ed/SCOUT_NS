namespace SCOUT.Core.Data
{
    public class LineItemClosed : LineItemState
    {     
        public override bool CanDelete()
        {
            RaiseMessage("Change Cancelled: This line cannot be deleted because it is closed.");
            return false;
        }

        public override bool CanCloseShort()
        {
            RaiseMessage("Change Cancelled: This line cannot be closed short because it is closed.");
            return false;
        }

        public override bool CanCancel()
        {
            RaiseMessage("Change Cancelled: This line cannot be cancelled because it is closed.");
            return false;
        }

        public override bool CanClose()
        {
            return true;
        }

        public override bool CanOpen()
        {
            return true;

            RaiseMessage("Change Cancelled: This line cannot be opened because it is closed.");
            return false;
        }

        public override bool CanChangePart(ILineItem lineItem, Part newPart )
        {
            RaiseMessage("Change Cancelled: The part of this line cannot be changed because the line is closed.");
            return false;
        }

        public override bool CanChangeQty(ILineItem lineItem, int qty)
        {
            RaiseMessage("Change Cancelled: The qty of this line cannot be changed because the line is closed.");
            return false;
        }        
    }
}