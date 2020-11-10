using System;
using System.Collections.Generic;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            PrefferedFoods = new List<Type>() { typeof(Meat), typeof(Vegetable) };
        }

        public override double WeightMultiplier => AnimalsFoodWeightConstatnts.CAT_FOOD_WEIGHT;

        public override ICollection<Type> PrefferedFoods { get; protected set; }

        public override string EatingSound()
        {
            return AnimalSoundConstants.CAT_HUNGRY_SOUND;
        }
    }
}
