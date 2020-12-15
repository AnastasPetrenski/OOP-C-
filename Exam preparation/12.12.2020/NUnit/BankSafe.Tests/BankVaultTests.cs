using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    

    public class BankVaultTests
    {
        private Item item;
        private BankVault bank;

        [SetUp]
        public void Setup()
        {
            item = new Item("Nasko", "1");
            bank = new BankVault();
        }

        [Test]
        public void CreateEntity()
        {
            Assert.AreEqual("Nasko", item.Owner);
            Assert.AreEqual("1", item.ItemId);
            Assert.NotNull(item);
        }

        [Test]
        public void CreateBankRepository()
        {
            Assert.NotNull(bank);
            Assert.AreEqual(12, bank.VaultCells.Count);
            Assert.That(bank.VaultCells.ContainsKey("A1"));
            Assert.AreEqual(null, bank.VaultCells["A1"]);
        }

        [Test]
        public void AddSameKey()
        {
            bank.AddItem("A1", item);
            Item test = new Item("Pesho", "2");

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", test));
        }

        [Test]
        public void AddValueNotNull()
        {
            Item test = new Item("Pesho", "2");

            Assert.Throws<ArgumentException>(() => bank.AddItem("Q1", test));
        }

        [Test]
        public void AddExisted()
        {
            bank.AddItem("A1", item);
            Item test = new Item("Pesho", "1");

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", test));
        }

        [Test]
        public void AddExisted2()
        {
            bank.AddItem("A1", item);
            Item test = new Item("Pesho", "1");

            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", test));
        }

        [Test]
        public void AddValue()
        {
            Item test = new Item("Pesho", "2");
            bank.AddItem("A1", test);
            bank.AddItem("A2", item);

            Assert.AreEqual(12, bank.VaultCells.Count);
        }

        [Test]
        public void AddValueResult()
        {
            

            string exc = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(exc, bank.AddItem("A2", item));
        }

        [Test]
        public void RemoveInvalidKey()
        {
            Item test = new Item("Pesho", "2");
            bank.AddItem("A1", test);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("Q1", test));
        }

        [Test]
        public void RemoveInvalidEntity()
        {
            Item test = new Item("Pesho", "2");
            bank.AddItem("A1", test);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", item));
        }

        [Test]
        public void RemoveItem()
        {
            Item test = new Item("Pesho", "2");
            bank.AddItem("A1", test);

            string exc = $"Remove item:{test.ItemId} successfully!";

            Assert.AreEqual(exc, bank.RemoveItem("A1", test));
        }

    }
}