namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.Players.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.Players.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            this.players.Remove(player);
            return true;
        }
    }
}
