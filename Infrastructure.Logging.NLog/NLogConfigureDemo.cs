using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Logging.NLog
{
    /// <summary>
    /// NLog代码配置示例
    /// </summary>
    public class NLogConfigureDemo
    {
        public void Configure()
        {
            var config = new LoggingConfiguration();
                       

            //配置存储方式
            //目标为文件
            var logFile = new FileTarget("logfile");
            logFile.FileName = "file.txt";
            //目标为控制台
            var logConsole = new ConsoleTarget("logconsole");

            //设置存储规则
            //info等级的打印到控制台
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, logConsole));
            //debug等级的打印到文件中
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, logFile));

            LogManager.Configuration = config;
        }
    }
}
