namespace Vehicles
{
    public static class VehicleFactory
    {
        public static Vehicle InitializeVehicle(string vehicleParts)
        {
            var vehicleInformation = vehicleParts.Split();
            var vehicleType = vehicleInformation[0];
            var vehicleFuel = double.Parse(vehicleInformation[1]);
            var vehicleConsumption = double.Parse(vehicleInformation[2]);
            var vehicleTankCapacity = double.Parse(vehicleInformation[3]);

            if (vehicleType == "Car")
            {
                var car = new Car(vehicleFuel, vehicleConsumption, vehicleTankCapacity);
                return car;
            }
            else if (vehicleType == "Truck")
            {
                var truck = new Truck(vehicleFuel, vehicleConsumption, vehicleTankCapacity);
                return truck;
            }
            else
            {
                var bus = new Bus(vehicleFuel, vehicleConsumption, vehicleTankCapacity);
                return bus;
            }
        }
    }
}
