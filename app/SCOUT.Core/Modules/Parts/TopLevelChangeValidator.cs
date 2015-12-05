namespace SCOUT.Core.Data
{
    public class TopLevelChangeValidator : ValidatorBase
    {
        private Part m_part;
        private bool m_isTopLevel;

        public TopLevelChangeValidator(Part part, bool isTopLevel)
        {
            m_part = part;
            m_isTopLevel = isTopLevel;
        }

        public override void GetError()
        {
            if(m_part.PartFamily != null)
            {
                if (m_isTopLevel)
                {
                    if (m_part.PartFamily.TopLevelPart != null)
                        m_error = "Change Cancelled: This unit is a in a family that already contains a top level part";                           
                }
            }            
        }
    }
}