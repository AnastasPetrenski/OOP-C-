using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>();
            RandomList list = new RandomList();
            
            list.Add("Pesho");
            list.Add("Pavel");
            list.Add("Pencho");
            list.Add("Gosh");
            list.RemoveElement();
            var result = list.RandomString();
            Console.WriteLine(result);
        }
    }
}
