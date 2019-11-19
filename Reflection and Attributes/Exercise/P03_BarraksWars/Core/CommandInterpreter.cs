namespace P03_BarraksWars.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        
        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(x => x.Name.ToLower() == commandName + "command");

            IExecutable command = (IExecutable)Activator
                .CreateInstance(commandType, new object[] { data });

            var fieldsToInject = commandType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetCustomAttributes().Any(ca => ca.GetType() == typeof(Attributes.InjectAttribute)));

            foreach (var field in fieldsToInject)
            {
                var fieldInfo = typeof(CommandInterpreter)
                    .GetField(field.Name, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);

                field.SetValue(command, fieldInfo);
            }

            return command;
        }
    }
}
