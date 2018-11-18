using System;
namespace Belatrix.Test.Logger.Constants
{
    public static class CommonConstants
    {
        /// <summary>
        /// The name of the log file text.
        /// </summary>
        public static string LogFileName = "LogFile{0}.txt";
        /// <summary>
        /// The log file text message.
        /// </summary>
        public static string LogFileTextMessage = "{0}|{1}: {2}";

        /// <summary>
        /// The log file directory configuration key.
        /// </summary>
        public static string LogFileDirectoryKey = "LogFileDirectory";

        /// <summary>
        /// The log file date format.
        /// </summary>
        public static string LogFileDateFormat = "ddMMyyyy";

        /// <summary>
        /// The log message date format.
        /// </summary>
        public static string LogMessageDateFormat = "dd-MM-yyyy hh:mm:ss";

        /// <summary>
        /// The log type configuration key.
        /// </summary>
        public static string LogTypeKey = "LogLevelType";

        /// <summary>
        /// The separetors charcters.
        /// </summary>
        public static char[] Separetors = new char[] { ',', ';', '|' };

        /// <summary>
        /// The database log key.
        /// </summary>
        public static string DatabaseLogKey = "DatabaseLogger";
    }
}
