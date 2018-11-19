using System;
using System.Configuration;
using Belatrix.Test.Logger.Constants;
using Belatrix.Test.Logger.Interface;
using Belatrix.Test.Logger.Logger;

namespace Belatrix.Test.Logger
{
    public class JobLogger : IJobLogger
    {
        private static readonly object loggerLock = new object();
       
        private static JobLogger instance;
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

        private string Support { get; set; }

        private bool IsDatabaseLogger
        {
            get
            {
                return (!string.IsNullOrEmpty(Support) && Support.Contains(LoggingSupport.Database.ToString("G").ToLower()));
            }
        }

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
        private readonly ILogger loggerText = new LoogerConsole();

        /// <summary>
        /// The logger database.
        /// </summary>
        private readonly ILogger loggerDatabase = new LoogerConsole();

        public JobLogger()
        {
            Support = ConfigurationManager.AppSettings[CommonConstants.LoggerSupportKey]?.ToLower();           
        }

        public void LogError(string message)
        {
            if (IsTextFileLogger)
                loggerText.Log(message, LogType.Error);
            if (IsDatabaseLogger)
                loggerDatabase.Log(message, LogType.Error);
            if (IsConsoleLogger)
                loggerConsole.Log(message, LogType.Error);
        }

        public void LogInfo(string message)
        {
            if (IsTextFileLogger)
                loggerText.Log(message, LogType.Info);
            if (IsDatabaseLogger)
                loggerDatabase.Log(message, LogType.Info);
            if (IsConsoleLogger)
                loggerConsole.Log(message, LogType.Info);
        }

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
