
using System;
using System.Collections.Generic;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            PrefferedFoods = new List<Type>() { typeof(Meat) };
        }

        public override double WeightMultiplier => throw new NotImplementedException();

        public override ICollection<Type> PrefferedFoods { get; protected set; }

        public override string EatingSound()
        {
            return AnimalSoundConstants.DOG_HUNGRY_SOUND;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
