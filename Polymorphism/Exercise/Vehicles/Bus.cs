namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AdditionalConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AdditionalConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            var distancePossible = (this.FuelConsumption - AdditionalConsumption) * distance <= this.FuelQuantity;

            if (distancePossible)
            {
                this.FuelQuantity -= (this.FuelConsumption - AdditionalConsumption) * distance;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }
    }
}
