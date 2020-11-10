using System;
using System.Collections.Generic;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            PrefferedFoods = new List<Type>() { typeof(Meat) };
        }

        public override double WeightMultiplier => AnimalsFoodWeightConstatnts.TIGER_FOOD_WEIGHT;

        public override ICollection<Type> PrefferedFoods { get; protected set; }

        public override string EatingSound()
        {
            return AnimalSoundConstants.TIGER_HUNGRY_SOUND;
        }
    }
}
