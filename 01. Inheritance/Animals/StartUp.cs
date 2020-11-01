using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                var arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string gender = arguments[2];

                try
                {
                    switch (input)
                    {
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));    break;
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));    break;
                        case "Frog":
                            animals.Add(new Frog(name, age, gender));   break;
                        case "Kitten":
                            animals.Add(new Kitten(name, age));         break;
                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));         break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
