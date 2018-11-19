using Belatrix.Test.Logger;
using System;

namespace TestConsol
{
    class MainClass
    {
        public static void Main(string[] args)
        {           
            for (var i = 0; i < 10; i++) {
                JobLogger.Instance.LogInfo(string.Format( "Test message {0}", i));
                JobLogger.Instance.LogError(string.Format("Test log error message {0}", i));
                JobLogger.Instance.LogWarning(string.Format("Test log warning message {0}", i));
            }
            Console.ReadKey();
        }
    }
}
