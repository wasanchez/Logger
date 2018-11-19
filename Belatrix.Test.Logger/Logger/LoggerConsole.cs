using System;
using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Logger
{
    /// <summary>
    /// Looger console.
    /// </summary>
    public class LoogerConsole : BaseLogger
    {
        /// <summary>
        /// Log the specified message and logType.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="logType">Log type.</param>
        public override void Log(string message, LogType logType)
        {
            base.Log(message, logType);

            if (base.CanLogAllTypes || IsLogTypeInList(logType))
            {
                Console.ForegroundColor = GetColor(logType);
                Console.WriteLine(GetFormattedMessage(message, logType));
            }
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns>The color.</returns>
        /// <param name="logType">Log type.</param>
        private ConsoleColor GetColor(LogType logType) {
            ConsoleColor color;

            switch (logType)
            {
                case LogType.Info:
                    color = ConsoleColor.White;
                    break;
                case LogType.Error:
                    color = ConsoleColor.Red;
                    break;
                case LogType.Warning:
                    color = ConsoleColor.Yellow;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }
            return color;
        }

    }
}
