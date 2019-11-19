using System;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.InputCommands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unit = this.Data[1];

            try
            {
                this.Repository.RemoveUnit(unit);
                return $"{unit} retired!";
            }
            catch(ArgumentException ae)
            {
                return ae.Message;
            }
        }
    }
}
