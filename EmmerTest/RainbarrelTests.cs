namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class RainbarrelTests
{
    [Test]
    public void ValidCapacities()
    {
        Assert.DoesNotThrow(() => new Rainbarrel(RainbarrelCapacity.Eighty));
        Assert.DoesNotThrow(() => new Rainbarrel(RainbarrelCapacity.Hundered));
        Assert.DoesNotThrow(() => new Rainbarrel(RainbarrelCapacity.HunderedTwenty));
    }

    [Test]
    public void FillAndEmptyRainbarrel()
    {
        var rainbarrel = new Rainbarrel(RainbarrelCapacity.Hundered);
        int amount = 5;
        rainbarrel.FillContent(amount);
        Assert.That(rainbarrel.Contents, Is.EqualTo(amount));

        rainbarrel.EmptyContent();
        Assert.That(rainbarrel.Contents, Is.EqualTo(0));
    }
}