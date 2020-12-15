using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            SiniorManager siniorManager = new SiniorManager("Nasko", "Sinior");
            JuniorManager juniorManager = new JuniorManager("Krisko", "Junior");
            SetLevel(siniorManager);
            SetLevel(juniorManager);
            siniorManager.SetLevel(juniorManager);
        }

        public static void SetLevel(IManager manager)
        {
            IManager newManager = manager as SiniorManager;

            if (newManager is JuniorManager)
            {
                Console.WriteLine("Access denied");
            }
            else if(newManager is SiniorManager)
            {
                var sss = newManager.GetType().Name;
                Console.WriteLine(sss);
            }

        }
    }
}
