namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Reflection;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type playerType = Assembly.GetCallingAssembly().GetType(type);

            IPlayer player = (IPlayer)Activator.CreateInstance(playerType, username);

            return player;
        }
    }
}
