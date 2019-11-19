using System;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core
{
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

            return (IExecutable)Activator
                .CreateInstance(commandType, new object[] { data, repository, unitFactory});
        }
    }
}
