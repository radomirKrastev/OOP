namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        private string name;
        private Dictionary<string, int> stats;

        public Player(string name, Dictionary<string, int> stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public int Skill => this.GetAverageRating();

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Dictionary<string, int> Stats
        {
            get => this.stats;
            private set
            {
                foreach (var stat in value)
                {
                    if (stat.Value < 0 || stat.Value > 100)
                    {
                        throw new ArgumentException($"{stat.Key} should be between 0 and 100.");
                    }
                }

                this.stats = value;
            }
        }

        private int GetAverageRating()
        {
            var playerTotalRating = 0;

            playerTotalRating += this.Stats["Endurance"];
            playerTotalRating += this.Stats["Sprint"];
            playerTotalRating += this.Stats["Dribble"];
            playerTotalRating += this.Stats["Passing"];
            playerTotalRating += this.Stats["Shooting"];

            var result = Math.Round(playerTotalRating / 5d, MidpointRounding.AwayFromZero);

            return Convert.ToInt32(result);
        }
    }
}
