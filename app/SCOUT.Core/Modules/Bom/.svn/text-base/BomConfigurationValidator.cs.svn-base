using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class BomConfigurationValidator : ModelValidator<BomConfigurationModel>
    {
        public BomConfigurationValidator(BomConfigurationModel model, MessageListener listener) : base(model, listener)
        {

        }

        public override void GetError()
        {
            m_error = Model.Configuration.Error;
            if(!string.IsNullOrEmpty(m_error))
                return;

            if (Model.Configuration.ConfigurationItems.Count == 0)
            {
                m_error = "Bom configuration must contain at least 1 item.";
                return;
            }
                
            foreach (BomConfigurationItem item in Model.Configuration.ConfigurationItems)
            {
                if(!string.IsNullOrEmpty(item.Error))
                {
                    m_error = item.Error;
                    return;
                }
            }
        }
    }
}