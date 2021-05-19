using Serilog;
using Serilog.Events;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base(

            new LoggerConfiguration()
                .WriteTo.MSSqlServer
                    ("Server=(localdb)\\Eren;Database=CampAuthDb;Trusted_Connection=true",
                    tableName: "Logs", autoCreateSqlTable: true)
                .WriteTo.Seq("http://localhost:5341/")
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .Enrich.WithProperty("LogType", "DatabaseLog")
                                        )
        {
            
        }
    }
}