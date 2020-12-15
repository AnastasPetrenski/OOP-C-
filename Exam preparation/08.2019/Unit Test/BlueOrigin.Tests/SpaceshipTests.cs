namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut;
        private Spaceship spaceship;

       [SetUp]
       public void SetUp()
        {
            string name = "Nasko";
            double oxygenInPercentage = 100;
            astronaut = new Astronaut(name, oxygenInPercentage);

            string sname = "Galaxy";
            int capacity = 2;
            spaceship = new Spaceship(sname, capacity);
        }

       [Test]
       public void CreateAstronaut()
        {
            Assert.AreEqual("Nasko", astronaut.Name);
            Assert.AreEqual(100, astronaut.OxygenInPercentage);
            Assert.IsNotNull(astronaut);
        }

        [Test]
        public void CreateSpaceShip()
        {
            Assert.AreEqual("Galaxy", spaceship.Name);
            Assert.AreEqual(2, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
            Assert.IsNotNull(spaceship);
        }

        [Test]
        public void NameNull()
        {
            Assert.Throws<ArgumentNullException>(() => spaceship = new Spaceship(null, 5));
        }

        [Test]
        public void NameEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => spaceship = new Spaceship("", 5));
        }

        [Test]
        public void NegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => spaceship = new Spaceship("Nas", -1));
        }

        [Test]
        public void OverCapacity()
        {
            var astro1 = new Astronaut("Pesho", 20);
            var astro2 = new Astronaut("Gosho", 30);

            spaceship.Add(astro1);
            spaceship.Add(astro2);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void AstroExist()
        {
            spaceship.Add(astronaut);
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void AddAstro()
        {
            spaceship.Add(astronaut);
            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void RemoveAstro()
        {
            spaceship.Add(astronaut);
            bool expected = true;

            Assert.AreEqual(expected, spaceship.Remove(astronaut.Name));
        }
    }
}