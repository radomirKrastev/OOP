namespace MXGP.Models.Motorcycles
{
    using System;
    using Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double ModelCubicCentimeters = 125;
        private const int MinimumHorsePower = 50;
        private const int MaximumHorsePower = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, ModelCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;

            protected set
            {
                if (value < MinimumHorsePower || value > MaximumHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
