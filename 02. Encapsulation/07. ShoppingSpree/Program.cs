using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string[] personsArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < personsArgs.Length; i++)
            {
                string[] input = personsArgs[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Person person = new Person(input[0], decimal.Parse(input[1]));
                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            List<Product> products = new List<Product>();
            string[] productsArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsArgs.Length; i++)
            {
                string[] input = productsArgs[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Product product = new Product(input[0], decimal.Parse(input[1]));
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = commands[0];
                string productName = commands[1];
                var productCurrent = products.FirstOrDefault(p => p.Name == productName);
                var personCurrent = persons.FirstOrDefault(p => p.Name == personName);
                if (personCurrent.AddProduct(productCurrent))
                {
                    Console.WriteLine($"{personCurrent.Name} bought {productCurrent.Name}");
                }
                else 
                {
                    Console.WriteLine($"{personCurrent.Name} can't afford {productCurrent.Name}");
                }
            }


            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
