namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatePart()
        {
            string name = "Test";
            decimal price = 20;

            Part part = new Part(name, price);

            Assert.AreEqual(name, part.Name);
            Assert.AreEqual(price, part.Price);
        }

        [Test]
        public void CreateComputer()
        {
            string name = "Test";

            Computer computer = new Computer(name);

            Assert.AreEqual(name, computer.Name);
            Assert.IsNotNull(computer);
            Assert.AreEqual(0, computer.Parts.Count);
        }

        [Test]
        public void EmptyName()
        {
            string name = string.Empty;

            Computer computer;

            Assert.Throws<ArgumentNullException>(() => computer = new Computer(name));
        }

        [Test]
        public void NullName()
        {
            string name = null;

            Computer computer;

            Assert.Throws<ArgumentNullException>(() => computer = new Computer(name));
        }

        [Test]
        public void WhiteSpace()
        {
            string name = "         ";

            Computer computer;

            Assert.Throws<ArgumentNullException>(() => computer = new Computer(name));
        }

        [Test]
        public void CheckCollectionType()
        {
            string partname = "Test";
            decimal price = 20;

            Part part = new Part(partname, price);


            string compname = "Test";

            Computer computer = new Computer(compname);

            var type = computer.Parts.GetType().Name;

            Assert.AreEqual("ReadOnlyCollection`1", type);
        }

        [Test]
        public void TotalPrice()
        {
            string partname = "Test";
            decimal price = 20;

            Part part = new Part(partname, price);


            string compname = "Test";

            Computer computer = new Computer(compname);
            computer.AddPart(part);
            computer.AddPart(part);

            var expectedTotal = 40;

            Assert.AreEqual(expectedTotal, computer.TotalPrice);
        }

        [Test]
        public void AddPart()
        {
            string partname = "Test";
            decimal price = 20;

            Part part = new Part(partname, price);


            string compname = "Test";

            Computer computer = new Computer(compname);
            computer.AddPart(part);

            var expectedCount = 1;

            Assert.AreEqual(expectedCount, computer.Parts.Count);
        }

        [Test]
        public void AddPartNull()
        {
            Part part = null;


            string compname = "Test";

            Computer computer = new Computer(compname);

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(part));

        }

        [Test]
        public void RemovePart()
        {
            string partname = "Test";
            decimal price = 20;

            Part part = new Part(partname, price);


            string compname = "Test";

            Computer computer = new Computer(compname);
            computer.AddPart(part);
            computer.RemovePart(part);

            var expectedCount = 0;

            Assert.AreEqual(expectedCount, computer.Parts.Count);
        }

        [Test]
        public void Getpart()
        {
            string partname = "Test";
            decimal price = 20;

            Part part = new Part(partname, price);


            string compname = "Test";

            Computer computer = new Computer(compname);
            computer.AddPart(part);
            var actualPart = computer.GetPart("Test");

            var expectedPrice = 20;

            Assert.AreEqual(expectedPrice, actualPart.Price);
        }
    }
}