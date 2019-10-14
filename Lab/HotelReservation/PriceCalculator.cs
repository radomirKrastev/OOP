namespace HotelReservation
{
    using Reservations;

    public class PriceCalculator
    {
        public decimal CalculatePrice(Reservation reservation)
        {
            var price = reservation.Price * (int)reservation.Season * reservation.Duration;
            var discount = (price * (int)reservation.Discount) / 100;
            var netPrice = price - discount;
            return netPrice;
        }
    }
}
