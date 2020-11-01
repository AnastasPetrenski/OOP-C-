using MordorsCruelPlan.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan
{
    public static class FoodFactory
    {
        public static FoodPoints GenerateFood(string food)
        {
            FoodPoints points = food switch
            {
                "cram" => new Cram(),
                "lembas" => new Lembas(),
                "apple" => new Apple(),
                "melon" => new Melon(),
                "honeycake" => new HoneyCake(),
                "mushrooms" => new Mushrooms(),
                _=> new Else()
            };

            return points;
        }
    }
}
          