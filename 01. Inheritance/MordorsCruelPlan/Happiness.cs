using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MordorsCruelPlan
{
    public class Happiness
    {
        private List<FoodPoints> food;
        private string mood;

        public Happiness()
        {
            this.food = new List<FoodPoints>();
        }

        public string GenerateFood(string[] food)
        {
            foreach (var item in food)
            {
                FoodPoints points = FoodFactory.GenerateFood(item);
                this.food.Add(points);
            }

            this.mood = GenerateMood();
            return this.mood;
        }

     
        public string GenerateMood()
        {
            return Mood.GetMood(this.food.Sum(f => f.Points));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"{this.food.Sum(f => f.Points)}")
                .AppendLine(this.mood);
            return sb.ToString();
        }
    }
}
