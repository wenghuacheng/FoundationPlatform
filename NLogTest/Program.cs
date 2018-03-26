using System;
using System.Text;
using Infrastructure.Logging;
using Infrastructure.Logging.NLog;

namespace NLogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //安装System.Text.Encoding.CodePages，防止中文乱码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ILoggerManagerWapper loggerManager = new NLogManager();
            ILoggerWapper logger = loggerManager.GetCurrentClassLogger();

            logger.LogInfo("Info消息，应该打印到控制台中");
            //logger.LogDebug("Debug消息,应该打印到文件中");

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "异常信息");
            }

            Console.ReadLine();
        }
    }
}
