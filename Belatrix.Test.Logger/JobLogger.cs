using System.Configuration;
using Belatrix.Test.Logger.Constants;
using Belatrix.Test.Logger.Interface;
using Belatrix.Test.Logger.Logger;

namespace Belatrix.Test.Logger
{
    /// <summary>
    /// Job logger is a simple logger
    /// It could be configure as a text file logger, console logger or database logger
    /// </summary>
    public class JobLogger : IJobLogger
    {
        private static readonly object loggerLock = new object();
       
        private static JobLogger instance;
        /// <summary>
        /// Gets the instance of JobLogger.
        /// </summary>
        /// <value>The instance.</value>
        public static JobLogger Instance {
            get
            {
                if (instance == null)
                {
                    lock (loggerLock)
                    {
                        instance = new JobLogger();
                    }
                }
                return instance;
            }
        }      


        /// <summary>
        /// The logger console.
        /// </summary>
        private readonly ILogger loggerConsole = new LoogerConsole();

        /// <summary>
        /// The logger text.
        /// </summary>
        private readonly ILogger loggerText = new LoogerText();

        /// <summary>
        /// The logger database.
        /// </summary>
        private readonly ILogger loggerDatabase = new LoggerDatabase();
             

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogError(string message)
        {
            loggerText.Log(message, LogType.Error);
            loggerDatabase.Log(message, LogType.Error);
            loggerConsole.Log(message, LogType.Error);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogInfo(string message)
        {
            loggerText.Log(message, LogType.Info);
            loggerDatabase.Log(message, LogType.Info);
            loggerConsole.Log(message, LogType.Info);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogWarning(string message)
        {
            loggerText.Log(message, LogType.Warning);
            loggerDatabase.Log(message, LogType.Warning);
            loggerConsole.Log(message, LogType.Warning);
        }
    }
}
