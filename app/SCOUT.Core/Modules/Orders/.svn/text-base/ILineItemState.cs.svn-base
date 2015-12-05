namespace SCOUT.Core.Data
{
    public interface ILineItemState
    {
        /// <summary>
        /// Verifies that a line item part change is valid
        /// </summary>
        /// <param name="lineItem">The line item being changed</param>
        /// <param name="newPart">The new part for the line item</param>
        /// <returns></returns>
        bool CanChangePart(ILineItem lineItem, Part newPart);

        /// <summary>
        /// Verifies that a line item qty change is valid
        /// </summary>
        /// <param name="lineItem">The line item being adjusted</param>
        /// <param name="adjustedQty">The adjusted qty for the line item</param>
        /// <returns></returns>
        bool CanChangeQty(ILineItem lineItem, int adjustedQty);
        bool CanCancel();
        bool CanClose();
        bool CanOpen();
        bool CanCloseShort();
        bool CanChangeStatusTo(LineItemStatus status);
    }
}