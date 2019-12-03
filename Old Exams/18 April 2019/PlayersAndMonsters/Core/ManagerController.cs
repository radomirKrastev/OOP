namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
    using Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.BattleFields;

    public class ManagerController : IManagerController
    {
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IBattleField battlefield;

        public ManagerController()
        {
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
            this.battlefield = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(Common.ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battlefield.Fight(attacker, enemy);
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
