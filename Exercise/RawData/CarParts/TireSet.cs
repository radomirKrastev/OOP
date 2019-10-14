namespace RawData.CarParts
{
    public class TireSet
    {
        public Tire [] Tires { get; private set; }

        public TireSet (Tire [] tires)
        {
            this.Tires = tires;
        }
    }
}
