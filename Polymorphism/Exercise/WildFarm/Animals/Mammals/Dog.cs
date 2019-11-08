namespace WildFarm.Animals.Mammals
{
    using System;
    using Foods;

    public class Dog : Mammal
    {
        private const double DefaultWeightGain = 0.4;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightGainPerFoodPiece => DefaultWeightGain;

        public override string Speak()
        {
            return "Woof!";
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
