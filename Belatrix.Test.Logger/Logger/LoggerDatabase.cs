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
                if (CanLogAllTypes || IsLogTypeInList(logType))
                {
                    WriteLog(message, logType);
                }
            }
            catch (System.Exception ex)
            {
                base.LogError(string.Format("Error trying to write log into database. Exception: {0}.", ex.ToString()));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Belatrix.Test.Logger.Logger.LoggerDatabase"/> class.
        /// </summary>
        public LoggerDatabase() {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings[CommonConstants.DatabaseLogKey].ConnectionString;
            }
            catch (System.Exception ex)
            {
                base.LogError(string.Format("Error trying to configure the database logger. Exception: {0}", ex.ToString()));
                throw ex;
            }
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        private void WriteLog(string message, LogType logType) {

            using(var connection = new SqlConnection(_connectionString)) {
                //connection.Open();
                //using (var command = new SqlCommand(, connection))
            }
        }


    }
}
