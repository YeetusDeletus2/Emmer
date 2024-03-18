namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class OilbarrelTests
{
    [Test]
    public void CapacityIs159()
    {
        var oilBarrel = new Oilbarrel();
        Assert.That(oilBarrel.Capacity, Is.EqualTo(159));
    }

    [Test]
    public void FillAndEmptyOilbarrel()
    {
        var oilbarrel = new Oilbarrel();
        int amount = 5;
        oilbarrel.FillContent(amount);
        Assert.That(oilbarrel.Contents, Is.EqualTo(amount));

        oilbarrel.EmptyContent();
        Assert.That(oilbarrel.Contents, Is.EqualTo(0));
    }
}