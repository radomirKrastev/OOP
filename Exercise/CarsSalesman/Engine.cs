namespace CarsSalesman
{
    using System.Text;

    class Engine
    {
        private const string offset = "  ";
        
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, string efficiency) :this (model, power)
        {
            this.Displacement = -1;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model,power,displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model;
        public int Power;
        public int Displacement;
        public string Efficiency;

        public override string ToString()
        {
            StringBuilder engineInformation = new StringBuilder();
            engineInformation.AppendFormat("{0}{1}:\n", offset, this.Model);
            engineInformation.AppendFormat("{0}{0}Power: {1}\n", offset, this.Power);
            engineInformation.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.Displacement == -1 ? "n/a" : this.Displacement.ToString());
            engineInformation.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.Efficiency);

            return engineInformation.ToString();
        }
    }
}
