namespace Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
            : base(model, color)
        {
            this.Model = model;
            this.Color = color;
        }
    }
}
