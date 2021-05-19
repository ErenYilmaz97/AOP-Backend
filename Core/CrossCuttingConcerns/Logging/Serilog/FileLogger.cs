using Serilog;
using Serilog.Events;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base(

            new LoggerConfiguration()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq("http://localhost:5341/")
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .Enrich.WithProperty("LogType", "FileLog")
        )
        {
            
        }
    }
}