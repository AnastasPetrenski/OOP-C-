
using System;
using System.Collections.Generic;

using WildFarm.Exeptions;
using WildFarm.Models.Contracts;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal, IEatingSoundable, IFeedable
    {
        private const string INVALID_FOOD = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> PrefferedFoods { get; protected set; }

        public abstract string EatingSound();
        public void TryFeeding(IFood food)
        {
            if (!PrefferedFoods.Contains(food.GetType()))
            {
                throw new InvalidFoodExeptionMessage(string.Format(INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

    }
}
