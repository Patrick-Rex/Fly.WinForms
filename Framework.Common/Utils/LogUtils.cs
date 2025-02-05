using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using System;
using System.IO;

namespace Framework.Common.Utils
{
    /// <summary>
    /// 日志工具类
    /// </summary>
    public static class LogUtils
    {
        public static void ConfigureLogging(string configFilePath)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName)
                .AddJsonFile(configFilePath, optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
#if DEBUG
                .WriteTo.Console()
#endif
                .CreateLogger();
        }

        public static ILogger GetLogger()
        {
            return Log.Logger;
        }
    }
}
