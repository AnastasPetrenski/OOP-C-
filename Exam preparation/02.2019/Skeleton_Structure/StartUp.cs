using SoftUniRestaurant.Models.Foods.Entities;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                Soup soup = new Soup("", 12);

            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

           
        }
    }
}
