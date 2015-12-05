using System;

namespace SCOUT.Core.Utils
{
    public class ExecutionLoop
    {
        private int m_attempts;

        public int ExecutionCount { get { return m_attempts; } }

        public void TryLoopOn<TException>(Action action, int attempts)
        {
            try
            {
                action();
            }

            catch (Exception ex)
            {
                if (ex is TException)
                {
                    if (m_attempts == attempts)
                    {                        
                        throw;
                    }
                        
                    m_attempts += 1;                    
                    TryLoopOn<TException>(action, attempts);
                }
                    
            }
            
        }

    }
}