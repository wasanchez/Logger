using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Logger
{
    /// <summary>
    /// Looger text.
    /// </summary>
    public class LoggerText : BaseLogger
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Belatrix.Test.Logger.Logger.LoogerText"/> is text
        /// file enabled.
        /// </summary>
        /// <value><c>true</c> if is text file enabled; otherwise, <c>false</c>.</value>
        private bool IsTextFileEnabled
        {
            get
            {
                return IsLoggerEnabled && Support.Contains(LoggingSupport.TextFile.ToString("G").ToLower());
            }
        }

        /// <summary>
        /// Log the specified message and logType.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="logType">Log type.</param>
        public override void Log(string message, LogType logType)
        {
            if (!IsTextFileEnabled)
                return;
            base.Log(message, logType);
        }

    }
}
