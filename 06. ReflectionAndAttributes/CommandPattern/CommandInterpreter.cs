using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (inputArgs[0] + "Command");
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand inctanceType = Activator.CreateInstance(commandType) as ICommand;

            if (inctanceType == null)
            {

            }

            string result = inctanceType.Execute(commandArgs);

            return result;
        }
    }
}
