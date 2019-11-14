namespace Logger.Core
{
    using System;
    using System.Collections.Generic;
    using Appenders.Contracts;
    using Contracts;        
    using Loggers;

    public class Engine : IEngine
    {
        private List<IAppender> appenders;
        private CommandInterpreter commandInterpreter;

        public Engine()
        {
            this.appenders = new List<IAppender>();
            this.commandInterpreter = new CommandInterpreter();
        }

        public void Run()
        {
            var appendersCount = int.Parse(Console.ReadLine());
            AddAllAppenders(appendersCount);

            this.commandInterpreter.Logger = new Logger(this.appenders.ToArray());

            ReadErrorMessages();

            this.commandInterpreter.PrintLoggerInfo();
        }

        private void ReadErrorMessages()
        {
            var message = Console.ReadLine();

            while (message != "END")
            {
                this.commandInterpreter.LogMessage(message);

                message = Console.ReadLine();
            }
        }

        private void AddAllAppenders(int appendersCount)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                this.appenders.Add(this.commandInterpreter.ReadAppender());
            }
        }
    }
}
