namespace SCOUT.Core.Data
{
    public class PartReplacementValidator : ValidatorBase
    {
        private ReplacementComponentFacts m_facts;

        public PartReplacementValidator(ReplacementComponentFacts facts)
        {
            m_facts = facts;
        }

        public override void GetError()
        {
            if(!MaterialCanBeConsumed(m_facts)) return;

            if(!CommodityComponentIsValid(m_facts)) return;

            if (!PartInIsValid(m_facts)) return;

            if (!PartInSnIsValid(m_facts)) return;

            if (!PartOutIsValid(m_facts)) return;

            if (!PartOutSnIsValid(m_facts)) return;

            if (RepairAlreadyContainsComponent(m_facts)) return;
        }

        private bool MaterialCanBeConsumed(ReplacementComponentFacts facts)
        {
            return facts.PartIn.DisableMaterialsTracking == false;            
        }

        private bool CommodityComponentIsValid(ReplacementComponentFacts facts)
        {
            if(facts.Component == null && facts.Repair.ArePartsRequired)
            {
                m_error = "Component Type is required.";
                return false;
            }

            return true;
        }

        private bool RepairAlreadyContainsComponent(ReplacementComponentFacts facts)
        {
           if(facts.Repair.ContainsReplacement(facts))
           {
               m_error = "A replacement with the same data already exists.";
               return true;
           }

            return false;
            
        }

        private bool PartOutSnIsValid(ReplacementComponentFacts facts)
        {
            if (facts.PartOut.IsSerialized() && string.IsNullOrEmpty(facts.SerialNumberIn))
            {
                m_error = "The [Part Out] serial number is required.";
                return false;
            }

            return true;
        }

        private bool PartOutIsValid(ReplacementComponentFacts facts)
        {
            if (facts.PartOut == null)
            {
                m_error = "The [Part Out] part number is not valid";
                return false;
            }

            return true;   
        }

        private bool PartInSnIsValid(ReplacementComponentFacts facts)
        {
            if(facts.PartIn.IsSerialized() && string.IsNullOrEmpty(facts.SerialNumberIn))
            {
                m_error = "The [Part In] serial number is required.";
                return false;
            }

            return true;
        }

        private bool PartInIsValid(ReplacementComponentFacts facts)
        {
            if (facts.PartIn == null)
            {
                m_error = "The [Part In] part number is not valid";
                return false;
            }
                
            return true;                
        }
    }
}