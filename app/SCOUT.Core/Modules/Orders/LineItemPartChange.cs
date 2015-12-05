namespace SCOUT.Core.Data
{
    public class LineItemPartChange : ValidatorBase
    {
        private ILineItem m_lineItem;
        private Part m_newPart;

        public LineItemPartChange(ILineItem lineItem, Part newPart)
        {
            m_lineItem = lineItem;
            m_newPart = newPart;
        }

        public override void GetError()
        {
            if (m_lineItem.ProcessedQty > 0)
                m_error = "This lines part cannot be changed because it has processed units.";

        }
    }
}