namespace SCOUT.Core.Mvc
{
    public interface IView
    {
        /// <summary>
        /// Gets the event controller responsible for registering, finding, and firing events
        /// A controller will handle these events and sync the model to the view or vice versa.
        /// </summary>
        MvcEventsController EventsController { get; }

        // Allows a controller to close a view
        void Close();

        // Allows a controller to show a view
        void Show();

        // Allows a controller to hide a view
        void Hide();
    }
}