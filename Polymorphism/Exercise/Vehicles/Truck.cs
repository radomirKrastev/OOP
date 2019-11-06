namespace Vehicles
{
    using System;

    public class Truck : Vehicle
    {
        private const double AdditionalConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AdditionalConsumption, tankCapacity)
        {
        }

        public override void Refuel(double additionalFuel)
        {
            base.Refuel(additionalFuel);

            this.FuelQuantity += (additionalFuel * 0.95)-additionalFuel;
        }
    }
}
