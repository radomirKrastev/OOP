namespace RawData.CarParts
{
    public class Tire
    {
        public Tire(double pressure, int year )
        {
            this.Pressure = pressure;
            this.Year = year;
        }

        public double Pressure { get; private set; }
        public int Year { get; private set; }
    }
}
