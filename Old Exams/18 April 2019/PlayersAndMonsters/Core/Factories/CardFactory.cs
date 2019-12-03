namespace PlayersAndMonsters.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            type += "Card";

            Type cardType = (Type)Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToString() == type)
                .FirstOrDefault();

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

            return card;
        }
    }
}
