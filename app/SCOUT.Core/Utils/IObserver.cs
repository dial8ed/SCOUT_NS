namespace SCOUT.Core
{
    public interface IObserver
    {        
        // Called by the subject to update the observer of any changes
        // The method parameters can be modified to fit certain criteria
        void Update();
    }
}