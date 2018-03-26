using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public interface ILoggerWapper
    {
        void LogTrace(string message);

        void LogDebug(string message);

        void LogInfo(string message);

        void LogWarn(string message);

        void LogError(string message);

        void LogFatal(string message);

        void Log(string message, LogMessageLevel level);

        void LogError(Exception ex, string message = null);
    }
}
