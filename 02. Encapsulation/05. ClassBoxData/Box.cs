using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length 
        {
            get => this.length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        private double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        private double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public string CalculateVolume()
        {
            double result = length * width * height;
            return $"Volume - {result:f2}";
        }

        public string CalculateSurfaceArea()
        {
            double result = ((length * width) + (width * height) + (height * length)) * 2;
            return $"Surface Area - {result:f2}";
        }

        public string CalculateLateralArea()
        {
            double result = ((length * height) + (width * height)) * 2;
            return $"Lateral Surface Area - {result:f2}";
        }
    }
}
