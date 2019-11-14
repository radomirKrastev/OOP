namespace Logger.Core
{
    using System;
    using System.Text;
    using Appenders;
    using Appenders.Contracts;
    using Contracts;
    using Enum;    
    using Layouts;
    using Loggers;

    public class CommandInterpreter : ICommandInterpreter
    {
        public Logger Logger { get; set; }

        public IAppender ReadAppender()
        {
            var appenderParts = Console.ReadLine().Split(" ");
            var type = appenderParts[0];

            var layoutFactory = new LayoutFactory();
            var layout = layoutFactory.CreateLayout(appenderParts[1]);
            
            var treshold = ReportLevel.INFO;

            if (appenderParts.Length == 3)
            {
                treshold = (ReportLevel)Enum.Parse(typeof(ReportLevel), appenderParts[2]);
            }

            var appenderFactory = new AppenderFactory();
            return appenderFactory.CreateAppender(type, layout, treshold);
        }

        public void LogMessage(string message)
        {
            var messageParts = message.Split("|");
            var error = (ReportLevel)Enum.Parse(typeof(ReportLevel), messageParts[0]);
            var date = messageParts[1];
            var messageText = messageParts[2];

            this.Logger.AppendMessage(date, error, messageText);
        }

        public void PrintLoggerInfo()
        {
            var output = new StringBuilder();
            output.AppendLine("Logger info");
            output.AppendLine();

            foreach (var appender in this.Logger.Appenders)
            {
                output.AppendLine(string.Format(
                    appender.Format,
                    appender.GetType().Name,
                    appender.Layout.GetType().Name,
                    appender.ReportLevel,
                    appender.MessagesCount));

                output.AppendLine();
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }
    }
}
