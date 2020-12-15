namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark park;

        [SetUp]
        public void Setup()
        {
            string make = "Nasko";
            string number = "XXX";
            this.car = new Car(make, number);

            this.park = new SoftPark();
        }

        [Test]
        public void CreateCar()
        {
            string make = "Nasko";
            string number = "XXX";

            Car car = new Car(make, number);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(number, car.RegistrationNumber);
            
        }

        [Test]
        public void CreatePark()
        {
            SoftPark park = new SoftPark();

            Assert.IsNotNull(park);
            Assert.That(park.Parking.ContainsKey("A1"));
            Assert.That(park.Parking["A1"] == null);
            Assert.AreEqual(12, this.park.Parking.Count);
        }

        [Test]
        public void GetDictionaryType()
        {
            SoftPark park = new SoftPark();
            park.ParkCar("A1", this.car);
            var type = park.Parking.GetType().Name;
            var valueType = park.Parking["A1"].GetType().Name;
          

            Assert.AreEqual("ImmutableDictionary`2", type);
            Assert.AreEqual(this.car.GetType().Name, valueType);
        }

        [Test]
        public void InvalidCarSport()
        {
            Assert.Throws<ArgumentException>(() => this.park.ParkCar("A", this.car));
        }

        [Test]
        public void FullCarSport()
        {
            this.park.ParkCar("A1", this.car);
            Car car = new Car("Test", "VVV");

            Assert.Throws<ArgumentException>(() => this.park.ParkCar("A1", car));
        }

        [Test]
        public void CarExistCarSport()
        {
            this.park.ParkCar("A1", this.car);

            Assert.Throws<InvalidOperationException>(() => this.park.ParkCar("A2", this.car));
        }

        [Test]
        public void SuccessfullyParkedCar()
        {
            var expectedMsg = $"Car:XXX parked successfully!";
            Assert.AreEqual(expectedMsg, this.park.ParkCar("A1", this.car));
        }

        [Test]
        public void RemoveInvalidSpot()
        {
            this.park.ParkCar("A1", this.car);
            Assert.Throws<ArgumentException>(() => this.park.RemoveCar("A", car));
        }

        [Test]
        public void RemoveInvalidSpotCar()
        {
            Car car = new Car("Test", "VVV");
            this.park.ParkCar("A1", this.car);
            this.park.ParkCar("A2", car);

            Assert.Throws<ArgumentException>(() => this.park.RemoveCar("A2", this.car));
        }

        [Test]
        public void RemoveCarSuccessfully()
        {
            this.park.ParkCar("A1", this.car);
            string expectedMsg = $"Remove car:XXX successfully!";

            Assert.AreEqual(expectedMsg, this.park.RemoveCar("A1", this.car));
        }

    }
}