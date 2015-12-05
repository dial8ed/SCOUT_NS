using System;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Mvc;

namespace SCOUT.Core.Services
{
    /// <summary>
    /// Simple class for running action delegates and raising user messages
    /// from those actions.
    /// </summary>
    public class ActionService : IUserMessageGenerator
    {
        public event EventHandler<UserMessageEventArgs> MessageRaised;
        private MessageListener m_messageListener;
        

        /// <summary>
        /// Validates an action can be run then runs the action if so. 
        /// </summary>
        /// <typeparam name="TValidator">A validator that derives from ValidatorBase</typeparam>
        /// <typeparam name="TModel">The model to be validated</typeparam>
        /// <param name="validator">Validator instance</param>
        /// <param name="action">Delegate to call if validation passes</param>
        public void RunAction<TModel>(object sender,
            ModelValidator<TModel> validator,
            EventHandler<ActionRequestEventArgs> action)           
        {
            if (!validator.IsValid())
                return;

            RunAction(sender, action);
        }


        /// <summary>
        /// Runs an action and raises any user messages encountered during the action
        /// </summary>
        /// <param name="action"></param>
        public void RunAction(object sender, EventHandler<ActionRequestEventArgs> action)
        {
            ActionRequestEventArgs args = new ActionRequestEventArgs();
            action(sender, args);

            if(args.UserMessage != null)
                RaiseMessage(sender, args.UserMessage);            
        }     
   
        /// <summary>
        /// Fires a MessageRaised event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="userMessage"></param>
        private void RaiseMessage(object sender,UserMessage userMessage)
        {
            if(MessageRaised != null)
                MessageRaised(sender, new UserMessageEventArgs(userMessage));
            
        }
    }
}