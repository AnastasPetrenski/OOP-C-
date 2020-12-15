using SoftUniRestaurant.Common;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IFood> foods;
        private ICollection<IDrink> drinks;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foods = new List<IFood>();
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
                    throw new ArgumentException(ExceptionMessages.CapacityLessOrEqualToZero);
                }
                capacity = value;
            }
        }
        public decimal PricePerPerson { get; }
        public int NumberOfPeople
        {
            get { return numberOfPeople; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.PeopleLessOrEqualToZero);
                }
                numberOfPeople = value;
            }
        }
        public bool IsReserved { get; private set; }
        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            if (this.NumberOfPeople == numberOfPeople && !this.IsReserved)
            {
                this.IsReserved = true;
            }
        }

        public void OrderFood(IFood food)
        {
            this.foods.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public decimal GetBill()
        {
            var bill = this.drinks.Sum(d => d.Price) + this.foods.Sum(f => f.Price);

            return bill;
        }

        public void Clear()
        {
            this.drinks.Clear();
            this.foods.Clear();
            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        //•	FoodOrders – collection of foods accessible only by the base class.
        //•	DrinkOrders – collection of drinks accessible only by the base class. 
        //•	TableNumber – int the table number 
        //•	Capacity – int the table capacity(capacity can’t be less than zero.In these cases, throw an ArgumentException with message "Capacity has to be greater than 0")
        //•	NumberOfPeople – int the count of people who want a table(number of people cannot be less or equal to 0. In these cases, throw an ArgumentException with message "Cannot place zero or less people!")
        //•	PricePerPerson – decimal the price per person for the table
        //•	IsReserved – bool returns true if the table is reserved
        //•	Price

    }
}
