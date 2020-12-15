using Container;
using NUnit.Framework;

namespace NUnitTest
{
    public class DummyTest
    {
        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetUp()
        {
            //Arrange for all [Test]
            this.aliveDummy = new Dummy(100, 100);
            this.deadDummy = new Dummy(100, 0);
        }

        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            //Act
            aliveDummy.TakeAttack(51);
            //Assert
            Assert.That(aliveDummy.Health, Is.EqualTo(49));
        }

        [Test]
        public void DummyShouldThrowExeptionIfAttackedWithoutHealth()
        {
            //Assert
            Assert.That(() => deadDummy.TakeAttack(10), //Act
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), "Dead dummy cannot be attacked.");
        }

        [Test]
        public void DummyShouldGiveExperienceIfDead()
        {
            //Act
            var experience = deadDummy.GiveExperience();
            //Assert
            Assert.That(experience, Is.EqualTo(30));
        }

        [Test]
        public void DummyShouldThrowExceptionAndNotGiveExperienceIfIsAlive()
        {
            //Act
            var experience = 0;
            //Assert
            Assert.That(() => aliveDummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is not dead."));
            Assert.AreEqual(0, experience);
        }
    }
}
