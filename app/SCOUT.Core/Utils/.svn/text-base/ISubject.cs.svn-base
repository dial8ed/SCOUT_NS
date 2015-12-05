namespace SCOUT.Core.Data
{
    public interface ISubject
    {
        // Registers an observer to the subjects notification list
        void RegisterObserver(IObserver observer);

        // Removes a registered observer from the subjects notification list
        void UnregisterObserver(IObserver observer);

        // Notifies the observers in the notification list of any changes that occurered in the subject
        void NotifyObservers();
    }
}