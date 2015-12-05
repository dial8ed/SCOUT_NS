namespace SCOUT.WinForms.Core
{
    public interface IApplicationController
    {
        ICommand GetCommand(string request, params object[] input);
    }
}