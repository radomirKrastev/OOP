namespace Vehicles
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var carInformation = Console.ReadLine().Split();
            var carFuel = double.Parse(carInformation[1]);
            var carConsumption = double.Parse(carInformation[2]);
            var carTankCapacity = double.Parse(carInformation[3]);
            
            var car = new Car(carFuel, carConsumption, carTankCapacity);

            var truckInformation = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInformation[1]);
            var truckConsumption = double.Parse(truckInformation[2]);
            var truckTankCapacity = double.Parse(truckInformation[3]);

            var truck = new Truck(truckFuel, truckConsumption, truckTankCapacity);

            var busInformation = Console.ReadLine().Split();
            var busFuel = double.Parse(busInformation[1]);
            var busConsumption = double.Parse(busInformation[2]);
            var busTankCapacity = double.Parse(busInformation[3]);

            var bus = new Bus(busFuel, busConsumption, busTankCapacity);

            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var commandParts = Console.ReadLine().Split(" ");
                var command = commandParts[0];
                var vehicleType = commandParts[1];

                if (command == "Drive")
                {
                    var distance = double.Parse(commandParts[2]);

                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (command == "DriveEmpty")
                {
                    var distance = double.Parse(commandParts[2]);

                    Console.WriteLine(bus.DriveEmpty(distance));
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        var liters = double.Parse(commandParts[2]);

                        if (vehicleType == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
