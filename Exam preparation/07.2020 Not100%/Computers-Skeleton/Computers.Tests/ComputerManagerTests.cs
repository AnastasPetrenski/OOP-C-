using NUnit.Framework;
using System;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestConstructorSetCollection()
        {
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();
            string expectedManufacturer = "HP";
            string expectedModel = "Probook";
            decimal expectedPrice = 1200;
            var expectedCollection = manager.Computers;
            Type type = expectedCollection.GetType();

            Assert.AreEqual(expectedPrice, computer.Price);
            Assert.AreEqual(expectedModel, computer.Model);
            Assert.AreEqual(expectedManufacturer, computer.Manufacturer);
            Assert.That(manager, Is.Not.Null);
            Assert.AreEqual("ReadOnlyCollection`1", type.Name);
            
        }

        [Test]
        public void ValidateNullValueShouldThrowExceptionIfNull()
        {
            Computer computer = null;
            ComputerManager manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(computer));
        }

        [Test]
        public void AddComputerShouldIncreaseCount()
        {
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, manager.Count);
            CollectionAssert.AllItemsAreInstancesOfType(manager.Computers, typeof(Computer));
        }

        [Test]
        public void AddComputerShouldThrowExcepetionIfEntityExist()
        {
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));
        }

        [Test]
        public void GetComputerShouldReturnCorrectEntity()
        {
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);

            var actualComputer = manager.GetComputer("HP", "Probook");
            var expectedPrice = 1200;

            Assert.That(actualComputer.Price, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void GetComputerShouldThrowExceptionEntityNotExist()
        {
            Computer notAddedComp = new Computer("Test", "NotAdded", 1000); 
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("Test", "NotAdded"));
        }

        [Test]
        public void RemoveComputerShouldReturnEntityOfTheSameType()
        {
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            var removed = manager.RemoveComputer("HP", "Probook");

            int expectedCount = 0;
            decimal expectedPrice = 1200;

            Assert.AreEqual(expectedCount, manager.Count);
            Assert.AreEqual(expectedPrice, removed.Price);
        }
        
        [Test]
        public void GetComputersByManufacturerShouldReturnCollectionOfComputers()
        {
            Computer AddedComp = new Computer("HP", "Notbook", 1000);
            Computer computer = new Computer("HP", "Probook", 1200);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            manager.AddComputer(AddedComp);

            string expectedManufacturer = "HP";

            var list = manager.GetComputersByManufacturer(expectedManufacturer);

            Assert.That(list, Is.All.TypeOf(typeof(Computer)));
            Assert.AreEqual(list.Count, manager.Count);
        }
    }
}