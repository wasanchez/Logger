using System;
using System.Configuration;
using System.IO;
using System.Threading;
using Belatrix.Test.Logger.Constants;
using Belatrix.Test.Logger.Interface;

namespace Belatrix.Test.Logger.Logger
{
    /// <summary>
    /// Base class logger.
    /// This class write in text file by default.
    /// </summary>
    public class BaseLogger : ILogger, IJobLogger
    {
        private string logLevelTypes = LogType.All.ToString("G").ToLower();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Belatrix.Test.Logger.Logger.BaseLogger"/> is
        /// logger enabled.
        /// </summary>
        /// <value><c>true</c> if is logger enabled; otherwise, <c>false</c>.</value>
        protected bool IsLoggerEnabled { get; set; }

        /// <summary>
        /// Gets or sets the support.
        /// </summary>
        /// <value>The support.</value>
        protected string Support { get; set; }

        /// <summary>
        /// The read write lock slim.
        /// </summary>
        protected readonly ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Belatrix.Test.Logger.Logger.BaseLogger"/> can log all types.
        /// </summary>
        /// <value><c>true</c> if can log all types; otherwise, <c>false</c>.</value>
        protected bool CanLogAllTypes { get { return IsLogTypeInList(LogType.All); } }

        /// <summary>
        /// Log the specified message and logType.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="logType">Log type.</param>
        public virtual void Log(string message, LogType logType)
        {
            if (!IsLoggerEnabled) return;
            
            readerWriterLockSlim.EnterWriteLock();
            try
            {
                if (CanLogAllTypes || IsLogTypeInList(logType))
                {
                    var logMessage = GetFormattedMessage(message, logType);
                    using (StreamWriter file = File.AppendText(GetFileName()))
                    {
                        file.WriteLine(logMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem trying to log the message.", ex.InnerException);
            }
            finally
            {
                readerWriterLockSlim.ExitWriteLock();
            }
        }
          /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogError(string message)
        {
            Log(message, LogType.Error);
        }

        /// <summary>
        /// Logs the info.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogInfo(string message)
        {
            Log(message, LogType.Info);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">Message.</param>
        public void LogWarning(string message)
        {
            Log(message, LogType.Warning);
        }

        /// <summary>
        /// Gets the formatted message.
        /// </summary>
        /// <returns>The formatted message.</returns>
        /// <param name="message">Message.</param>
        /// <param name="logType">Log type.</param>
        protected virtual string GetFormattedMessage(string message, LogType logType)
        {
            var logMessage = string.Format(CommonConstants.LogFileTextMessage, DateTime.Now.ToString(CommonConstants.LogMessageDateFormat), logType.ToString("G"), message);
            return logMessage;
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <returns>The file name.</returns>
        private string GetFileName()
        {
            var directory = ConfigurationManager.AppSettings[CommonConstants.LogFileDirectoryKey];
            directory = string.IsNullOrEmpty(directory) ? CommonConstants.DefaultLogFileDirectory : directory;
            var fileName = string.Format(CommonConstants.LogFileName, DateTime.Now.ToString(CommonConstants.LogFileDateFormat));

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return Path.Combine(directory, fileName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Belatrix.Test.Logger.Logger.BaseLogger"/> class.
        /// </summary>
        public BaseLogger() {
            Configure(); 
        }

        /// <summary>
        /// Configure this instance.
        /// </summary>
        private void Configure(){
            try
            {              
                string logLevel = ConfigurationManager.AppSettings[CommonConstants.LogTypeKey]?.ToLower();
                if (!string.IsNullOrEmpty(logLevel))
                {
                    if (!logLevel.Contains(LogType.All.ToString("G").ToLower()))
                        logLevelTypes = logLevel;
                }
                Support = ConfigurationManager.AppSettings[CommonConstants.LoggerSupportKey]?.ToLower();
                IsLoggerEnabled = !string.IsNullOrEmpty(Support) && !Support.Contains(LoggingSupport.None.ToString("G").ToLower());
            }
            catch (Exception ex)
            {
                Support = string.Empty;
                throw new Exception("Error on configuration logs", ex.InnerException);
            }
        }

        /// <summary>
        /// Ises the log type in list.
        /// </summary>
        /// <returns><c>true</c>, if log type in list was ised, <c>false</c> otherwise.</returns>
        /// <param name="logType">Log type.</param>
        protected bool IsLogTypeInList(LogType logType) {
            return logLevelTypes.Contains(logType.ToString("G").ToLower());
        } 
    }
}
