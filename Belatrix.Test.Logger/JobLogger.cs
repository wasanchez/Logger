using System;
using Belatrix.Test.Logger.Interface;
using Belatrix.Test.Logger.Logger;

namespace Belatrix.Test.Logger
{
    public static class JobLogger
    {
        /// <summary>
        /// The logger console.
        /// </summary>
        private static readonly ILogger _loggerConsole = new LoogerConsole();

        /// <summary>
        /// The logger text.
        /// </summary>
        private static readonly ILogger _loggerText = new LoogerConsole();

        /// <summary>
        /// The logger database.
        /// </summary>
        private static readonly ILogger _loggerDatabase = new LoogerConsole();

        static JobLogger()
        {
        }
    }
}
