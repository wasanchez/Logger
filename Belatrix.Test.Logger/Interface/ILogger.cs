using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Interface
{
    public interface ILogger
    {
       void Log(string message, LogType logType);
    }
}
