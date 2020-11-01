using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random randomizer;
        private List<string> list;

        public RandomList()
        {
            this.randomizer = new Random();
            this.list = new List<string>();
        }

        public void AddElement(string element)
        {
            this.Add(element);
        }

        public string RandomString()
        {   
            int randomIndex = randomizer.Next(0, this.Count);
            string randomElement = this[randomIndex];
            return randomElement;
        }

        public bool RemoveElement()
        {
            int randomIndex = randomizer.Next(0, this.Count);
            var result = this.Remove(this[randomIndex]);
            return result;
        }
    }
}
