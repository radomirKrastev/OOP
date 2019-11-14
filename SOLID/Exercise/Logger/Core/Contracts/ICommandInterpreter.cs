namespace Logger.Core.Contracts
{
    using Appenders.Contracts;

    public interface ICommandInterpreter
    {
        IAppender ReadAppender();

        void LogMessage(string message);

        void PrintLoggerInfo();
    }
}
