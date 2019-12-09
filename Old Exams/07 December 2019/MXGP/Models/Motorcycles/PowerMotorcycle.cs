namespace MXGP.Models.Motorcycles
{
    using System;
    using Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private const double ModelCubicCentimeters = 450;
        private const int MinimumHorsePower = 70;
        private const int MaximumHorsePower = 150;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
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
