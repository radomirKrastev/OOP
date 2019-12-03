namespace PlayersAndMonsters.Core.Factories
{
    using Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Reflection;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly.GetCallingAssembly().GetType(type);

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
