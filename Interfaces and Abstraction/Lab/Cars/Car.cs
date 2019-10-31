namespace Cars
{
    public class Car : ICar
    {
        private string model;
        private string color;

        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            protected set
            {
                this.model = value;
            }
        }

        public string Color
        {
            get => this.color;
            protected set
            {
                this.color = value;
            }
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }
}
