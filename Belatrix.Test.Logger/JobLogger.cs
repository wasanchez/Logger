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
        /// Gets or sets the support.
        /// </summary>
        /// <value>The support.</value>
        private string Support { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Belatrix.Test.Logger.JobLogger"/> is database logger.
        /// </summary>
        /// <value><c>true</c> if is database logger; otherwise, <c>false</c>.</value>
        private bool IsDatabaseLogger
        {
            get
            {
                return (!string.IsNullOrEmpty(Support) && Support.Contains(LoggingSupport.Database.ToString("G").ToLower()));
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Belatrix.Test.Logger.JobLogger"/> is text file logger.
        /// </summary>
        /// <value><c>true</c> if is text file logger; otherwise, <c>false</c>.</value>
        private bool IsTextFileLogger
        {
            get
            {
                //By default, It will log in text file
                if (!IsDatabaseLogger && !IsConsoleLogger)
                {
                    return true;
                }
                return (!string.IsNullOrEmpty(Support) && Support.Contains(LoggingSupport.TextFile.ToString("G").ToLower()));
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Belatrix.Test.Logger.JobLogger"/> is console logger.
        /// </summary>
        /// <value><c>true</c> if is console logger; otherwise, <c>false</c>.</value>
        private bool IsConsoleLogger
        {
            get
            {
                return (!string.IsNullOrEmpty(Support) && Support.Contains(LoggingSupport.Console.ToString("G").ToLower()));
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
        /// Initializes a new instance of the <see cref="T:Belatrix.Test.Logger.JobLogger"/> class.
        /// </summary>
        public JobLogger()
        {
            Support = ConfigurationManager.AppSettings[CommonConstants.LoggerSupportKey]?.ToLower();           
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogError(string message)
        {
            if (IsTextFileLogger)
                loggerText.Log(message, LogType.Error);
            if (IsDatabaseLogger)
                loggerDatabase.Log(message, LogType.Error);
            if (IsConsoleLogger)
                loggerConsole.Log(message, LogType.Error);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogInfo(string message)
        {
            if (IsTextFileLogger)
                loggerText.Log(message, LogType.Info);
            if (IsDatabaseLogger)
                loggerDatabase.Log(message, LogType.Info);
            if (IsConsoleLogger)
                loggerConsole.Log(message, LogType.Info);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogWarning(string message)
        {
            if (IsTextFileLogger)
                loggerText.Log(message, LogType.Warning);
            if (IsDatabaseLogger)
                loggerDatabase.Log(message, LogType.Warning);
            if (IsConsoleLogger)
                loggerConsole.Log(message, LogType.Warning);
        }
    }
}
