namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (this.Cards.Any(x => x.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.Cards.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            this.cards.Remove(card);
            return true;
        }
    }
}
