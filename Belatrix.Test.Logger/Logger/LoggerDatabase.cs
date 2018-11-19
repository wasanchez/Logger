using System.Configuration;
using System.Data.SqlClient;
using Belatrix.Test.Logger.Constants;

namespace Belatrix.Test.Logger.Logger
{
    public class LoggerDatabase : BaseLogger
    {   
        private string ConnectionString { get; set; }
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
                ConnectionString = ConfigurationManager.ConnectionStrings[CommonConstants.DatabaseLogKey].ConnectionString;
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

            using(var connection = new SqlConnection(ConnectionString)) {
                connection.Open();
                using (var command = new SqlCommand(CommonConstants.DatabaseLoggerCmd, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("Message", message));
                    command.Parameters.Add(new SqlParameter("LogType", (int)logType));
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
