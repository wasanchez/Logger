using System;
using Belatrix.Test.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.Test.UnitTest
{
    [TestClass]
    public class JobLoggerTest
    {
        [TestMethod]
        [TestCategory("LogError")]
        [DataRow("An error message log")]
        public void LogTextFileError_TestOk(string message)
        {
            try
            {
                JobLogger.Instance.LogError(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }

        [TestMethod]
        [TestCategory("LogInfo")]
        [DataRow("An information message log")]
        public void LogTextFileInfo_TestOk(string message)
        {
            try
            {
                JobLogger.Instance.LogInfo(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }


        [TestMethod]
        [TestCategory("LogWarning")]
        [DataRow("A warning message log")]
        public void LogTextFileWarning_TestOk(string message)
        {
            try
            {
                JobLogger.Instance.LogWarning(message);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, ex.ToString());
            }
        }

    }
}
