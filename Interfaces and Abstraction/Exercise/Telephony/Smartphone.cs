namespace Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : IBrowser, ICaller
    {
        public string Browse(string site)
        {
            if (site.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (number.All(char.IsNumber))
            {
                return $"Calling... {number}";
            }

            throw new ArgumentException("Invalid number!");
        }
    }
}
