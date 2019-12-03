namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;
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
                this.IncreaseBegginerAttributes(attackPlayer);
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                this.IncreaseBegginerAttributes(enemyPlayer);
            }

            this.GetHealthBonusFromDeck(attackPlayer);
            this.GetHealthBonusFromDeck(enemyPlayer);
            
            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                int attackerDamage = attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();
                int enemyDamage = enemyPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();

                enemyPlayer.TakeDamage(attackerDamage);

                if (!enemyPlayer.IsDead)
                {
                    attackPlayer.TakeDamage(enemyDamage);
                }
            }
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
