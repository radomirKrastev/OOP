namespace RawData
{
    using CarParts;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, TireSet tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.TireSet = tires;
        }

        public string Model;
        public Engine Engine;
        public Cargo Cargo;
        public TireSet TireSet;
    }
}
