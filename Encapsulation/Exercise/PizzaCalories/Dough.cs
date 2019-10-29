namespace PizzaCalories
{
    using System;
    
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;

        private string flour;
        private string baking;
        private double weight;
        
        public Dough(string flour, string baking, double weight)
        {
            this.Flour = flour;
            this.Baking = baking;
            this.Weight = weight;
        }

        public double Calories => this.GetCaloriesPerGram();

        private double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private string Flour
        {
            get => this.flour;
            set
            {
                switch (value.ToLower())
                {
                    case "wholegrain":
                        this.flour = value;
                        break;
                    case "white":
                        this.flour = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        private string Baking
        {
            get => this.baking;
            set
            {
                switch (value.ToLower())
                {
                    case "crispy":
                        this.baking = value;
                        break;
                    case "chewy":
                        this.baking = value;
                        break;
                    case "homemade":
                        this.baking = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        private double GetCaloriesPerGram()
        {
            double caloriesPerGram = BaseCaloriesPerGram;

            switch (this.Flour.ToLower())
            {
                case "wholegrain":
                    caloriesPerGram *= 1;
                    break;
                case "white":
                    caloriesPerGram *= 1.5;
                    break;
            }

            switch (this.Baking.ToLower())
            {
                case "crispy":
                    caloriesPerGram *= 0.9;
                    break;
                case "chewy":
                    caloriesPerGram *= 1.1;
                    break;
                case "homemade":
                    caloriesPerGram *= 1;
                    break;
            }

            return caloriesPerGram * this.Weight;
        }
    }
}
