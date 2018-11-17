using System.Configuration;
using System.Data.SqlClient;
using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Logger
{
    public class LoggerDatabase : BaseLogger
    {
        private readonly string _connectionString;
        const string _command = "insert into Log values ({0}, {1})";

        /// <summary>
        /// Log the specified message and logType.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="logType">Log type.</param>
        public override void Log(string message, LogType logType)
        {
            try
            {
                WriteLog(message, logType);
            }
            catch (System.Exception ex)
            {
                base.Log(message, logType);
                base.LogError(string.Format("Error trying to write log into database. Exception: {0}.", ex.ToString()));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Belatrix.Test.Logger.Logger.LoggerDatabase"/> class.
        /// </summary>
        public LoggerDatabase() {
            _connectionString = ConfigurationManager.ConnectionStrings[CommonConstants.DatabaseLogKey].ConnectionString;
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        private void WriteLog(string message, LogType logType) {

            using(var connection = new SqlConnection(_connectionString)) {
                connection.Open();
                //using (var command = new SqlCommand(, connection))
            }
        }


    }
}
