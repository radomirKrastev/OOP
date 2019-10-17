namespace RawData.CarParts
{
    public class TireSet
    {
        public TireSet (Tire [] tires)
        {
            this.Tires = tires;
        }

        public Tire[] Tires { get; private set; }
    }
}
