namespace Logger.Appenders.Contracts
{
    using Enum;
    using Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel treshold);
    }
}
