using Container;
using NUnit.Framework;

namespace NUnitTest
{
    //[TestFixture]
    public class AxeTest
    {
        
        //fakeTarget
        //    .Setup(p => p.TakeAttack(It.IsAny<int>))
        //    .Callback(() => hero.Weapon.DuarabilityPoints -= 1);
        //fakeTarget
        //    .Setup(p => p.Health)
        //    .Returns(0);

        private Dummy dummy;

        [SetUp]
        public void SetDummy() => this.dummy = new Dummy(100, 100);

        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(100, 1);
            //Act
            axe.Attack(this.dummy);
            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(0));
        }

        [Test]
        public void AxeShouldThrowExeptionIfAnAttackIsMadeWithBrokenAxe()
        {
            //Arrange
            Axe axe = new Axe(100, 0);
           
            //Assert
            Assert.That(() => axe.Attack(this.dummy), 
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
