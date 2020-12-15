using System;

namespace LiskovExampleConstructorFlow
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Animal animal = new Animal("asaa");
            var catName = animal.Name;
            Console.WriteLine(catName);

            Cat caty = new Cat();
            var catyName = caty.Name;
            Console.WriteLine(catyName);
        }
    }
}
