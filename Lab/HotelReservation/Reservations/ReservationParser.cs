namespace HotelReservation.Reservations
{
    public class ReservationParser
    {
        public Reservation Parse(string data)
        {
            var dataParts = data.Split();

            var price = decimal.Parse(dataParts[0]);
            var days = int.Parse(dataParts[1]);
            var seasonType = dataParts[2];

            var season = Season.Autumn;
            
            if (seasonType == "Spring")
            {
                season = Season.Spring;
            }
            else if (seasonType == "Winter")
            {
                season = Season.Winter;
            }
            else if (seasonType == "Summer")
            {
                season = Season.Summer;
            }

            var discount = DiscountType.None;
            
            if (dataParts.Length == 4)
            {
                var discountType = dataParts[3];
                if (discountType == "VIP")
                {
                    discount = DiscountType.VIP;
                }
                else if (discountType == "SecondVisit")
                {
                    discount = DiscountType.SecondVisit;
                }
            }           

            return new Reservation(price, days, season, discount);
        }
    }
}
