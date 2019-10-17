namespace RawData
{
    using System;
    using System.Collections.Generic;
    using CarParts;

    public class InformationParser
    {
        public void Parse(string information, List<Car> cars)
        {
            var parameters = information.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];

            var tire1Pressure = double.Parse(parameters[5]);
            var tire1age = int.Parse(parameters[6]);
            var tire2Pressure = double.Parse(parameters[7]);
            var tire2age = int.Parse(parameters[8]);
            var tire3Pressure = double.Parse(parameters[9]);
            var tire3age = int.Parse(parameters[10]);
            var tire4Pressure = double.Parse(parameters[11]);
            var tire4age = int.Parse(parameters[12]);

            var engine = new Engine(engineSpeed, enginePower);
            var cargo = new Cargo(cargoWeight, cargoType);            

            var tire1 = new Tire(tire1Pressure, tire1age);
            var tire2 = new Tire(tire2Pressure, tire2age);
            var tire3 = new Tire(tire3Pressure, tire3age);
            var tire4 = new Tire(tire4Pressure, tire4age);
            var tireSet = new Tire[4] { tire1, tire2, tire3, tire4 };
            var tires = new TireSet(tireSet);

            var carAdder = new CarAdder();
            carAdder.Add(cars, engine, cargo, tires, carModel);
        }        
    }
}
