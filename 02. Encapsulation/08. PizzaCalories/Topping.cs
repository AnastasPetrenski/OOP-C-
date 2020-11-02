using System;

namespace PizzaCalories
{
    public class Topping : Ingredient
    {

        public Topping(string toppingType, double weight) : base(toppingType, weight)
        {
        }

        protected override string Type
        {
            get => this.type;
            set
            {
                if (value.ToLower() != Enumerator.meat.ToString() &&
                    value.ToLower() != Enumerator.sauce.ToString() &&
                    value.ToLower() != Enumerator.veggies.ToString() &&
                    value.ToLower() != Enumerator.cheese.ToString())
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        protected override double Weight
        {
            get => this.weight;
            set
            {
                if (value <= 0 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public override double CalculateCalories()
        {
            var typeModifier = Modifier.GetToppingModifier(this.Type);

            return base.CalculateCalories() + (caloriesPerGram * typeModifier * this.Weight);
        }
    }
}