using System;
using System.Collections.Generic;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            PrefferedFoods = new List<Type>() { typeof(Meat) };
        }

        public override double WeightMultiplier => AnimalsFoodWeightConstatnts.OWL_FOOD_WEIGHT;

        public override ICollection<Type> PrefferedFoods { get; protected set; }

        public override string EatingSound()
        {
            return AnimalSoundConstants.OWL_HUNGRY_SOUND;
        }
    }
}
