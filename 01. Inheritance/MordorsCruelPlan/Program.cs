using System;
using System.Dynamic;
using System.Linq;

namespace MordorsCruelPlan
{
    public class Program
    {
        static void Main(string[] args)
        {
            int totalPoints = 0;
            string[] input = Console.ReadLine().ToLower().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Happiness mood = new Happiness();
            mood.GenerateFood(input);
            
            Console.WriteLine(mood.ToString());

        }

      
    }
}
