using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            AddCollection<string> array1 = new AddCollection<string>();
            AddRemoveCollection<string> array2 = new AddRemoveCollection<string>();
            MyList<string> array3 = new MyList<string>();

            List<string> outputFirstLine = new List<string>();
            List<string> outputSecondLine = new List<string>();
            List<string> outputThirdLine = new List<string>();
            List<string> outputFourthLine = new List<string>();
            List<string> outputFifthLine = new List<string>();

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var x = array1.Add(input[i]);
                outputFirstLine.Add(x.ToString());
                var y = array2.Add(input[i]);
                outputSecondLine.Add(y.ToString());
                var z = array3.Add(input[i]);
                outputThirdLine.Add(z.ToString());
            }

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                outputFourthLine.Add(array2.Remove());
                outputFifthLine.Add(array3.Remove());
            }

            Console.WriteLine(string.Join(" ", outputFirstLine));
            Console.WriteLine(string.Join(" ", outputSecondLine));
            Console.WriteLine(string.Join(" ", outputThirdLine));
            Console.WriteLine(string.Join(" ", outputFourthLine));
            Console.WriteLine(string.Join(" ", outputFifthLine));
        }
    }
}
