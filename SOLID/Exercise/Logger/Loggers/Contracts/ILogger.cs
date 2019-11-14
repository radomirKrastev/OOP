namespace Logger.Loggers.Contracts
{
    using System.Collections.Generic;
    using global::Logger.Appenders.Contracts;

    public interface ILogger
    {
        List<IAppender> Appenders { get; }
    }
}
