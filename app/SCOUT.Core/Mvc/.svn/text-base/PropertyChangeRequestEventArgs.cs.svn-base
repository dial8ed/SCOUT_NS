using System;

namespace SCOUT.Core.Mvc
{
    public class PropertyChangeRequestEventArgs<T> :EventArgs
    {
        private T m_requestedValue;


        public PropertyChangeRequestEventArgs(T requestedValue)
        {
            RequestedValue = requestedValue;
        }

        /// <summary>
        /// The requested value. 
        /// Used for synchronizing the model and view.
        /// </summary>
        public T RequestedValue
        {
            get { return m_requestedValue; }
            set { m_requestedValue = value; }
        }
    }
}