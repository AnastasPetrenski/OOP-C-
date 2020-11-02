using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public virtual string Name 
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

        public virtual decimal Money 
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> Bag => this.bag;

        public bool AddProduct(Product product)
        {
            if (this.money >= product.Price)
            {
                this.money -= product.Price;
                this.bag.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string result = this.Bag.Count > 0
                ? $"{this.Name} - {string.Join(", ", this.Bag)}"
                : $"{this.Name} - Nothing bought";
            return result;
        }
    }
}
