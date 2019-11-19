namespace P03_BarraksWars.Core.InputCommands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
