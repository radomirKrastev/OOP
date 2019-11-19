namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using P03_BarraksWars.Core.InputCommands;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
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
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            Type commandClass = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(x => x.Name.ToLower() == commandName + "command");

            Command commandInstance = (Command)Activator
                .CreateInstance(commandClass, new object[] { data, repository, unitFactory});

            MethodInfo methodInfo = commandClass.GetMethod("Execute");

            string result = (string)methodInfo.Invoke(commandInstance, null);

            return result;
        }
    }
}
