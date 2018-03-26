using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace Infrastructure.Logging.NLog
{
    public class NLogger : BaseLogger
    {
        private Logger logger;
        public NLogger(Logger logger)
        {
            this.logger = logger;
        }
        public override void LogDebug(string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public override void LogError(string message)
        {
            logger.Log(LogLevel.Error, message);
        }

        public override void LogError(Exception ex, string message = null)
        {
            logger.Error(ex, message);
        }

        public override void LogFatal(string message)
        {
            logger.Log(LogLevel.Fatal, message);
        }

        public override void LogInfo(string message)
        {
            logger.Log(LogLevel.Info, message);
        }

        public override void LogTrace(string message)
        {
            logger.Log(LogLevel.Trace, message);
        }

        public override void LogWarn(string message)
        {
            logger.Log(LogLevel.Warn, message);
        }
    }
}
