namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {


        [SetUp]

        [Test]
        public void ValidateConstructorFields()
        {
            string makeExpected = "Nokia";
            string modelExpected = "3330";

            Phone phone = new Phone(makeExpected, modelExpected);

            Assert.AreEqual(makeExpected, phone.Make);
            Assert.AreEqual(modelExpected, phone.Model);
            Assert.AreEqual(0, phone.Count);
            Assert.IsNotNull(phone);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyMakeShoultThrowExceptionIfNullOrEmpty(string makeExpected)
        {
            string modelExpected = "3330";
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone(makeExpected, modelExpected), $"Invalid {nameof(phone.Make)}!");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyModelShoultThrowExceptionIfNullOrEmpty(string modelExpected)
        {
            string makeExpected = "Nokia";
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone(makeExpected, modelExpected), $"Invalid {nameof(phone.Model)}!");
        }

        [Test]
        public void AddContactShouldIncreasePhoneCount()
        {
            string makeExpected = "Nokia";
            string modelExpected = "3330";

            Phone phone = new Phone(makeExpected, modelExpected);

            string name = "Nasko";
            string number = "089560";

            phone.AddContact(name, number);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void AddContactShouldThrowExceptionIfNameExist()
        {
            string makeExpected = "Nokia";
            string modelExpected = "3330";

            Phone phone = new Phone(makeExpected, modelExpected);

            string name = "Nasko";
            string number = "089560";
            phone.AddContact(name, number);

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Nasko", "095663"));
        }

        [Test]
        public void CallShouldReturnCorrectNumberMessage()
        {
            string makeExpected = "Nokia";
            string modelExpected = "3330";

            Phone phone = new Phone(makeExpected, modelExpected);

            string name = "Nasko";
            string number = "089560";
            phone.AddContact(name, number);

            string expectedMessage = $"Calling {name} - {number}...";
            string actualMessage = phone.Call(name);

            Assert.AreEqual(expectedMessage, actualMessage);
            Assert.That(expectedMessage, Is.EqualTo(phone.Call(name)));
        }

        [Test]
        public void CallShouldThrowExceptionIfNameNotExist()
        {
            string makeExpected = "Nokia";
            string modelExpected = "3330";

            Phone phone = new Phone(makeExpected, modelExpected);

            string name = "Nasko";
            string number = "089560";
            phone.AddContact(name, number);

            string notExistingName = "Vasko";

            Assert.Throws<InvalidOperationException>(() => phone.Call(notExistingName));
        }
    }
}