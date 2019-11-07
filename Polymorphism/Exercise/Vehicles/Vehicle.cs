namespace Vehicles
{
    using System;

    public class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        
        public double TankCapacity { get; protected set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }                
            }
        }

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
            if (additionalFuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (this.FuelQuantity + additionalFuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {additionalFuel} fuel in the tank");
            }

            this.FuelQuantity += additionalFuel;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
