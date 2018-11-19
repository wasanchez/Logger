using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Test.Logger.Interface
{
    public interface IJobLogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
