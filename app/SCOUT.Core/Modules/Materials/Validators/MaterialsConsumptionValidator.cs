using System.Collections.Generic;
using System.Text;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class MaterialsConsumptionValidator : ModelValidator<MaterialsConsumptionModel>
    {
        
        public MaterialsConsumptionValidator(MaterialsConsumptionModel model, MessageListener listener) : base(model, listener)
        {

        }


        public override void GetError()
        {
            if(HasInvalidConsumptionQtyRequests())
                return;

        }

        private bool HasInvalidConsumptionQtyRequests()
        {
            StringBuilder errorMessage = new StringBuilder();

            foreach (KeyValuePair<MaterialConsumableItem, int> request in Model.ConsumptionRequests)
            {
                if ((request.Key.Qty - request.Value) < 0)
                {
                    errorMessage.AppendLine("Exceeds available qty for " +
                                            request.Key.Part.PartNumber + " request: " + request.Value + " available: " + request.Key.Qty);
                }
            }

            m_error = errorMessage.ToString();

            return m_error.Length > 0;
            
        }
    }
}