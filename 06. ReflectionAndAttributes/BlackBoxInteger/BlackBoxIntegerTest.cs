using System;
using System.Linq;
using System.Reflection;

namespace BlackBoxInteger
{
    public class BlackBoxIntegerTest
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            BlackBoxInteger obj = Activator.CreateInstance(type, true) as BlackBoxInteger;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var commands = input.Split("_", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var method = type.GetMethod(commands[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                var paramethers = method.GetParameters();
                var argument = int.Parse(commands[1]);
                method.Invoke(obj, new object[] { argument });

                int currentValue = (int)type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);

                Console.WriteLine(currentValue);
            }
        }
    }
}
