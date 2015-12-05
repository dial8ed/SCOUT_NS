namespace SCOUT.Core.Providers
{
    public enum LogType
    {
        Information = 0,
        Warning = 1,
        Error = 2,
        Exception = 3
    }

    public interface ILoggingProvider
    {
        void Log(string message, LogType type);
    }
}