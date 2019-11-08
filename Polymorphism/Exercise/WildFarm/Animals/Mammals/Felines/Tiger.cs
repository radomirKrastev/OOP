namespace WildFarm.Animals.Mammals.Felines
{
    using System;
    using Foods;

    public class Tiger : Feline
    {
        private const double DefaultWeightGain = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightGainPerFoodPiece => DefaultWeightGain;

        public override string Speak()
        {
            return "ROAR!!!";
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
