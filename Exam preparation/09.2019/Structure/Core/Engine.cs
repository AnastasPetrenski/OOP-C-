using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var result = string.Empty;
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        var type = input[1];
                        var name = input[2];
                        result = controller.AddAstronaut(type, name);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var planetName = input[1];
                        var items = input.Skip(2).ToArray();
                        result = controller.AddPlanet(planetName, items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        var retired = input[1];
                        result = controller.RetireAstronaut(retired);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var planetName = input[1];
                        result = controller.ExplorePlanet(planetName);
                    }
                    else if(input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
