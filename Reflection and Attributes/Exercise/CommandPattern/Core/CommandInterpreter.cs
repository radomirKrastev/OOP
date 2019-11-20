namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commandExtension = "Command";

            var commandParts = args
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = commandParts[0] + commandExtension;
            var commandData = commandParts.Skip(1).ToArray();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            var commandInstance = (ICommand)Activator.CreateInstance(commandType);

            var result = commandInstance.Execute(commandData);

            return result.ToString();
        }
    }
}
