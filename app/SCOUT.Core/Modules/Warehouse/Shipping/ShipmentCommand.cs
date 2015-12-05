using System;
using SCOUT.Core.Providers.Workflow;

namespace SCOUT.Core.Data
{
    public abstract class ShipmentTask
    {
        protected IChainCommand m_next;

        public IChainCommand SetNext(IChainCommand command)
        {            
            m_next = command;
            return m_next;
        }

        protected abstract bool HandleRequest(ShipmentFacts facts);

    }
}