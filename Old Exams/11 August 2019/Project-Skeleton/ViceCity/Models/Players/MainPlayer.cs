namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int InitialLifePoints = 100;
        private const string OnlyName = "Tommy Vercetti";

        public MainPlayer() 
            : base(OnlyName, InitialLifePoints)
        {
        }
    }
}
