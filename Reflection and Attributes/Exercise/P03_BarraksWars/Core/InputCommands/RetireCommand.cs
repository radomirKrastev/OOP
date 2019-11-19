namespace P03_BarraksWars.Core.InputCommands
{
    using System;
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.Attributes;
    
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string unit = this.Data[1];

            try
            {
                this.repository.RemoveUnit(unit);
                return $"{unit} retired!";
            }
            catch (ArgumentException ae)
            {
                return ae.Message;
            }
        }
    }
}
