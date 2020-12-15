using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            bankAccount = new BankAccount("OBB", 2000);
        }

        [Test]
        public void CreateEntity()
        {
            Assert.AreEqual("OBB", bankAccount.Name);
            Assert.AreEqual(2000, bankAccount.Balance);
            Assert.NotNull(bankAccount);
        }

        [Test]
        [TestCase("Ob")]
        [TestCase("oooooooooooooooooooooooooooooooooooooooooooooooooooooooooo")]
        public void InvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() => bankAccount = new BankAccount(name, 2000));
        }

        [Test]
        [TestCase(-1)]
        public void InvalidBalance(decimal balance)
        {
            Assert.Throws<ArgumentException>(() => bankAccount = new BankAccount("OBB", balance));
        }

        [Test]
        [TestCase(-1)]
        public void InvalidAmount(decimal amount)
        {
            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amount));
        }

        [Test]
        [TestCase(1)]
        public void DepositAmount(decimal amount)
        {
            bankAccount.Deposit(amount);
            var expected = 2001;

            Assert.AreEqual(expected, bankAccount.Balance);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(2002)]
        public void InvalidWithdraw(decimal amount)
        {
            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));
        }

        [Test]
        [TestCase(1)]
        public void Withdraw(decimal amount)
        {
            bankAccount.Withdraw(amount);
            var expected = 1999;

            Assert.AreEqual(expected, bankAccount.Balance);
        }
    }
}