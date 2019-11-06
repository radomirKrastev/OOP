namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AdditionalConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void Refuel(double additionalFuel)
        {
            base.Refuel(additionalFuel*0.95);
        }

        public override string Drive(double distance)
        {
            var distancePossible = (this.FuelConsumption + AdditionalConsumption) * distance <= this.FuelQuantity;

            if (distancePossible)
            {
                this.FuelQuantity -= (this.FuelConsumption + AdditionalConsumption) * distance;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }
    }
}
