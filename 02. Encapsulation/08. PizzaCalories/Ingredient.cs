using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Ingredient
    {
        protected const int caloriesPerGram = 2;
        protected string type;
        protected double weight;

        public Ingredient(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        protected virtual string Type
        {
            get;
            set;
        }

        protected virtual double Weight
        {
            get;
            set;
        }

        public virtual double CalculateCalories()
        {
            return default;
        }
    }
}
