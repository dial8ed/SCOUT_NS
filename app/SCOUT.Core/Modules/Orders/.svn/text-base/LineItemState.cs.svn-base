using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public abstract class LineItemState : ILineItemState
    {  
        public abstract bool CanCancel();

        public abstract bool CanClose();

        public abstract bool CanOpen();

        public abstract bool CanCloseShort();

        public abstract bool CanDelete();

        public bool CanChangeStatusTo(LineItemStatus status)
        {
           switch (status)
           {
               case LineItemStatus.Open:
                   return CanOpen();

               case LineItemStatus.Cancelled:
                   return CanCancel();

               case LineItemStatus.Closed:
                   return CanClose();
                  
               case LineItemStatus.ClosedShort:
                   return CanCloseShort();
                   
           }
            return false;
        }

        public static ILineItemState GetStateForStatus(LineItemStatus status)
        {            
            switch(status)
            {
                case LineItemStatus.Open:
                    return new LineItemOpen();

                case LineItemStatus.Closed:
                    return new LineItemClosed();

                case LineItemStatus.ClosedShort:
                    return new LineItemClosedShort();

                case LineItemStatus.Cancelled:
                    return new LineItemCancelled();
            }

            return null;
        }
        
        public virtual bool CanChangePart(ILineItem lineItem, Part newPart)
        {
            return new 
                LineItemPartChange(lineItem, newPart).Validated();
        }

        public virtual bool CanChangeQty(ILineItem lineItem, int qty)
        {
            return new
                LineItemQtyChange(lineItem, qty).Validated();
        }

        protected void RaiseMessage(string msg)
        {
           Scout.Core.UserInteraction.Dialog.ShowMessage(msg, UserMessageType.Validation);
        }        
    }
}