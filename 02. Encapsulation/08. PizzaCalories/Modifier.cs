namespace PizzaCalories
{
    internal static class Modifier
    {
        internal static double GetFlourTypeModifier(string type)
        {
            double modifier = type.ToLower() switch
            {
                "white" => 1.5,
                "wholegrain" => 1.0
            };

            return modifier;
        }

        internal static double GetBackingTechniqueModifier(string backing)
        {
            double modifier = backing.ToLower() switch
            {
                "crispy" => 0.9,
                "chewy" => 1.1,
                "homemade" => 1.0
            };

            return modifier;
        }

        internal static double GetToppingModifier(string topping)
        {
            double modifier = topping.ToLower() switch
            {
                "meat" => 1.2,
                "veggies" => 0.8,
                "cheese" => 1.1,
                "sauce" => 0.9
            };

            return modifier;
        }
    }
}