using System;
using System.Collections.Generic;
using SCOUT.Core.Bus;
using SCOUT.Core.Data;
using SCOUT.Core.Materials.Messages;

namespace SCOUT.Core.Modules.Materials
{
    public class MaterialsConsumptionTracker : IListener<MaterialsPartConsumed>
    {
        private List<PartToConsume> m_partsToConsume;

        public MaterialsConsumptionTracker()
        {
            m_partsToConsume = new List<PartToConsume>();
        }

        public void Process(MaterialsPartConsumed message)
        {

            m_partsToConsume.Add(new PartToConsume(message.Part, message.Qty, BomUsageAction.Install));            
        }

        public List<PartToConsume> GetPartsToConsume()
        {
            return m_partsToConsume;
        }


    }

}