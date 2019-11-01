namespace BorderControl
{
    using System;

    public abstract class Passer
    {
        public abstract string Id { get; }

        public bool CheckIdValidity(long idLastDigits)
        {
            if (this.Id.EndsWith(idLastDigits.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
