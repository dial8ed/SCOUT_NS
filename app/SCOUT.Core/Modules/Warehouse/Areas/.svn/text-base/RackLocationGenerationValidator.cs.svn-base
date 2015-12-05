namespace SCOUT.Core.Data
{
    public class RackLocationGenerationValidator : ValidatorBase
    {
        private Domain m_domain;
        private Section m_section;
        private int m_numberOfBays;
        private int m_numberOfShelves;
        private int m_startingBay;

        public RackLocationGenerationValidator(Domain domain, Section section, int bays, int shelves, int startingBay)
        {
            m_domain = domain;
            m_section = section;
            m_numberOfBays = bays;
            m_numberOfShelves = shelves;
            m_startingBay = startingBay;
        }

        public override void GetError()
        {
            if(!m_domain.LocatorControlled)
            {
                m_error = "This domain is not locator controlled.";
                return;
            }

            if (StartingBayExists(m_startingBay))
            {
                m_error = "The starting bay for this section already exists.";
                return;    
            }
            
            if(m_numberOfShelves > 999 || m_numberOfBays > 999)
            {
                m_error = "The number of bays or shelves cannot exceed 999.";
                return;
            }                        
        }


        private bool StartingBayExists(int startingBay)
        {
            string bayLabel = startingBay.ToString().PadLeft(3, char.Parse("0"));

            foreach (Bay bay in m_section.Bays)
            {
                if(bay.Label.Equals(bayLabel))
                    return true;
            }

            return false;
        }
    }
}