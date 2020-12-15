using MXGP.Core.Contracts;
using MXGP.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IChampionshipController controller;

        public Engine(IReader reader, IWriter writer, IChampionshipController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "End")
            {
                var result = string.Empty;
                var arguments = input.Split();
                var command = arguments[0];
                try
                {
                    if (command == "CreateRider")
                    {
                        var name = arguments[1];
                        result = this.controller.CreateRider(name);
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        var type = arguments[1];
                        var model = arguments[2];
                        var horsePower = int.Parse(arguments[3]);
                        result = this.controller.CreateMotorcycle(type, model, horsePower);
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        var riderName = arguments[1];
                        var motorcycleModel = arguments[2];
                        result = this.controller.AddMotorcycleToRider(riderName, motorcycleModel);
                    }
                    else if (command == "AddRiderToRace")
                    {
                        var raceName = arguments[1];
                        var riderName = arguments[2];
                        result = this.controller.AddRiderToRace(raceName, riderName);
                    }
                    else if (command == "CreateRace")
                    {
                        var name = arguments[1];
                        var laps = int.Parse(arguments[2]);
                        result = this.controller.CreateRace(name, laps);
                    }
                    else if (command == "StartRace")
                    {
                        var raceName = arguments[1];
                        result = this.controller.StartRace(raceName);
                    }
                }
                catch (Exception e)
                {
                    result = e.Message;
                }
                

                this.writer.WriteLine(result);
            }
        }
    }
}
