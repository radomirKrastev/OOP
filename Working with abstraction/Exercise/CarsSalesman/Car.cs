namespace CarsSalesman
{
    using System.Text;

    class Car
    {
        private const string offset = "  ";
        
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Weight = -1;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            this.Color = color;
        }
        
        public string Model;
        public Engine Engine;
        public int Weight;
        public string Color;

        public override string ToString()
        {
            StringBuilder carInformation = new StringBuilder();
            carInformation.AppendFormat("{0}:\n", this.Model);
            carInformation.Append(this.Engine.ToString());
            carInformation.AppendFormat("{0}Weight: {1}\n", offset, this.Weight == -1 ? "n/a" : this.Weight.ToString());
            carInformation.AppendFormat("{0}Color: {1}", offset, this.Color);

            return carInformation.ToString();
        }
    }
}
