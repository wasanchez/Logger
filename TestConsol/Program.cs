using System;
using Belatrix.Test.Logger.Interface;
using Belatrix.Test.Logger.Logger;

namespace TestConsol
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ILogger logger = new LoogerConsole();
            for (var i = 0; i < 10; i++) {
                logger.LogInfo(string.Format( "Test message {0}", i));
                logger.LogError(string.Format("Test log error message {0}", i));
                logger.LogWarning(string.Format("Test log warning message {0}", i));
            }
        }
    }
}
