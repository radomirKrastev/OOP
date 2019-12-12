using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository repository;
    private Hero hero;

    [SetUp]
    public void Setup()
    {
        this.hero = new Hero("Pencho", 500);
        this.repository = new HeroRepository();
    }

    [Test]
    public void ConstructorWorksCorrectly()
    {
        Assert.IsNotNull(this.repository.Heroes);
    }

    [Test]
    public void CreateHeroAddsHeroToCollection()
    {
        this.repository.Create(this.hero);

        Assert.AreEqual(1, this.repository.Heroes.Count);
    }
       
    [Test]
    public void CreateHeroReturnsCorrectString()
    {
        Assert.AreEqual($"Successfully added hero {this.hero.Name} with level {this.hero.Level}", this.repository.Create(this.hero));
    }

    [Test]
    public void CreateNullHeroThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => this.repository.Create(null));
    }

    [Test]
    public void CreateTheSameHeroThrowsInvalidOperationException()
    {
        this.repository.Create(this.hero);

        Assert.Throws<InvalidOperationException>(() => this.repository.Create(this.hero));
    }

    [TestCase("Pencho")]
    [TestCase("Slaveykov")]
    public void RemoveReturnsTrueOrFalseCorrectlyaAndDeletesHero(string name)
    {
        this.repository.Create(this.hero);

        if (name == "Pencho")
        {
            Assert.AreEqual(true, this.repository.Remove(name));
            Assert.AreEqual(0, this.repository.Heroes.Count);
        }
        else
        {
            Assert.AreEqual(false, this.repository.Remove(name));
            Assert.AreEqual(1, this.repository.Heroes.Count);
        }
    }

    [TestCase(" ")]
    [TestCase(null)]
    public void RemoveNullOrWhitespaceNameHeroThrowsArgumentNullException(string name)
    {
        this.repository.Create(this.hero);

        Assert.Throws<ArgumentNullException>(() => this.repository.Remove(name));
    }

    [Test]
    public void GetHeroWithHighestLevelWorksCorrectly()
    {
        var heroTwo = new Hero("Stancho", 899);
        var heroThree = new Hero("Pancho", 340);
        this.repository.Create(this.hero);
        this.repository.Create(heroTwo);
        this.repository.Create(heroThree);

        Assert.AreEqual(heroTwo, this.repository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroReturnsRightHero()
    {
        var heroTwo = new Hero("Stancho", 899);
        var heroThree = new Hero("Pancho", 340);
        this.repository.Create(this.hero);
        this.repository.Create(heroTwo);
        this.repository.Create(heroThree);

        Assert.AreEqual(heroTwo, this.repository.GetHero("Stancho"));
    }
}