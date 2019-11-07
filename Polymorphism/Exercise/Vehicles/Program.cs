namespace Vehicles
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var vehicles = new Vehicle[3];

            for (int i = 0; i < 3; i++)
            {
                var carInformation = Console.ReadLine();
                vehicles[i] = VehicleFactory.InitializeVehicle(carInformation);
            }

            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var commandParts = Console.ReadLine().Split(" ");
                var command = commandParts[0];
                var vehicleType = commandParts[1];

                if (command == "Drive")
                {
                    var distance = double.Parse(commandParts[2]);

                    var vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                    Console.WriteLine(vehicle?.Drive(distance));
                }
                else if (command == "DriveEmpty")
                {
                    var distance = double.Parse(commandParts[2]);

                    Bus bus = (Bus)vehicles[2];

                    Console.WriteLine(bus.DriveEmpty(distance));
                }
                else if (command == "Refuel")
                {
                    try
                    {
                        var liters = double.Parse(commandParts[2]);

                        var vehicle = vehicles.FirstOrDefault(x => x.GetType().Name == vehicleType);

                        vehicle.Refuel(liters);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
