namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> squad;

        public Team(string name)
        {
            this.Name = name;
            this.squad = new List<Player>();
        }        

        public int Rating => this.GetTeamRating();

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

        public void AddPlayer(Player player)
        {
            this.squad.Add(player);
        }

        public void Remove(string name)
        {
            if (this.squad.Where(x => x.Name == name).FirstOrDefault() == null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.squad.RemoveAll(x => x.Name == name);
        }

        private int GetTeamRating()
        {
            if (this.squad.Count == 0)
            {
                return 0;
            }

            var playersSkill = 0;

            foreach (var player in this.squad)
            {
                playersSkill += player.Skill;
            }

            var result = Math.Round(playersSkill / this.squad.Count * 1d, MidpointRounding.AwayFromZero);

            return Convert.ToInt32(result);
        }
    }
}
