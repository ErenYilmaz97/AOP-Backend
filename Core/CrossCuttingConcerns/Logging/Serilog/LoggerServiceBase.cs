using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog
{
    public class LoggerServiceBase : ILog
    {
        private readonly ILogger _logger;

        public LoggerServiceBase(LoggerConfiguration loggerConfiguration)
        {
            _logger = loggerConfiguration.CreateLogger();
        }



        public void Info(object logMessage)
        {
            _logger.Information("{@logMessage}", logMessage);
        }


        public void Debug(object logMessage)
        {
            _logger.Debug("{@logMessage}", logMessage);
        }



        public void Verbose(object logMessage)
        {
            _logger.Verbose("{@logMessage}", logMessage);
        }


        public void Warning(object logMessage)
        {
            _logger.Warning("{@logMessage}", logMessage);
        }


        public void Error(object logMessage)
        {
            _logger.Error("{@logMessage}", logMessage);
        }


        public void Fatal(object logMessage)
        {
            _logger.Fatal("{@logMessage}", logMessage);
        }

    }
}