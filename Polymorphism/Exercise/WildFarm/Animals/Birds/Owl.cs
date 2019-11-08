namespace WildFarm.Animals.Birds
{
    using System;
    using Foods;

    public class Owl : Bird
    {
        private const double DefaultWeightGain = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightGainPerFoodPiece => DefaultWeightGain;

        public override string Speak()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            if (food.Type.ToLower() != "meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.Type}!");
            }

            base.Eat(food);
        }
    }
}
