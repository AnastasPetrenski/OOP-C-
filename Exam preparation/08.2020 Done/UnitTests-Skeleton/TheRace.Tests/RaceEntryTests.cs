using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateConstructor()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.IsNotNull(raceEntry);
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfNull()
        {
            UnitDriver driver = null; 
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldThrowExceptionIfDriversNameDuplicate()
        {
            UnitCar unitCar = new UnitCar("BMW", 200, 5000);
            UnitDriver driver = new UnitDriver("BMW", unitCar);
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverShouldAddEntityToCollection()
        {
            UnitCar unitCar = new UnitCar("BMW", 200, 5000);
            UnitDriver driver = new UnitDriver("BMW", unitCar);
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, raceEntry.Counter);
        }

        [Test]
        public void AddDriverShouldReturnMessageIfSuccessfullyAdded()
        {
            UnitCar unitCar = new UnitCar("BMW", 200, 5000);
            UnitDriver driver = new UnitDriver("BMW", unitCar);
            RaceEntry raceEntry = new RaceEntry();

            var result = raceEntry.AddDriver(driver);

            string DriverAdded = "Driver {0} added in race.";
            Assert.That(result, Is.EqualTo(string.Format(DriverAdded, driver.Name)));
        }

        [Test]
        public void AverageHoursePowerShouldThrowExceptionIfCountLessThanTwo()
        {
            UnitCar unitCar = new UnitCar("BMW", 200, 5000);
            UnitDriver driver = new UnitDriver("BMW", unitCar);
            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void AverageHoursePowerSholdReturnDoubleResult()
        {
            UnitCar unitCar = new UnitCar("BMW", 200, 5000);
            UnitDriver driver = new UnitDriver("BMW", unitCar);
            UnitCar unitCarTwo = new UnitCar("Audi", 400, 3000);
            UnitDriver driverTwo = new UnitDriver("Audi", unitCarTwo);

            RaceEntry raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driverTwo);

            double expected = (unitCar.HorsePower + unitCarTwo.HorsePower) / 2;
            double actual = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expected, actual);
        }
    }
}