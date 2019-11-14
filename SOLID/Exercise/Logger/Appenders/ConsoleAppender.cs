namespace Logger.Appenders
{
    using System;
    using Enum;
    using Layouts.Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public override string Format => "Appender type: {0}," +
            " Layout type: {1}," +
            " Report level: {2}," +
            " Messages appended: {3}";

        public override ReportLevel ReportLevel { get; set; }

        public override void Append(string date, ReportLevel errorLevel, string message)
        {
            if (errorLevel >= this.ReportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, date, errorLevel, message));
            }            
        }
    }
}
