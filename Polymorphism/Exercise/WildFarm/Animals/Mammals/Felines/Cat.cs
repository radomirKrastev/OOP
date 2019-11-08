namespace WildFarm.Animals.Mammals.Felines
{
    using System;
    using Foods;

    public class Cat : Feline
    {
        private const double DefaultWeightGain = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightGainPerFoodPiece => DefaultWeightGain;

        public override string Speak()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (food.Type.ToLower() != "vegetable" && food.Type.ToLower() != "meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.Type}!");
            }

            base.Eat(food);
        }
    }
}
