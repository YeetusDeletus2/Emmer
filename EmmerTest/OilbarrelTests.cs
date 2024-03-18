namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class OilbarrelTests
{
    [Test]
    public void CapacityIs159()
    {
        Oilbarrel oilBarrel = new Oilbarrel();
        Assert.That(oilBarrel.Capacity, Is.EqualTo(Oilbarrel.MaxCapacity));
    }

    [Test]
    public void FillAndEmptyOilbarrel()
    {
        Oilbarrel oilbarrel = new Oilbarrel();
        int amount = 5;
        oilbarrel.FillContent(amount);
        Assert.That(oilbarrel.Contents, Is.EqualTo(amount));

        oilbarrel.EmptyContent();
        Assert.That(oilbarrel.Contents, Is.EqualTo(0));
    }
}