using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace Infrastructure.Logging.NLog
{
    public class NLogManager : ILoggerManagerWapper
    {
        public ILoggerWapper GetLogger(string name)
        {
            var logger = LogManager.GetLogger(name);
            return new NLogger(logger);
        }

        public ILoggerWapper GetCurrentClassLogger()
        {
            string name = StackTraceUsageUtils.GetClassFullName();
            var logger = LogManager.GetLogger(name);
            return new NLogger(logger);
        }
    }
}
