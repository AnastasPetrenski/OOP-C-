using Container;
using System;
using Xunit;

namespace XUnitTest
{
    public class CalculatorTest
    {
        [Fact]
        public void SumShouldReturnCorrectResultWithTwoNumbers()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Sum(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void SumShouldReturnCorrectResultWithManyNumbers()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Sum(1, 2, 3, 4, 5, 6);

            bool assert = 21 <= result;

            Assert.True(assert);
        }

        [Fact]
        public void SumShouldReturnCorrectResultWithoutNumbers()
        {
            Calculator calculator = new Calculator();

            var numbers = new int[] { };

            var result = calculator.Sum(numbers);

            Assert.Equal(0, result);

            Assert.Empty(numbers);
        }

        [Fact]
        public void ProductShouldThrowExceptionWithNullNumbers()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                var calculator = new Calculator();

                var result = calculator.Multiply(null);
            });

           
        }
    }
}
