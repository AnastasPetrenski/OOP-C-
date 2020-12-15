using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string command = string.Empty;

            do
            {
                command = Console.ReadLine();

                string result = this.commandInterpreter.Read(command);

                Console.WriteLine(result);

            } while (command != "Exit");
        }
    }
}
