namespace Logger.Appenders.Contracts
{
    using Enum;
    using Layouts.Contracts;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; }        

        string Format { get; }

        ILayout Layout { get; }

        int MessagesCount { get; }

        void Append(string date, ReportLevel reportLevel, string message);
    }
}
