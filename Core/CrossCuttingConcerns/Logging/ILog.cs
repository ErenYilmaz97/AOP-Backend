namespace Core.CrossCuttingConcerns.Logging
{
    public interface ILog
    {
        void Info(object logMessage);
        void Debug(object logMessage);
        void Verbose(object logMessage);
        void Warning(object logMessage);
        void Error(object logMessage);
        void Fatal(object logMessage);
    }
}