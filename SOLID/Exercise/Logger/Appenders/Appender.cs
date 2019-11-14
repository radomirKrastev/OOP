namespace Logger.Appenders
{
    using Contracts;
    using Enum;
    using Logger.Layouts.Contracts;

    public abstract class Appender : IAppender
    {
        public abstract ReportLevel ReportLevel { get; set; }

        public abstract string Format { get; }

        public ILayout Layout { get; protected set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);        
    }
}
