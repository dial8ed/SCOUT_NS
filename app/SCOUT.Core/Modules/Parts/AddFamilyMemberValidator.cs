namespace SCOUT.Core.Data
{
    public class AddFamilyMemberValidator : ValidatorBase
    {
        private Part m_part;
        private PartFamily m_partFamily;
  
        public AddFamilyMemberValidator(PartFamily partFamily, Part part)
        {
            m_part = part;
            m_partFamily = partFamily;
        }

        public override void GetError()
        {
            if(!PartServiceCommoditiesMatch(m_part, m_partFamily)) return;     
            if(PartExistsInFamily(m_part, m_partFamily)) return;
            if(PartExistsInAnotherFamily(m_part)) return;
            if(ContainsTopLevel(m_part, m_partFamily)) return;
        }

        private bool PartExistsInFamily(Part part, PartFamily family)
        {
            if(!family.ContainsPart(part)) return false;

            m_error = "This part already is a member of this family";
            return false;            
        }
        
        private bool PartExistsInAnotherFamily(Part part)
        {
            if(part.PartFamily == null) return false;

            m_error = "This part belongs to the [ " + part.PartFamily.Label + " ] family and cannot be added to this family";
            return true;
        }

        private bool PartServiceCommoditiesMatch(Part part, PartFamily family)
        {
            if (part.ServiceCommodity.Equals(family.ServiceCommodity))            
                return true;

            m_error = "This part number cannot be added because its service commodity doesnt match the families";
            return false;
                           
        }

        private bool ContainsTopLevel(Part part, PartFamily family)
        {
           
            if (!part.IsTopLevel) return false;

            if (part.IsTopLevel && family.TopLevelPart == null) return false;

            m_error = "You cannot add 2 toplevel part numbers to a part family.";
            return true;
            
        }
    }
}