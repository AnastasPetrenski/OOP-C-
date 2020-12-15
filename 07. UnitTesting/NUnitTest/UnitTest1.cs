namespace NUnitTest
{
    using Container;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class UnitTests1
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            this.calculator = new Calculator();
        }

        [Test]
        public void SumShouldReturnCorrectResultWithTwoNumbers()
        {
            //Arrange
                    //Setup()
            //Act
            var result = this.calculator.Sum(1, 2);
            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void SumShouldReturnCorrectResultWithManyNumbers()
        {
            //Arrange
                    //Setup()
            //Act
            var result = calculator.Sum(1, 2, 3, 4, 5, 6);

            bool assert = 21 <= result;
            //Assert
            Assert.True(assert);
        }

        [Test]
        public void SumShouldReturnCorrectResultWithoutNumbers()
        {
            //Arrange
            ////Setup()  => Calculator calculator = new Calculator();
            //Act
            var numbers = new int[] { };

            var result = calculator.Sum(numbers);
            //Assert
            Assert.That(result, Is.EqualTo(0));

            Assert.IsEmpty(numbers, "Array is emty");
        }

        [Test]
        public void ProductShouldThrowExceptionWithNullNumbers()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = calculator.Multiply(null);
            });
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            BankAccount bankAccount = new BankAccount(50);

            bankAccount.Deposit(50);

            Assert.That(bankAccount.Ammount, Is.EqualTo(100));
        }
    }
}