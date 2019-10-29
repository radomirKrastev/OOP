namespace PizzaCalories
{
    using System;

    public class Topping
    {
        private const int BaseCaloriesPerGram = 2;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Calories => this.GetCaloriesPerGram();
        
        private double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range[1..50].");
                }

                this.weight = value;
            }
        }

        private string Type
        {
            get => this.type;
            set
            {
                switch (value.ToLower())
                {
                    case "meat":
                        this.type = value;
                        break;
                    case "veggies":
                        this.type = value;
                        break;
                    case "cheese":
                        this.type = value;
                        break;
                    case "sauce":
                        this.type = value;
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        private double GetCaloriesPerGram()
        {
            double caloriesPerGram = BaseCaloriesPerGram;

            switch (this.Type.ToLower())
            {
                case "meat":
                    caloriesPerGram *= 1.2;
                    break;
                case "veggies":
                    caloriesPerGram *= 0.8;
                    break;
                case "cheese":
                    caloriesPerGram *= 1.1;
                    break;
                case "sauce":
                    caloriesPerGram *= 0.9;
                    break;
            }

            return caloriesPerGram  * this.weight;
        }
    }
}
