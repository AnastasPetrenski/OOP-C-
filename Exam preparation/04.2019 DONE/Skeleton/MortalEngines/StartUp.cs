using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using MortalEngines.Entities.Machines;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            //IPilot pilot = new Pilot("Nasko");
            //IPilot test = null;
            //Fighter mashine = new Fighter("Name", 200, 200);
            //System.Console.WriteLine(mashine.AttackPoints);
            //mashine.ToggleAggressiveMode();
            //System.Console.WriteLine(mashine.AttackPoints);
            //mashine.ToggleAggressiveMode();
            //System.Console.WriteLine(mashine.AttackPoints);
            //if (mashine.Pilot == null)
            //{
            //    mashine.Pilot = pilot;
            //}

            //mashine.Pilot = test;

            IMachinesManager manager = new MachinesManager();
            IWriter writer = new Writer();
            IReader reader = new Reader(manager);
            Engine engine = new Engine(reader, writer);
            engine.Run();

        }
    }
}