namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double DefaultWeightGain = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightGainPerFoodPiece => DefaultWeightGain;

        public override string Speak()
        {
            return "Cluck";
        }
    }
}
