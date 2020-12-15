using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle motorcycle;
        private UnitRider rider;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            string model = "KTM";
            int horsePower = 100;
            double cubicCentimeters = 450;
            motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);

            string name = "Nasko";
            rider = new UnitRider(name, motorcycle);

            raceEntry = new RaceEntry();
        }

        [Test]
        public void CreateMotorcycle()
        {
            Assert.NotNull(motorcycle);
            Assert.AreEqual("KTM", motorcycle.Model);
            Assert.AreEqual(100, motorcycle.HorsePower);
            Assert.AreEqual(450, motorcycle.CubicCentimeters);
        }

        [Test]
        public void CreateRider()
        {
            Assert.IsNotNull(rider);
            Assert.AreEqual("Nasko", rider.Name);
            Assert.AreSame(motorcycle, rider.Motorcycle);
        }

        [Test]
        public void CreateRiderNullExc()
        {
            Assert.Throws<ArgumentNullException>(() => rider = new UnitRider(null, motorcycle));
        }

        [Test]
        public void CreateRace()
        {
            Assert.IsNotNull(raceEntry);
            Assert.AreEqual(raceEntry.Counter, 0);
        }

        [Test]
        public void AddRiderNullExc()
        {
            UnitRider rider = null;
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void AddRiderInvalidExc()
        {
            var motorcycle1 = new UnitMotorcycle("CTX", 100, 300);
            UnitRider rider = new UnitRider("Nasko", motorcycle1);
            raceEntry.AddRider(this.rider);
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void AddRiderResult()
        {
            var result = "Rider Nasko added in race.";
            Assert.That(result, Is.EqualTo(raceEntry.AddRider(rider)));
        }

        [Test]
        public void CalculateAverageHorsePowerExc()
        {
            raceEntry.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerResult()
        {
            var motorcycle1 = new UnitMotorcycle("CTX", 200, 300);
            UnitRider rider1 = new UnitRider("Nasko1", motorcycle1);
            raceEntry.AddRider(rider);
            raceEntry.AddRider(rider1);
            var expected = 150;

            Assert.That(expected, Is.EqualTo(raceEntry.CalculateAverageHorsePower()));
        }
    }
}