using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var inputArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                string country = inputArgs[1];
                string age = inputArgs[2];

                Citizen citizen = new Citizen(name, country, age);
                IPerson personGetName = citizen;
                IResident residentGetName = citizen;
                Console.WriteLine(personGetName.GetName());
                Console.WriteLine(residentGetName.GetName());
            }
        }
    }
}
