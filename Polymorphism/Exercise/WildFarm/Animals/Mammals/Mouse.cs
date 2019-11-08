namespace WildFarm.Animals.Mammals
{
    using System;
    using Foods;
    
    public class Mouse : Mammal
    {
        private const double DefaultWeightGain = 0.1;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightGainPerFoodPiece => DefaultWeightGain;

        public override string Speak()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            if (food.Type.ToLower() != "vegetable" && food.Type.ToLower() != "fruit")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.Type}!");
            }

            base.Eat(food);
        }
    }
}
