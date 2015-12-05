using System;

namespace SCOUT.Core.Data
{
    public class LineItemQtyChange : ValidatorBase
    {
        private ILineItem m_lineItem;
        private int m_adjustedQty;

        public LineItemQtyChange(ILineItem lineItem, int adjustedQty)
        {
            m_lineItem = lineItem;
            m_adjustedQty = adjustedQty;
        }

        public override void GetError()
        {
            if (m_lineItem.ProcessedQty > m_adjustedQty)
                m_error = "The line item qty cannot be less than the processed qty.";
            
        }
    }
}