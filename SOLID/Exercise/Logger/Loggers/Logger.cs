namespace Logger.Loggers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using global::Logger.Appenders.Contracts;
    using global::Logger.Enum;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders.ToList();
        }

        public List<IAppender> Appenders { get; protected set; }

        public void AppendMessage(string date, ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
    }
}
