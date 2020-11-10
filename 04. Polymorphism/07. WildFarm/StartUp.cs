using System;
using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm.Engine
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
