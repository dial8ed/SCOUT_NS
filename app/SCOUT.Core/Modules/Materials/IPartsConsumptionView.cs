using System.Collections.Generic;
using SCOUT.Core.Data;
using SCOUT.Core.Mvc;

namespace SCOUT.Core.Modules.Materials
{
    public interface IPartsConsumptionView : IPassiveView
    {        
        void SetState(string consumptionDescription, IList<PartToConsume> partsToConsume);
    }
}