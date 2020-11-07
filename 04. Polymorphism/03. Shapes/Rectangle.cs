using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; private set; }
        public double Width { get; private set; }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
            return (Height + Width) * 2;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
