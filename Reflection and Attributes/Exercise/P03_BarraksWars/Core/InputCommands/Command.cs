namespace P03_BarraksWars.Core.InputCommands
{
    using _03BarracksFactory.Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get => this.data;
            private set
            {
                this.data = value;
            }
        }

        public abstract string Execute();
    }
}
