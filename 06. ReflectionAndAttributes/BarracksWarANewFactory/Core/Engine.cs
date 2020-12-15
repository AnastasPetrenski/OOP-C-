using System;
using System.Linq;
using System.Reflection;
using BarracksWarANewFactory.Contracts;

namespace BarracksWarANewFactory.Core
{
    public class Engine : IEngine
    {
        private IRepository report;
        private IUnitFactory factory;

        public Engine(IRepository report, IUnitFactory factory)
        {
            this.report = report;
            this.factory = factory;
        }

        public void Run()
        {

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    return;
                    Console.WriteLine(e.Message);

                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            commandName = commandName[0].ToString().ToUpper() + commandName.Substring(1) + "Command";
            Type typeOfCommand = Type.GetType("BarracksWarANewFactory.Core.Commands." + commandName);
            IExecutable command = Activator.CreateInstance(typeOfCommand, new Object[] { data, this.report, this.factory}) as IExecutable;

            var fieldsToInject = typeOfCommand.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes(false).Any(ca => ca.GetType() == typeof(CustomAttributes.InjectAttribute)));

            foreach (var commandField in fieldsToInject)
            {
                var engineClassFieldValue = typeof(Engine)
                    .GetField(commandField.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this);

                commandField.SetValue(command, engineClassFieldValue);
            }

            var result = command.Execute();
            return result;
        }
    }
}
