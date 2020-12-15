using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var commands = this.reader.ReadCommands();

            for (int i = 0; i < commands.Count; i++)
            {
                this.writer.Write(commands[i].Execute().ToString());
            }
        }
    }
}
