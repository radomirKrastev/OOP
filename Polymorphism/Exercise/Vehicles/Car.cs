namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AdditionalConsumption = 0.9; 

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AdditionalConsumption, tankCapacity)
        {
        }
    }
}
