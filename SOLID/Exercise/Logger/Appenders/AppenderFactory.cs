namespace Logger.Appenders
{
    using System;
    using Appenders.Contracts;
    using Enum;
    using Layouts.Contracts;
    using Logger.Files;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel treshold)
        {
            if (type.ToLower() == "consoleappender")
            {
                var appender = new ConsoleAppender(layout);
                appender.ReportLevel = treshold;
                return appender; 
            }
            else if (type.ToLower() == "fileappender")
            {
                var appender = new FileAppender(layout, new LogFile());
                appender.ReportLevel = treshold;
                return appender;
            }
            else
            {
                throw new ArgumentException("invalid appender!");
            }
        }
    }
}
