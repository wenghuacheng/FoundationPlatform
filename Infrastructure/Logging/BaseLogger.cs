using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public abstract class BaseLogger : ILoggerWapper
    {
        public void Log(string message, LogMessageLevel level)
        {
            switch (level)
            {
                case LogMessageLevel.Trace:
                    LogTrace(message);
                    break;
                case LogMessageLevel.Info:
                    LogInfo(message);
                    break;
                case LogMessageLevel.Warn:
                    LogInfo(message);
                    break;
                case LogMessageLevel.Debug:
                    LogDebug(message);
                    break;
                case LogMessageLevel.Error:
                    LogError(message);
                    break;
                case LogMessageLevel.Fatal:
                    LogFatal(message);
                    break;
            }
        }

        public abstract void LogDebug(string message);

        public abstract void LogError(string message);

        public abstract void LogFatal(string message);

        public abstract void LogInfo(string message);

        public abstract void LogTrace(string message);

        public abstract void LogWarn(string message);

        public abstract void LogError(Exception ex, string message = null);
    }
}
