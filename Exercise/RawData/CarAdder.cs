namespace RawData
{
    using CarParts;
    using System.Collections.Generic;

    public class CarAdder
    {
        public void Add(List<Car> cars,Engine engine, Cargo cargo, TireSet tires, string model)
        {
            cars.Add(new Car(model, engine, cargo, tires));
        }
    }
}
