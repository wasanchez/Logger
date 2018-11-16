using System;
namespace Belatrix.Test.Logger.Interface
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
