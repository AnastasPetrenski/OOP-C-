using System;
using System.Reflection.Metadata.Ecma335;

namespace PizzaCalories
{
    public class Dough : Ingredient
    {
        private string backingType;
        
        
        public Dough(string flourType, string technique, double weight)
            : base(flourType, weight)
        {
            this.BackingType = technique;
        }

        protected override string Type 
        { 
            get => this.type; 
            set
            {
                if (value.ToLower() != Enumerator.white.ToString() &&
                    value.ToLower() != Enumerator.wholegrain.ToString())
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.type = value;
            }
        }

        private string BackingType 
        {
            get => this.backingType;
            set
            {
                if (value.ToLower() != Enumerator.crispy.ToString() &&
                    value.ToLower() != Enumerator.chewy.ToString() &&
                    value.ToLower() != Enumerator.homemade.ToString())
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.backingType = value;
            }
        }

        protected override double Weight 
        {
            get => this.weight;
            set
            {
                if (value <= 0 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public override double CalculateCalories()
        {
            var typeModifier = Modifier.GetFlourTypeModifier(this.Type);
            var backingModifier = Modifier.GetBackingTechniqueModifier(this.BackingType);

            return base.CalculateCalories() + (caloriesPerGram * typeModifier * backingModifier * this.Weight);
        }
    }
}