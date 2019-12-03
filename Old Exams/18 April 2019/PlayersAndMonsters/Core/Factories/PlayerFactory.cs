namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type playerType = (Type)Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToString() == type)
                .FirstOrDefault();

            ICardRepository cardRepository = new CardRepository();

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType, cardRepository, username);

            return player;
        }
    }
}
