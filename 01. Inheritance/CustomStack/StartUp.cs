using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings mu = new StackOfStrings();
            Console.WriteLine(mu.IsEmpty());

            string[] arr = new string[] { "pesj", "asd" };
            mu.AddRange(arr);

            foreach (var item in mu)
            {
                Console.WriteLine(item);
            }
        }
    }
}
