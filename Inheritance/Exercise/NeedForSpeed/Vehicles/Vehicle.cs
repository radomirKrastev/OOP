namespace NeedForSpeed.Vehicles
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        private int horsePower;
        private double fuel;        

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; protected set; }

        public double Fuel { get; protected set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public void Drive(double kilometers)
        {
            if (this.Fuel - (this.FuelConsumption * kilometers) >= 0)
            {
                this.Fuel -= this.FuelConsumption * kilometers;
            }            
        }
    }
}
