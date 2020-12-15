using SoftUniRestaurant.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrWhitespaceName);
                }
                name = value;
            }
        }

        public int ServingSize
        {
            get { return servingSize; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ServingLessOrEqualToZero);
                }

                servingSize = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PriceLessOrEqualToZero);
                }
                price = value;
            }
        }

        public override string ToString()
        {
            string format = String.Format("{0}: {1}g - {2:f2}", this.Name, this.ServingSize, this.Price);
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
