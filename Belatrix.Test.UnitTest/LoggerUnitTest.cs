using System;
using Belatrix.Test.Logger.Interface;
using Belatrix.Test.Logger.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.Test.UnitTest
{
    [TestClass]
    public class LoggerUnitTest
    {
        private IJobLogger loggerText;
        private IJobLogger loggerDatabase;
        private IJobLogger loggerConsole;

        [TestInitialize]
        public void Initialize()
        {
            loggerText = new LoggerText();
            loggerDatabase = new LoggerDatabase();
            loggerConsole = new LoggerConsole();
        }


        [TestMethod]
        [TestCategory("LogTextFileError")]
        [DataRow("A new line in text file as an error log")]
        public void LogTextFileError_TestOk(string message)
        {
            try
            {
                loggerText.LogError(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }

        [TestMethod]
        [TestCategory("LogTextFileInfo")]
        [DataRow("This is an information log")]
        public void LogTextFileInfo_TestOk(string message)
        {
            try
            {
                loggerText.LogInfo(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }


        [TestMethod]
        [TestCategory("LogTextFileWarning")]
        [DataRow("A warning message logged in text file")]
        public void LogTextFileWarning_TestOk(string message)
        {
            try
            {
                loggerText.LogWarning(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }


        [TestMethod]
        [TestCategory("LogConsoleError")]
        [DataRow("An error message in Console")]
        public void LogConsoleError_TestOk(string message)
        {
            try
            {
                loggerConsole.LogError(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }

        [TestMethod]
        [TestCategory("LogConsoleInfo")]
        [DataRow("An information message in Console")]
        public void LogConsoleInfo_TestOk(string message)
        {
            try
            {
                loggerConsole.LogInfo(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }


        [TestMethod]
        [TestCategory("LogConsoleWarning")]
        [DataRow("A warning message logged in Console")]
        public void LogConsoleWarning_TestOk(string message)
        {
            try
            {
                loggerConsole.LogWarning(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }

        [TestMethod]
        [TestCategory("LogDatabaseError")]
        [DataRow("An error message inserted in database")]
        public void LogDatabaseError_TestOk(string message)
        {
            try
            {
                loggerDatabase.LogError(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }

        [TestMethod]
        [TestCategory("LogDatabaseInfo")]
        [DataRow("An Information message inserted in database")]
        public void LogDatabaseInfo_TestOk(string message)
        {
            try
            {
                loggerDatabase.LogInfo(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }


        [TestMethod]
        [TestCategory("LogDatabaseWarning")]
        [DataRow("A warning message inserted in database")]
        public void LogDatabaseWarning_TestOk(string message)
        {
            try
            {
                loggerDatabase.LogWarning(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false,  ex.ToString());
            }
        }
    }
}   
