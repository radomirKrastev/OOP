namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        private int battery; 

        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public int Battery
        {
            get => this.battery;
            private set
            {
                this.battery = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} with {this.Battery} Batteries";
        }
    }
}
