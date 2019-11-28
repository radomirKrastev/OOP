namespace MortalEngines.Core
{
    using System;
    using Contracts;    

    public class Engine : IEngine
    {
        private ICommandProcessor commandProcessor;

        public Engine()
        {
            this.commandProcessor = new CommandProcessor();
        }

        public void Run()
        {   
            string command = Console.ReadLine();

            while (command != "Quit")
            {
                this.commandProcessor.ExecuteCommand(command);

                command = Console.ReadLine();
            }
        }
    }
}
