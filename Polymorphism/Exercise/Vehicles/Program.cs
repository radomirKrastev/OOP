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

            var car = new Car(carFuel, carConsumption);

            var truckInformation = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInformation[1]);
            var truckConsumption = double.Parse(truckInformation[2]);

            var truck = new Truck(truckFuel, truckConsumption);

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
                    else if (vehicleType =="Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));                        
                    }
                }
                else if(command == "Refuel")
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
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
