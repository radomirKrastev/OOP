namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int InitialDamage = 5;
        private const int InitialHealth = 80;

        public MagicCard(string name) 
            : base(name, InitialDamage, InitialHealth)
        {
        }
    }
}
