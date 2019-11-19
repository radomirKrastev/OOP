namespace P03_BarraksWars.Core.InputCommands
{
    using _03BarracksFactory.Contracts;
    using P03_BarraksWars.Attributes;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        public ReportCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
