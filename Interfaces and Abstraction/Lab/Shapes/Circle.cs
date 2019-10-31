﻿namespace Shapes
{
    using System.Text;

    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public string Draw()
        {
            var output = new StringBuilder();

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = (x * x) + (y * y);

                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        output.Append("*");
                    }
                    else
                    {
                        output.Append(" ");
                    }
                }

                output.AppendLine();
            }

            return output.ToString().TrimEnd();
        }
    }
}
