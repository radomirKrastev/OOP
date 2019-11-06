namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AdditionalConsumption = 0.9; 

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
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
