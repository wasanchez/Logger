using System;
using Belatrix.Test.Logger.Interface;

namespace Belatrix.Test.Logger.Logger
{
    public class LoogerConsole : ILogger
    {
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
