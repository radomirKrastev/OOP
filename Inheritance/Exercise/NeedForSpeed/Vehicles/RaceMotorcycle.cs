namespace NeedForSpeed.Vehicles
{
    public class RaceMotorcycle : Motorcycle
    {
        public const double DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
