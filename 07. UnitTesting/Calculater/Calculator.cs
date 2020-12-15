namespace Container
{
    using System;
    using System.Linq;

    public class Calculator
    {
        public int Sum(params int[] numbers)
            => numbers.Sum();

        public int Multiply(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers)); 
            }

            int multiplier = 1;

            foreach (var item in numbers)
            {
                multiplier *= item;
            }

            return multiplier;
        }
    }
}
