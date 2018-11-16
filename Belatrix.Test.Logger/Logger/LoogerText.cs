using System;
using Belatrix.Test.Logger.Constants;
using Belatrix.Test.Logger.Interface;

namespace Belatrix.Test.Logger.Logger
{
    public class LoogerText : AbstractLogger, ILogger
    {
        public override void Log(string messgae, LogType logType)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }


    }
}
