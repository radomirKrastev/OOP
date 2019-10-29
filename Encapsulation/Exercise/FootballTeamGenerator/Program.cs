namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var teams = new HashSet<Team>();

            while (command != "END")
            {
                try
                {                    
                    var commandParts = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var teamName = commandParts[1];

                    if (commandParts[0] == "Team")
                    {
                        teams.Add(new Team(teamName));
                    }
                    else if (commandParts[0] == "Add")
                    {
                        ValidateTeam(teams, teamName);

                        var player = CreatePlayer(commandParts);

                        var team = teams.Where(x => x.Name == teamName).First();
                        team.AddPlayer(player);
                    }
                    else if (commandParts[0] == "Remove")
                    {
                        var playerName = commandParts[2];

                        var team = teams.Where(x => x.Name == teamName).First();
                        team.Remove(playerName);
                    }
                    else if (commandParts[0] == "Rating")
                    {
                        ValidateTeam(teams, teamName);

                        var team = teams.Where(x => x.Name == teamName).First();

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }

                    command = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    command = Console.ReadLine();
                }
            }            
        }

        private static Player CreatePlayer(string[] commandParts)
        {
            var playerName = commandParts[2];
            var stats = commandParts.Skip(3).Select(int.Parse).ToArray();

            var playerStats = new Dictionary<string, int>();
            playerStats.Add("Endurance", stats[0]);
            playerStats.Add("Sprint", stats[1]);
            playerStats.Add("Dribble", stats[2]);
            playerStats.Add("Passing", stats[3]);
            playerStats.Add("Shooting", stats[4]);

            return new Player(playerName, playerStats);
        }

        private static void ValidateTeam(HashSet<Team> teams, string teamName)
        {
            if (teams.Where(x => x.Name == teamName).FirstOrDefault() == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
