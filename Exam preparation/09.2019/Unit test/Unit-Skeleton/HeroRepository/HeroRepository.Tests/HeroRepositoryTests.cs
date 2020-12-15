using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("MyHero", 50);

        heroRepository = new HeroRepository();
    }

    [Test]
    public void CreateHero()
    {
        Assert.NotNull(hero);
        Assert.AreEqual("MyHero", hero.Name);
        Assert.AreEqual(50, hero.Level);
    }

    [Test]
    public void CreateHeroRepository()
    {
        Assert.NotNull(heroRepository);
        Assert.AreEqual(0, heroRepository.Heroes.Count);
        Assert.AreEqual("ReadOnlyCollection`1", heroRepository.Heroes.GetType().Name);
    }

    [Test]
    public void AddNullHero()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void AddExistedHero()
    {
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void AddHero()
    {
        var expectedResult = $"Successfully added hero MyHero with level 50";
        Assert.That(expectedResult,Is.EqualTo(heroRepository.Create(hero)));
    }

    [Test]
    [TestCase("")]
    [TestCase("     ")]
    [TestCase(null)]
    public void RemoveEmptyName(string name)
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name));
    }

    [Test]
    public void RemoveHero()
    {
        heroRepository.Create(hero);

        Assert.AreEqual(true, heroRepository.Remove(hero.Name));
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void RemoveNotExistedHero()
    {
        heroRepository.Create(hero);

        Assert.AreEqual(false, heroRepository.Remove("Hero"));
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevel()
    {
        Hero lowLevelHero = new Hero("LowLevel", 20);
        heroRepository.Create(hero);

        var actualHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreSame(hero, actualHero);
        Assert.AreEqual(hero.Level, actualHero.Level);
        Assert.AreNotEqual(lowLevelHero.Level, actualHero.Level);
    }

    [Test]
    public void GetHero()
    {
        heroRepository.Create(hero);

        var actualHero = heroRepository.GetHero("MyHero");

        Assert.AreSame(hero, actualHero);
        Assert.AreEqual(hero.Name, actualHero.Name);
    }

    [Test]
    public void GetHeroReturnNull()
    {
        heroRepository.Create(hero);

        var actualHero = heroRepository.GetHero("Hero");
        Hero expectedNullHero = null;

        Assert.AreSame(expectedNullHero, null);
    }


}