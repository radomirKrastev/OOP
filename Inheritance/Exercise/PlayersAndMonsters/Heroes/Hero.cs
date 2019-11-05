namespace PlayersAndMonsters.Heroes
{
    public class Hero
    {
        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username
        {
            get => this.username;
            protected set
            {
                this.username = value;
            }
        }

        public int Level
        {
            get => this.level;
            protected set
            {
                this.level = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
