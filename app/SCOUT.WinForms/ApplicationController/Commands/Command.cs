using System;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Light weight Command
    /// </summary>
    public abstract class Command : ICommand
    {
        private object[] m_input;        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="input"></param>
        protected Command(params object[] input)
        {
            m_input = input;
        }

        /// <summary>
        /// The arguments to be passed to the command object
        /// </summary>
        protected object[] Args
        {
            get { return m_input; }
        }
       
        /// <summary>
        /// Execute the command
        /// </summary>
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}