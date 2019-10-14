namespace HotelReservation.Reservations
{
    public class Reservation
    {
        public decimal Price { get; private set; }
        public int Duration { get; private set; }
        public Season Season { get; private set; }
        public DiscountType Discount { get; private set; }
        
        public Reservation(decimal price, int duration, Season season, DiscountType discount)
        {
            this.Price = price;
            this.Duration = duration;
            this.Season = season;
            this.Discount = discount;
        }   
    }
}
