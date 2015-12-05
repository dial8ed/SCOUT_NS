
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public interface IPassiveView : IUserMessageEnabledView, IUserQuestionEnabledView
    {
        /// <summary>
        /// Gets the event controller responsible for registering, finding, and firing events
        /// A controller will handle these events and sync the model to the view or vice versa.
        /// </summary>
        MvcEventsController EventsController { get; }

        /// <summary>
        /// Closes the view
        /// </summary>
        void Close();
    }
}