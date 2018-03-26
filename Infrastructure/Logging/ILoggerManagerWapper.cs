using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging
{
    public interface ILoggerManagerWapper
    {
        ILoggerWapper GetLogger(string name);

        ILoggerWapper GetCurrentClassLogger();
    }
}
