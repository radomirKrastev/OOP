namespace _03BarracksFactory.Core
{
    using System;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core.InputCommands;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];

                    IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);

                    Type commandType = typeof(Command);

                    MethodInfo methodInfo = commandType.GetMethod("Execute");

                    string result = (string)methodInfo.Invoke(command, null);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
