using InfernoInfinity.Contracts;
using System;
using System.Linq;

namespace InfernoInfinity.Engines
{
    public class Engine : IEngine
    {
        public Engine(IRepository repository)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get; private set; }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                //•	Create;{levelOfRarity weaponType};{weapon name}
                //•	Add;{weapon name};{socket index};{levelOfClarity gemtype}
                //•	Remove;{weapon name};{socket index}
                //•	Print;{weapon name}
                string[] data = input.Split(';').ToArray();
                string commandName = data[0];
                InterpredCommand(data.Skip(1).ToArray(), commandName);
            }

        }

        private void InterpredCommand(string[] data, string commandName)
        {
            commandName = commandName + "Command";
            Type type = Type.GetType("InfernoInfinity.Commands." + commandName);
            var command = Activator.CreateInstance(type, new Object[] { data, this.Repository} ) as IExecutable;

            command.Execute();
        }
    }
}
