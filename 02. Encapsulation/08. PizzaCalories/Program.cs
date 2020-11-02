using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dough dough = null;
            Topping topping = null;
            Pizza pizza = null;
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var commands = command.Split();

                if (commands[0] == "Pizza")
                {
                    try
                    {
                        pizza = new Pizza(commands[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                    
                }

                if (commands[0] == "Dough")
                {
                    try
                    {
                        dough = new Dough(commands[1], commands[2], double.Parse(commands[3]));
                        pizza.Dough = dough;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }

                if (commands[0] == "Topping")
                {
                    try
                    {
                        topping = new Topping(commands[1], double.Parse(commands[2]));
                        try
                        {
                            pizza.AddTopping(topping);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
               
            }
            
            Console.WriteLine(pizza.ToString());
        }
    }
}
