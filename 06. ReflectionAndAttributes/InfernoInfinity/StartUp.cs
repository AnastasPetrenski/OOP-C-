using InfernoInfinity.Contracts;
using InfernoInfinity.Engines;
using InfernoInfinity.Models;
using InfernoInfinity.WeaponFactories;
using System.Collections.Generic;

namespace InfernoInfinity
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            IEngine engine = new Engine(repository);
            engine.Run();


        }
    }
}
