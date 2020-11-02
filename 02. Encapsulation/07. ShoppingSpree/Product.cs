using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        internal string Name 
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                this.name = value;
            }
        }

        internal decimal Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.price = value;
            }
                
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
