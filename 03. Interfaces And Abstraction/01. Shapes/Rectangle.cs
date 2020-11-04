using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; private set; }
        public double Height { get; private set; }

        public string Draw()
        {
            var sb = new StringBuilder();
            sb.Append(DrawLine(this.Width, '*', '*'));
            for (int i = 1; i < this.Height - 1; ++i)
            {
                sb.Append(DrawLine(this.Width, '*', ' '));
            }
            sb.Append(DrawLine(this.Width, '*', '*'));
            return sb.ToString().TrimEnd();
        }

        private string DrawLine(double width, char end, char mid)
        {
            var sb = new StringBuilder();
            sb.Append(end); ;
            for (int i = 1; i < width - 1; ++i)
            {
                sb.Append(mid);
            }
            sb.AppendLine(end.ToString());
            return sb.ToString();
        }
    }
}
