using SoftUniRestaurant.Common;
using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private string brand;
        private int servingSize;
        private decimal price;

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
            Brand = brand;
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

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrWhitespaceBrand);
                }
                brand = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:f2}lv";
        }
    }
}
