using System;
using System.Collections.Generic;
using System.Text;

namespace HighQualityMistakes
{
    public class Person : Human
    {
        private const int height = 150;

        public Person(string name) : base(name)
        {
        }

        public Person(int age) : base(age)
        {
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public string Print(int a, double b, string[] numbers)
        {
            int max = 0;
            var result = a + b;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(result < double.Parse(numbers[i]))
                {
                    max = int.Parse(numbers[i]);
                }
            }

            return max.ToString();
        }
    }
}
