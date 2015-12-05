namespace SCOUT.Core.Data
{
    public class LineItemOpen : LineItemState
    {
        public override bool CanCancel()
        {
            return true;
        }

        public override bool CanClose()
        {
            return true;
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
            return true;
        }

        public override bool CanChangePart(ILineItem lineItem, Part newPart)
        {
            return base.CanChangePart(lineItem, newPart);
        }

        public override bool CanChangeQty(ILineItem lineItem, int qty)
        {
            return base.CanChangeQty(lineItem, qty);
        }
    }
}