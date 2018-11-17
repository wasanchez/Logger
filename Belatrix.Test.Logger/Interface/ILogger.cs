using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Interface
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
        void Log(string message, LogType logType);
    }
}
