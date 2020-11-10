using System;
using System.Collections.Generic;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            PrefferedFoods = new List<Type>() { typeof(Fruit), typeof(Vegetable)};
        }

        public override double WeightMultiplier => AnimalsFoodWeightConstatnts.MOUSE_FOOD_WEIGHT;

        public override ICollection<Type> PrefferedFoods { get ; protected set ; }

        public override string EatingSound()
        {
            return AnimalSoundConstants.MOUSE_HUNGRY_SOUND;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
