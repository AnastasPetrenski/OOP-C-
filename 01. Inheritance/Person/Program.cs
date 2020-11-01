using System;

namespace Person
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("Nasko", 1);
            //Console.WriteLine(person.ToString());
            //try
            //{
            //    person = new Person("Test", -1);
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            
            //Console.WriteLine(person.ToString());

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);


        }
    }
}
