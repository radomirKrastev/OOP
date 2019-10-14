namespace HotelReservation
{
    using Reservations;
    using System;

    public class Program
    {
        public static void Main()
        {
            var reservationInformation = Console.ReadLine();
            var reservationParser =  new ReservationParser();
            var reservation = reservationParser.Parse(reservationInformation);
            var priceCalculator = new PriceCalculator();
            var holidayCost = priceCalculator.CalculatePrice(reservation);

            Console.WriteLine($"{holidayCost:F2}");
        }
    }
}
