using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.IO
{
    public class Reader : IReader
    {
        private IMachinesManager manager;

        public Reader(IMachinesManager manager)
        {
            this.manager = manager;
        }

        public IList<ICommand> ReadCommands()
        {
            string input = string.Empty;
            List<ICommand> list = new List<ICommand>();

            while ((input = Console.ReadLine()) != "Quit")
            {
                string[] commands = input.Split();
                string commandType = commands[0];
                var arguments = commands.Skip(1).ToArray();

                ICommand comanda = new Command(commandType, arguments, this.manager);
                list.Add(comanda);
            }

            return list;
        }
    }
}
