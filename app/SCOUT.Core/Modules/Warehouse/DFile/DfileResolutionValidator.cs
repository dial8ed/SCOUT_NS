using System;

namespace SCOUT.Core.Data
{
    public class DfileResolutionValidator : ValidatorBase
    {        
        private string m_resolution;
        private DfileAction m_action;
        private Order m_actionOrder;

        public DfileResolutionValidator(string resolution, DfileAction action, Order actionOrder)
        {            
            m_resolution = resolution;
            m_action = action;
            m_actionOrder = actionOrder;
        }


        public override void GetError()
        {

            if(m_action == DfileAction.NoAction)
            {
                m_error = "Action is required.";
                return;
            }

            if(string.IsNullOrEmpty(m_resolution))
            {
                m_error = "Resolution is required.";
                return;
            }

            if(m_actionOrder == null)
            {
                m_error = "Action order is required.";
                return;
            }
            
        }
    }
}