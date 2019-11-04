namespace MilitaryElite
{
    using System;
    
    public class Mission
    {
        private string name;
        private string state;

        public Mission(string name, string state)
        {
            this.name = name;
            this.State = state;
        }

        public string Name => this.name;

        public string State
        {
            get => this.state;
            protected set
            {
                switch (value)
                {
                    case "inProgress":
                        this.state = value;
                        break;
                    case "Finished":
                        this.state = value;
                        break;
                    default:
                        throw new ArgumentException("invalid mission state!");
                }
            }
        }

        public void CompleteMission()
        {
            this.state = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
