using System;

namespace ReflectionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Age = 20
            };

            var isValid = Validator.Validate(person);

            Console.WriteLine(isValid);
        }
    }
}
