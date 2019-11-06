namespace Vehicles
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public virtual string Drive(double distance)
        {
            var distancePossible = this.FuelConsumption * distance <= this.FuelQuantity;

            if (distancePossible)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{GetType().Name} travelled {distance} km";
            }

            return $"{GetType().Name} needs refueling";
        }
        
        public virtual void Refuel(double additionalFuel)
        {
            this.FuelQuantity += additionalFuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
