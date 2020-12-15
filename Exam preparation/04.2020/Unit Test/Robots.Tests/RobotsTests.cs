namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public  void Seter()
        {
            string name = "Robo";
            int battery = 100;
            this.robot = new Robot(name, battery);

            int capacity = 2;
            this.manager = new RobotManager(capacity);
        }
        

        [Test]
        public void CreateRobotManagerThrougConstructor()
        {
            string name = "Robo";
            int battery = 100;
            Robot robot = new Robot(name, battery);

            int capacity = 10;
            RobotManager manager = new RobotManager(capacity);

            Assert.AreEqual(name, robot.Name);
            Assert.AreEqual(battery, robot.MaximumBattery);
            Assert.AreEqual(battery, robot.Battery);
            Assert.IsNotNull(manager);
            Assert.AreEqual(capacity, manager.Capacity);
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void CapacityShoultThrowExceptionIfLessThanZero()
        {
            int capacity = -1;

            RobotManager manager;

            Assert.Throws<ArgumentException>(() => manager = new RobotManager(capacity));
        }

        [Test]
        public void AddShoultThrowExceptionIfEntityNameExist()
        {
            string name = "Robo";
            int battery = 100;

            Robot robot = new Robot(name, battery);

            this.manager.Add(this.robot);
            Assert.Throws<InvalidOperationException>(() => this.manager.Add(robot));
        }

        [Test]
        public void AddShoultThrowExceptionIfOverCapacity()
        {
            string name = "Robot";
            int battery = 100;

            Robot robot = new Robot(name, battery);

            string exname = "Robottat";
            int exbattery = 100;

            Robot execptionRobot = new Robot(exname, exbattery);

            this.manager.Add(this.robot);
            this.manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => this.manager.Add(execptionRobot));
        }

        [Test]
        public void AddShoultAddedEntitySuccessfully()
        {
            this.manager.Add(this.robot);

            int count = 1;

            Assert.That(count, Is.EqualTo(manager.Count));
        }

        [Test]
        public void RemoveShoultThrowExceptionIfNull()
        {
            this.manager.Add(this.robot);


            Assert.Throws<InvalidOperationException>(() => manager.Remove("InvalidName"));
        }

        [Test]
        public void RemoveShoultDecreaseCount()
        {
            this.manager.Add(this.robot);
            this.manager.Remove("Robo");

            int expextedCount = 0;

            Assert.AreEqual(expextedCount, manager.Count);
        }

        [Test]
        public void WorkShoultThrowExceptionIfNull()
        {
            this.manager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => manager.Work("InvalidName", "job", 10));
        }

        [Test]
        public void WorkShoultThrowExceptionIfNotEnoughBattery()
        {
            this.manager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Robo", "job", 1000));
        }

        [Test]
        public void WorkShoultDecreaseBatteryIfDoneSuccessfully()
        {
            this.manager.Add(this.robot);
            manager.Work("Robo", "job", 10);

            int expectedBattery = 90;

            Assert.AreEqual(expectedBattery, robot.Battery);
        }

        [Test]
        public void ChargeShoultThrowExceptionIfNull()
        {
            this.manager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => manager.Charge("InvalidName"));
        }

        [Test]
        public void ChargeShoultResetBatteryToInitialValue()
        {
            this.manager.Add(this.robot);
            manager.Work("Robo", "job", 10);
            manager.Charge("Robo");

            int expectedBattery = 100;

            Assert.AreEqual(expectedBattery, robot.Battery);
        }

    }
}
