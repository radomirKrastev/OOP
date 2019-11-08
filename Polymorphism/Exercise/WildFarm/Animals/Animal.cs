namespace WildFarm.Animals
{
    using Foods;

    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public virtual double WeightGainPerFoodPiece { get; protected set; }

        public override abstract string ToString();

        public abstract string Speak();

        public virtual void Eat(Food food)
        {
            this.Weight += food.Quantity * this.WeightGainPerFoodPiece;

            this.FoodEaten += food.Quantity;
        }
    }
}
