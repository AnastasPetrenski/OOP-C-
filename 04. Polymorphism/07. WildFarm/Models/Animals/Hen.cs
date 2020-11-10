using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            PrefferedFoods = new List<Type>() { typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable) };
        }

        public override double WeightMultiplier => AnimalsFoodWeightConstatnts.HEN_FOOD_WEIGHT;

        public override ICollection<Type> PrefferedFoods { get; protected set; } 

        public override string EatingSound()
        {
            return AnimalSoundConstants.HEN_HUNGRY_SOUND;
        }
    }
}
