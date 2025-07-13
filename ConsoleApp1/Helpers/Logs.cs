using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    public class Logs
    {
        public static void ConfigureLogger()
        {
            if (!Directory.Exists(PathConfig.RootFolderLogs))
            {
                Directory.CreateDirectory(PathConfig.RootFolderLogs);
            }

            var outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(PathConfig.LogFilePath, outputTemplate: outputTemplate, rollingInterval: RollingInterval.Day)
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentName()
                .CreateLogger();
        }


        public static void LogInfo(string message)
        {
            Log.Information(message);
        }

        public static void LogWarning(string message)
        {
            Log.Warning(message);
        }

        public static void LogError(string message)
        {
            Log.Error(message);
        }

        public static void LogException(string context, Exception ex)
        {
            Log.Error(ex, context);
        }
    }
}
