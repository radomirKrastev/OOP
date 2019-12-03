namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                IncreaseBegginerAttributes(attackPlayer);
            }

            if(enemyPlayer.GetType().Name == "Beginner")
            {
                IncreaseBegginerAttributes(enemyPlayer);
            }

            GetHealthBonusFromDeck(attackPlayer);
            GetHealthBonusFromDeck(enemyPlayer);

            //Attack is not implemented yet
        }

        private void IncreaseBegginerAttributes(IPlayer player)
        {
            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }

        private void GetHealthBonusFromDeck(IPlayer player)
        {
            foreach (ICard card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }
    }
}
