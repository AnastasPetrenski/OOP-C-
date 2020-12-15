using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IBakedFood> foods;
        private readonly ICollection<IDrink> drinks;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; }
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }
        public bool IsReserved { get; private set; }
        public decimal Price => this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.drinks.Clear();
            this.foods.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0; //???
        }

        public decimal GetBill()
        {
            return this.foods.Sum(f => f.Price) + this.drinks.Sum(d => d.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            //first check number
            this.NumberOfPeople = numberOfPeople;
            //after that set IsReserved
            this.IsReserved = true; 
        }
    }
}
