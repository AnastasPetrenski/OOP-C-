using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int capacity = 10;
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>(capacity);
        }

        public Pizza(string name, Dough dough)
            : this(name)
        {
            this.Dough = dough;
        }

        public int NumberOfToppings => this.toppings.Count;

        public string TotalCalories => this.CalculateCalories();

        public string Name 
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length <= 0 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value; 
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (capacity <= this.toppings.Count)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        private string CalculateCalories()
        {
            var toppingsCalories = toppings.Sum(t => t.CalculateCalories());
            var doughCalories = this.Dough.CalculateCalories();
            return $"{toppingsCalories + doughCalories:F2}";
        }

        public override string ToString()
        {
            return $"{this.name} - {this.CalculateCalories()} Calories.";
        }
    }
}
