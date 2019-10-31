namespace Shapes
{
    using System;
    using System.Text;

    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public string Draw()
        {
            var output = new StringBuilder();
            output.Append(this.DrawLine());
            output.AppendLine();

            for (int h = 1; h < this.height - 1; h++)
            {
                for (int w = 0; w < this.width; w++)
                {
                    if (w == 0 || w == this.width - 1)
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

            output.AppendLine(this.DrawLine());

            return output.ToString().TrimEnd();
        }

        private string DrawLine()
        {
            var output = new StringBuilder();

            for (int i = 0; i < this.width; i++)
            {
                output.Append("*");
            }

            return output.ToString().TrimEnd();
        }
    }
}
