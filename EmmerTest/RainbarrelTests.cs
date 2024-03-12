namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class RainbarrelTests
{
    [Test]
    public void ValidCapacities()
    {
        Assert.DoesNotThrow(() => new Rainbarrel(80));
        Assert.DoesNotThrow(() => new Rainbarrel(100));
        Assert.DoesNotThrow(() => new Rainbarrel(120));
    }

    [Test]
    public void InvalidCapacities()
    {
        Assert.Throws<WrongCapacityException>(() => new Rainbarrel(50));
        Assert.Throws<WrongCapacityException>(() => new Rainbarrel(110));
        Assert.Throws<WrongCapacityException>(() => new Rainbarrel(130));
    }

    [Test]
    public void FillAndEmptyRainbarrel()
    {
        var rainbarrel = new Rainbarrel(100);
        int amount = 5;
        rainbarrel.IncreaseContent(amount);
        Assert.That(rainbarrel.Contents, Is.EqualTo(amount));

        rainbarrel.EmptyContent();
        Assert.That(rainbarrel.Contents, Is.EqualTo(0));
    }
}