using System;
using SCOUT.Core.Providers.Workflow;

namespace SCOUT.Core.Services
{
    public abstract class ChainCommand : IChainCommand
    {
        private IChainCommand m_successor;

        public void SetSuccessor(IChainCommand successor)
        {
            m_successor = successor;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
        
    }
}