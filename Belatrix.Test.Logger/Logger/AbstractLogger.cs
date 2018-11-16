using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Logger
{
    public abstract class AbstractLogger
    {
        public abstract void Log(string messgae, LogType logType);
    }
}
